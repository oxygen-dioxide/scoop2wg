using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Scoop2wg.ScoopModels
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.5.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class ScoopArchitecture
    {

        [JsonProperty("bin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ShimListConverter))]
        public List<Shim> Bin { get; set; }

        [JsonProperty("env_add_path", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Env_add_path { get; set; }

        [JsonProperty("env_set", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Env_set { get; set; }

        [JsonProperty("extract_dir", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Extract_dir { get; set; }

        [JsonProperty("hash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Hash { get; set; }

        [JsonProperty("installer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ScoopInstaller Installer { get; set; }

        [JsonProperty("post_install", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Post_install { get; set; }

        [JsonProperty("post_uninstall", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Post_uninstall { get; set; }

        [JsonProperty("pre_install", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Pre_install { get; set; }

        [JsonProperty("pre_uninstall", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Pre_uninstall { get; set; }

        [JsonProperty("shortcuts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        [JsonConverter(typeof(ShimListConverter))]
        public List<Shim> Shortcuts { get; set; }

        [JsonProperty("uninstaller", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uninstaller Uninstaller { get; set; }

        [JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Url { get; set; }

        [JsonIgnore]
        public string ArchitectureValue { get; set; }

        [JsonIgnore]
        public bool Innosetup { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.5.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class ScoopInstaller
    {

        [JsonProperty("args", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<String> Args { get; set; }

        [JsonProperty("file", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string File { get; set; }

        [JsonProperty("script", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<String> Script { get; set; }

        [JsonProperty("keep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Keep { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.5.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Uninstaller
    {
        [JsonProperty("args", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<String> Args { get; set; }

        [JsonProperty("file", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string File { get; set; }

        [JsonProperty("script", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<String> Script { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.5.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class ScoopManifest
    {

        [JsonProperty("$schema", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Schema { get; set; }

        [JsonProperty("architecture", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, ScoopArchitecture> Architecture { get; set; }

        [JsonProperty("bin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ShimListConverter))]
        public List<Shim> Bin { get; set; }

        //[JsonProperty("persist", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        //public StringOrArrayOfStringsOrAnArrayOfArrayOfStrings Persist { get; set; }

        [JsonProperty("depends", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Depends { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("env_add_path", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Env_add_path { get; set; }

        [JsonProperty("env_set", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Env_set { get; set; }

        [JsonProperty("extract_dir", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Extract_dir { get; set; }

        [JsonProperty("extract_to", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Extract_to { get; set; }

        [JsonProperty("hash", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Hash { get; set; }

        [JsonProperty("homepage", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        public string Homepage { get; set; }

        /// <summary>
        /// True if the installer InnoSetup based. Found in https://github.com/ScoopInstaller/Main/search?l=JSON&amp;q=innosetup
        /// </summary>
        [JsonProperty("innosetup", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public bool Innosetup { get; set; }

        [JsonProperty("installer", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public ScoopInstaller Installer { get; set; }

        [JsonProperty("license", Required = Required.Always)]
        [JsonConverter(typeof(LicenseConverter))]
        public License License { get; set; }

        [JsonProperty("notes", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Notes { get; set; }

        [JsonProperty("post_install", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Post_install { get; set; }

        [JsonProperty("post_uninstall", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Post_uninstall { get; set; }

        [JsonProperty("pre_install", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Pre_install { get; set; }

        [JsonProperty("pre_uninstall", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Pre_uninstall { get; set; }

        [JsonProperty("psmodule", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Psmodule Psmodule { get; set; }

        [JsonProperty("shortcuts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.MinLength(1)]
        [JsonConverter(typeof(ShimListConverter))]
        public List<Shim> Shortcuts { get; set; }

        [JsonProperty("uninstaller", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Uninstaller Uninstaller { get; set; }

        [JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringOrListOfStringConverter))]
        public List<string> Url { get; set; }

        [JsonProperty("version", Required = Required.Always)]
        [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^[\w\.\-+_]+$")]
        public string Version { get; set; }

        public List<ScoopArchitecture> GetArchitectures()
        {
            if (Architecture == null || Architecture.Count == 0)
            {
                return new List<ScoopArchitecture>
                {
                    new ScoopArchitecture
                    {
                        ArchitectureValue = "neutral",
                        Bin = this.Bin,
                        Env_add_path = this.Env_add_path,
                        Env_set = this.Env_set,
                        Extract_dir = this.Extract_dir,
                        Hash = this.Hash,
                        Installer = this.Installer,
                        Post_install = this.Post_install,
                        Post_uninstall = this.Post_uninstall,
                        Pre_install = this.Pre_install,
                        Pre_uninstall = this.Pre_uninstall,
                        Shortcuts = this.Shortcuts,
                        Uninstaller = this.Uninstaller,
                        Url = this.Url,
                        Innosetup = this.Innosetup,
                    }
                };
            }
            var list = Architecture.Select(kv => new ScoopArchitecture
            {
                ArchitectureValue = kv.Key,
                Bin = kv.Value.Bin ?? this.Bin,
                Env_add_path = kv.Value.Env_add_path ?? this.Env_add_path,
                Env_set = kv.Value.Env_set ?? this.Env_set,
                Extract_dir = kv.Value.Extract_dir ?? this.Extract_dir,
                Hash = kv.Value.Hash ?? this.Hash,
                Installer = kv.Value.Installer ?? this.Installer,
                Post_install = kv.Value.Post_install ?? this.Post_install,
                Post_uninstall = kv.Value.Post_uninstall ?? this.Post_uninstall,
                Pre_install = kv.Value.Pre_install ?? this.Pre_install,
                Pre_uninstall = kv.Value.Pre_uninstall ?? this.Pre_uninstall,
                Shortcuts = kv.Value.Shortcuts ?? this.Shortcuts,
                Uninstaller = kv.Value.Uninstaller ?? this.Uninstaller,
                Url = kv.Value.Url ?? this.Url,
                Innosetup = this.Innosetup,
            }).ToList();
            return list;
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "11.5.0.0 (Newtonsoft.Json v13.0.0.0)")]
    public partial class Psmodule
    {

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

    }

    //以下是我自定义的解析器
    public class StringOrListOfStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<string>);
        }

        // 反序列化逻辑
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                // 如果是单个字符串，将其放入列表中
                return new List<string> { token.ToString() };
            }
            else if (token.Type == JTokenType.Array)
            {
                // 如果是数组，直接反序列化为 List<string>
                return token.ToObject<List<string>>();
            }

            // 处理其他情况，例如 null
            return new List<string>();
        }

        // 序列化逻辑，这里我们不需要，所以返回 false。
        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter is for deserialization only.");
        }
    }

    public class Shim
    {
        public string Executable { get; set; }
        public string Name { get; set; }
        public string Args { get; set; }
    }

    public class ShimListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<Shim>);
        }

        Shim ParseShim(JToken token)
        {
            if (token.Type == JTokenType.String)
            {
                return new Shim
                {
                    Executable = token.ToString(),
                };
            }
            else if (token.Type == JTokenType.Array)
            {
                List<string>? strs = token.ToObject<List<string>>();
                if (strs == null)
                {
                    throw new Exception("Failed to parse shim");
                }
                return new Shim
                {
                    Executable = strs[0],
                    Name = strs.Count >= 2 ? strs[1] : null,
                    Args = strs.Count >= 3 ? strs[2] : null,
                };
            }
            throw new Exception("Failed to parse shim");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                return new List<Shim> { ParseShim(token) };
            }
            else if (token.Type == JTokenType.Array)
            {
                return token.ToArray().Select(ParseShim).ToList();
            }
            return new List<Shim>();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter is for deserialization only.");
        }
    }

    public class License
    {
        [JsonProperty("identifier", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Identifier { get; set; }

        [JsonProperty("url", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
    }

    public class LicenseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(License);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                return new License
                {
                    Identifier = token.ToString(),
                };
            }
            else
            {
                return token.ToObject<License>();
            }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("This converter is for deserialization only.");
        }
    }
}