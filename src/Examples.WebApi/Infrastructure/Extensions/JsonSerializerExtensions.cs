using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Examples.WebApi.Infrastructure.Extensions
{
    public static class JsonSerializerExtensions
    {
        public static JsonOptions UseCustomOptions(this JsonOptions options)
        {
            //options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;  // (default)

            // Properties with default values are ignored during serialization or deserialization. (default Never)
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;

            // Read-only properties are ignored during serialization. (default false)
            options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;

            // Configure a converts enumeration values to and from strings.
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            return options;
        }
    }
}