using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CSharp;

namespace SpotifyApiWrapper.API.Helpers {
    public static class ApiModelToOneWithAttributesHelper {
        public static string ConvertType(Type modelType) {
            //do not need anything more than class now
            var builder = new ApiModelToOneWithAttributesBuilder("class", modelType.Name);

            foreach (var propertyInfo in modelType.GetProperties()) {
                builder.AddProperty(IsSystemType(propertyInfo.PropertyType) && !IsPropertyOfNullableType(propertyInfo.PropertyType)
                                        ? GetTypeAlias(propertyInfo.PropertyType)
                                        : GetGenericPropertyName(propertyInfo.PropertyType), propertyInfo.Name);
            }

            return builder.GetObjectAsString();
        }

        private static bool IsSystemType(Type type) {
            //hacky hackery hack
            return type.Namespace == "System";
        }

        private static string GetTypeAlias(Type propertyType) {
            using (var codeProvider = new CSharpCodeProvider()) {
                var typeRef = new CodeTypeReference(propertyType);
                return codeProvider.GetTypeOutput(typeRef);
            }
        }

        private static string GetGenericPropertyName(Type propertyType) {
            //non-generics
            if (!propertyType.IsGenericType) {
                return propertyType.Name;
            }

            var sb = new StringBuilder();

            //nullable
            if (IsPropertyOfNullableType(propertyType)) {
                if (propertyType.GetGenericArguments().Length == 1) {
                    sb.Append($"{GetTypeAlias(propertyType.GetGenericArguments()[0])}?");
                }
            }
            else {
                sb.Append(propertyType.Name);

                if (sb.Length > 0) {
                    sb.Length -= 2;
                }
                //other generics i.e. collections
                sb.Append("<");
                foreach (var genericArgument in propertyType.GetGenericArguments()) {
                    sb.Append(IsSystemType(genericArgument)
                                  ? $"{GetTypeAlias(genericArgument)}, "
                                  : $"{genericArgument.Name}, ");
                }

                if (sb.Length > 0) {
                    sb.Length -= 2;
                }

                sb.Append(">");
            }
            return sb.ToString();
        }

        public static IEnumerable<string> ConvertMultipleTypes(IEnumerable<Type> types) {
            return types.Select(ConvertType).ToList();
        }

        private static bool IsPropertyOfNullableType(Type propertyType) {
            return Nullable.GetUnderlyingType(propertyType) != null;
        }
    }
}