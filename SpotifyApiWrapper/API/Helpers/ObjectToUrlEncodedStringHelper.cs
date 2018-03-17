using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;

namespace SpotifyApiWrapper.API.Helpers {
    internal static class ObjectToUrlEncodedStringHelper {
        public static string ConvertToUrlEncodedString(this IParameters parameters) {
            var result = new Dictionary<string, string>();
            if (parameters == null) {
                return string.Empty;
            }

            var parametersType = parameters.GetType();
            foreach (var prop in parametersType.GetProperties()) {
                foreach (var customAttribute in prop.GetCustomAttributes(true)) {
                    string propValueAsString;

                    if (prop.GetValue(parameters, null) is IEnumerable<string>) {
                        propValueAsString = GetEnumerableElementsAsString((IEnumerable<string>) prop.GetValue(parameters, null));
                    }
                    else {
                        propValueAsString = prop.GetValue(parameters, null)?.ToString();
                    }
                    
                    if (string.IsNullOrEmpty(propValueAsString)) {
                        continue;
                    }

                    if (customAttribute is JsonPropertyAttribute jsonPropAttribute) {
                        result.Add(jsonPropAttribute.PropertyName, propValueAsString);
                    }
                    else {
                        result.Add(prop.Name, propValueAsString);
                    }
                }
            }

            using (var content = new FormUrlEncodedContent(result)) {
                return content.ReadAsStringAsync().Result;
            }
        }

        private static string GetEnumerableElementsAsString(IEnumerable<string> enumerable) {
            var sb = new StringBuilder();
            foreach (var elem in enumerable) {
                sb.Append($"{elem},");
            }

            if (sb.Length >= 1) {
                sb.Length -= 1;
            }
            return sb.ToString();
        }
    }
}