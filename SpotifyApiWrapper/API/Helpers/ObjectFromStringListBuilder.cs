using System.Collections.Generic;
using System.Text;

namespace SpotifyApiWrapper.API.Helpers {
    internal class ObjectFromStringListBuilder {
        private readonly string objectAccessModifier;
        private readonly string objectName;
        private readonly string objectType;
        private readonly List<PropertyExample> properties = new List<PropertyExample>();

        public ObjectFromStringListBuilder(string objectType, string objectName, string objectAccessModifier = "public") {
            this.objectType = objectType;
            this.objectName = objectName;
            this.objectAccessModifier = objectAccessModifier;
        }

        public ObjectFromStringListBuilder AddProperty(string propertyType, string propertyName, string accessModifier = "public") {
            this.properties.Add(new PropertyExample(propertyName, propertyType, accessModifier));
            return this;
        }

        //override ToString? nah
        public string GetObjectAsString() {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.objectAccessModifier} {this.objectType} {this.objectName} {{");

            foreach (var propertyExample in this.properties) {
                sb.AppendLine(this.GetPropertyAsString(propertyExample));
                sb.AppendLine();
            }
            sb.Append("}");

            return sb.ToString();
        }

        private string GetPropertyAsString(PropertyExample propertyExample) {
            switch (this.objectType) {
                case "enum":
                    return $"\t{propertyExample.PropertyName},";
                case "class":
                    return $"\t{propertyExample.PropertyAccessModifier} {propertyExample.PropertyType} {propertyExample.PropertyName} {{get; set}}";
                default:
                    return $"\t{propertyExample.PropertyAccessModifier} {propertyExample.PropertyType} {propertyExample.PropertyName} {{get; set}}";
            }
        }
    }

    internal class PropertyExample {
        public PropertyExample(string propertyName, string propertyType, string propertyAccessModifier) {
            this.PropertyName = propertyName;
            this.PropertyType = propertyType;
            this.PropertyAccessModifier = propertyAccessModifier;
        }

        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string PropertyAccessModifier { get; set; }
    }
}