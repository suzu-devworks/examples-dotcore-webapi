using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ExamplesWebApi.Core
{
    [JsonConverter(typeof(StaticStatusJsonConverter))]
    public sealed class StaticStatus
    {
        public static readonly StaticStatus Unknown = new(0, null, null);
        public static readonly StaticStatus Wait = new(200, nameof(Wait), @"^[Ww]ait$");
        public static readonly StaticStatus Activate = new(300, nameof(Activate), @"^[Aa]ctivate$");
        public static readonly StaticStatus Completed = new(100, nameof(Completed), @"^[Cc]ompleted$");

        private StaticStatus(int value, string display, string pattern)
        {
            Value = value;
            Display = display;
            _pattern = (pattern is null) ? null : new(pattern, RegexOptions.Compiled);
        }

        public int Value { get; }
        public string Display { get; }

        private Regex _pattern;

        public override string ToString() => this.Display;

        public static IEnumerable<StaticStatus> All => Array.AsReadOnly(new[]{
            StaticStatus.Wait,
            StaticStatus.Activate,
            StaticStatus.Completed,
        });

        public static StaticStatus Get(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            var entry = All.FirstOrDefault(x => x._pattern.IsMatch(value));
            if (entry is not null)
            {
                return entry;
            }

            return Unknown;
        }

        public class StaticStatusJsonConverter : JsonConverter<StaticStatus>
        {
            public override StaticStatus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
                => StaticStatus.Get(reader.GetString());

            public override void Write(Utf8JsonWriter writer, StaticStatus value, JsonSerializerOptions options)
                => writer.WriteStringValue(value?.ToString());
        }
    }
}