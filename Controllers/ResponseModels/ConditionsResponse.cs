using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VetsApiTest.Controllers.Condition
{
 public partial class ConditionResult
    {
        [JsonProperty("resourceType", NullValueHandling = NullValueHandling.Ignore)]
        public string ResourceType { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }

        [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
        public Link[] Link { get; set; }

        [JsonProperty("entry", NullValueHandling = NullValueHandling.Ignore)]
        public Entry[] Entry { get; set; }
    }

    public partial class Entry
    {
        [JsonProperty("fullUrl", NullValueHandling = NullValueHandling.Ignore)]
        public Uri FullUrl { get; set; }

        [JsonProperty("resource", NullValueHandling = NullValueHandling.Ignore)]
        public Resource Resource { get; set; }

        [JsonProperty("search", NullValueHandling = NullValueHandling.Ignore)]
        public Search Search { get; set; }
    }

    public partial class Resource
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }

        [JsonProperty("resourceType", NullValueHandling = NullValueHandling.Ignore)]
        public ResourceType? ResourceType { get; set; }

        [JsonProperty("patient", NullValueHandling = NullValueHandling.Ignore)]
        public Patient Patient { get; set; }

        [JsonProperty("dateRecorded", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DateRecorded { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public Category Code { get; set; }

        [JsonProperty("category", NullValueHandling = NullValueHandling.Ignore)]
        public Category Category { get; set; }

        [JsonProperty("clinicalStatus", NullValueHandling = NullValueHandling.Ignore)]
        public ClinicalStatus? ClinicalStatus { get; set; }

        [JsonProperty("verificationStatus", NullValueHandling = NullValueHandling.Ignore)]
        public VerificationStatus? VerificationStatus { get; set; }

        [JsonProperty("onsetDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? OnsetDateTime { get; set; }

        [JsonProperty("abatementDateTime", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? AbatementDateTime { get; set; }
    }

    public partial class Category
    {
        [JsonProperty("coding", NullValueHandling = NullValueHandling.Ignore)]
        public Coding[] Coding { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }

    public partial class Coding
    {
        [JsonProperty("system", NullValueHandling = NullValueHandling.Ignore)]
        public Uri System { get; set; }

        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public CodeUnion? Code { get; set; }

        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public string Display { get; set; }
    }

    public partial class Patient
    {
        [JsonProperty("reference", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Reference { get; set; }

        [JsonProperty("display", NullValueHandling = NullValueHandling.Ignore)]
        public Display? Display { get; set; }
    }

    public partial class Search
    {
        [JsonProperty("mode", NullValueHandling = NullValueHandling.Ignore)]
        public Mode? Mode { get; set; }
    }

    public partial class Link
    {
        [JsonProperty("relation", NullValueHandling = NullValueHandling.Ignore)]
        public string Relation { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }
    }

    public enum CodeEnum { Diagnosis, Problem };

    public enum ClinicalStatus { Active, Resolved };

    public enum Display { MrWayne846Goyette777 };

    public enum ResourceType { Condition };

    public enum VerificationStatus { Unknown };

    public enum Mode { Match };

    public partial struct CodeUnion
    {
        public CodeEnum? Enum;
        public long? Integer;

        public static implicit operator CodeUnion(CodeEnum Enum) => new CodeUnion { Enum = Enum };
        public static implicit operator CodeUnion(long Integer) => new CodeUnion { Integer = Integer };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CodeUnionConverter.Singleton,
                CodeEnumConverter.Singleton,
                ClinicalStatusConverter.Singleton,
                DisplayConverter.Singleton,
                ResourceTypeConverter.Singleton,
                VerificationStatusConverter.Singleton,
                ModeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CodeUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CodeUnion) || t == typeof(CodeUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "diagnosis":
                            return new CodeUnion { Enum = CodeEnum.Diagnosis };
                        case "problem":
                            return new CodeUnion { Enum = CodeEnum.Problem };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new CodeUnion { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type CodeUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (CodeUnion)untypedValue;
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case CodeEnum.Diagnosis:
                        serializer.Serialize(writer, "diagnosis");
                        return;
                    case CodeEnum.Problem:
                        serializer.Serialize(writer, "problem");
                        return;
                }
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type CodeUnion");
        }

        public static readonly CodeUnionConverter Singleton = new CodeUnionConverter();
    }

    internal class CodeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CodeEnum) || t == typeof(CodeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "diagnosis":
                    return CodeEnum.Diagnosis;
                case "problem":
                    return CodeEnum.Problem;
            }
            throw new Exception("Cannot unmarshal type CodeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CodeEnum)untypedValue;
            switch (value)
            {
                case CodeEnum.Diagnosis:
                    serializer.Serialize(writer, "diagnosis");
                    return;
                case CodeEnum.Problem:
                    serializer.Serialize(writer, "problem");
                    return;
            }
            throw new Exception("Cannot marshal type CodeEnum");
        }

        public static readonly CodeEnumConverter Singleton = new CodeEnumConverter();
    }

    internal class ClinicalStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ClinicalStatus) || t == typeof(ClinicalStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "active":
                    return ClinicalStatus.Active;
                case "resolved":
                    return ClinicalStatus.Resolved;
            }
            throw new Exception("Cannot unmarshal type ClinicalStatus");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ClinicalStatus)untypedValue;
            switch (value)
            {
                case ClinicalStatus.Active:
                    serializer.Serialize(writer, "active");
                    return;
                case ClinicalStatus.Resolved:
                    serializer.Serialize(writer, "resolved");
                    return;
            }
            throw new Exception("Cannot marshal type ClinicalStatus");
        }

        public static readonly ClinicalStatusConverter Singleton = new ClinicalStatusConverter();
    }

    internal class DisplayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Display) || t == typeof(Display?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Mr. Wayne846 Goyette777")
            {
                return Display.MrWayne846Goyette777;
            }
            throw new Exception("Cannot unmarshal type Display");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Display)untypedValue;
            if (value == Display.MrWayne846Goyette777)
            {
                serializer.Serialize(writer, "Mr. Wayne846 Goyette777");
                return;
            }
            throw new Exception("Cannot marshal type Display");
        }

        public static readonly DisplayConverter Singleton = new DisplayConverter();
    }

    internal class ResourceTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ResourceType) || t == typeof(ResourceType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Condition")
            {
                return ResourceType.Condition;
            }
            throw new Exception("Cannot unmarshal type ResourceType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ResourceType)untypedValue;
            if (value == ResourceType.Condition)
            {
                serializer.Serialize(writer, "Condition");
                return;
            }
            throw new Exception("Cannot marshal type ResourceType");
        }

        public static readonly ResourceTypeConverter Singleton = new ResourceTypeConverter();
    }

    internal class VerificationStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VerificationStatus) || t == typeof(VerificationStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "unknown")
            {
                return VerificationStatus.Unknown;
            }
            throw new Exception("Cannot unmarshal type VerificationStatus");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (VerificationStatus)untypedValue;
            if (value == VerificationStatus.Unknown)
            {
                serializer.Serialize(writer, "unknown");
                return;
            }
            throw new Exception("Cannot marshal type VerificationStatus");
        }

        public static readonly VerificationStatusConverter Singleton = new VerificationStatusConverter();
    }

    internal class ModeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Mode) || t == typeof(Mode?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "match")
            {
                return Mode.Match;
            }
            throw new Exception("Cannot unmarshal type Mode");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Mode)untypedValue;
            if (value == Mode.Match)
            {
                serializer.Serialize(writer, "match");
                return;
            }
            throw new Exception("Cannot marshal type Mode");
        }

        public static readonly ModeConverter Singleton = new ModeConverter();
    }
}