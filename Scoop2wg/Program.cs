using CommandLine;
using Newtonsoft.Json;
using Scoop2wg.ScoopModels;
using Scoop2wg.WingetModels;
using Scoop2wg.WingetModels.Version;
using Scoop2wg.WingetModels.DefaultLocale;
using Scoop2wg.WingetModels.Installer;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Scoop2wg
{
    class Program
    {
        public class Options
        {
            [Value(0, MetaName = "Input", Required = true, HelpText = "Input scoop manifest file name or scoop app name")]
            public string Input { get; set; }

            [Option('i', "identifier", Required = false, HelpText = "Output winget package identifier")]
            public string Identifier { get; set; }

            [Option('o', "output", Required = false, HelpText = "Output path")]
            public string Output { get; set; }
        }

        static void Main(string[] args)
        {
            //args= ["obsidian"];


            Console.WriteLine("Scoop2wg");
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(RunOptions);
        }

        static string GitHubUsernameFromUrl(string url)
        {
            if (url.Contains("github.com"))
            {
                var parts = url.Split('/');
                int index = Array.IndexOf(parts, "github.com");
                if (index >= 0 && index + 1 < parts.Length)
                {
                    return parts[index + 1];
                }
            }
            return null;}

        static void RunOptions(Options opts)
        {
            string scoopManifestStr = "";
            string scoopAppName = opts.Input;
            if (File.Exists(opts.Input))
            {
                scoopManifestStr = File.ReadAllText(opts.Input);
                scoopAppName = Path.GetFileNameWithoutExtension(opts.Input);
            }
            else
            {
                //run "scoop cat <appname> and get the output"
                var proc = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "scoop.cmd",
                        Arguments = $"cat {opts.Input}",
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }
                };
                proc.Start();
                scoopManifestStr = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
            }
            var scoopManifest = JsonConvert.DeserializeObject<ScoopManifest>(scoopManifestStr);

            if (scoopManifest == null)
            {
                Console.WriteLine("Failed to parse scoop manifest");
                return;
            }

            string identifier = opts.Identifier;
            if (string.IsNullOrEmpty(identifier))
            {
                string? gitHubUsername = new List<string> { scoopManifest.Homepage }
                    .Concat(scoopManifest.GetArchitectures().SelectMany(a => a.Url ?? Enumerable.Empty<string>()))
                    .Where(url => !string.IsNullOrEmpty(url))
                    .Select(url => GitHubUsernameFromUrl(url))
                    .FirstOrDefault(name => !string.IsNullOrEmpty(name));
                if (!string.IsNullOrEmpty(gitHubUsername))
                {
                    identifier = $"{gitHubUsername}.{scoopAppName}";
                }
                else
                {
                    identifier = $"{scoopAppName}.{scoopAppName}";
                }
            }
            Console.WriteLine($"Using winget package identifier: {identifier}");

            var versionManifest = new VersionManifest()
            {
                PackageIdentifier = identifier,
                PackageVersion = scoopManifest.Version,
                DefaultLocale = "en-US"
            };

            var defaultLocaleManifest = new DefaultLocaleManifest()
            {
                PackageName = identifier.Split('.')[1],
                Publisher = identifier.Split('.')[0],
                PackageIdentifier = identifier,
                PackageVersion = scoopManifest.Version,
                PackageLocale = "en-US",
                PackageUrl = scoopManifest.Homepage,
                License = scoopManifest.License?.Identifier ?? null,
                LicenseUrl = scoopManifest.License?.Url ?? null,
                ShortDescription = scoopManifest.Description,
            };

            var installerManifest = new InstallerManifest()
            {
                PackageIdentifier = identifier,
                PackageVersion = scoopManifest.Version,
                Installers = scoopManifest.GetArchitectures().Select(ConvertInstaller).ToList(),
            };

            var wingetManifests = new Manifests()
            {
                VersionManifest = versionManifest,
                DefaultLocaleManifest = defaultLocaleManifest,
                InstallerManifest = installerManifest,
            };
            string outputPath = opts.Output ?? ".";
            Directory.CreateDirectory(outputPath);
            string extension = ".yaml";

            var serializer = new SerializerBuilder()
                .WithQuotingNecessaryStrings()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull).Build();
            if (wingetManifests.VersionManifest != null)
            {
                string fileName = Manifests.GetFileName(wingetManifests.VersionManifest, extension);
                string filePath = Path.Combine(outputPath, fileName);
                var yaml = serializer.Serialize(wingetManifests.VersionManifest);
                File.WriteAllText(filePath, yaml);
                Console.WriteLine($"Wrote {filePath}");
            }
            if (wingetManifests.DefaultLocaleManifest != null)
            {
                string fileName = Manifests.GetFileName(wingetManifests.DefaultLocaleManifest, extension);
                string filePath = Path.Combine(outputPath, fileName);
                var yaml = serializer.Serialize(wingetManifests.DefaultLocaleManifest);
                File.WriteAllText(filePath, yaml);
                Console.WriteLine($"Wrote {filePath}");
            }
            if (wingetManifests.InstallerManifest != null)
            { 
                string fileName = Manifests.GetFileName(wingetManifests.InstallerManifest, extension);
                string filePath = Path.Combine(outputPath, fileName);
                var yaml = serializer.Serialize(wingetManifests.InstallerManifest);
                File.WriteAllText(filePath, yaml);
                Console.WriteLine($"Wrote {filePath}");
            }
            
        }

        static Installer ConvertInstaller(ScoopArchitecture scoopInstaller)
        {
            var result = new Installer();
            result.Architecture = scoopInstaller.ArchitectureValue switch
            {
                "32bit" => Architecture.X86,
                "64bit" => Architecture.X64,
                "arm64" => Architecture.Arm64,
                "neutral" => Architecture.Neutral,
            };
            result.InstallerUrl = scoopInstaller.Url[0];
            result.InstallerSha256 = scoopInstaller.Hash[0];
            if (scoopInstaller.Url[0].EndsWith(".exe"))
            {
                result.InstallerType = InstallerType.Exe;
                if (scoopInstaller.Innosetup)
                {
                    result.InstallerType = InstallerType.Inno;
                }
                else
                {
                    Console.WriteLine($"Warning: {scoopInstaller.Url[0]} is an exe, please make sure to set the silent args correctly.");
                }
            }
            else if (scoopInstaller.Url[0].EndsWith(".msi"))
            {
                result.InstallerType = InstallerType.Msi;
            }
            else
            {
                result.InstallerType = InstallerType.Zip;
                result.NestedInstallerType = NestedInstallerType.Portable;
                result.NestedInstallerFiles = (scoopInstaller.Bin ?? Enumerable.Empty<Shim>())
                    .Concat(scoopInstaller.Shortcuts ?? Enumerable.Empty<Shim>())
                    .Where(s => string.IsNullOrEmpty(s.Args))
                    .GroupBy(s => s.Executable)
                    .Select(g => g.First())
                    .Select(s => new NestedInstallerFile
                    {
                        RelativeFilePath = scoopInstaller.Extract_dir == null ? s.Executable : Path.Combine(scoopInstaller.Extract_dir[0], s.Executable),
                        PortableCommandAlias = s.Name ?? Path.GetFileNameWithoutExtension(s.Executable),
                    })
                    .ToList();
                result.ArchiveBinariesDependOnPath = true;
            }
            
            return result;
        }
    }
}