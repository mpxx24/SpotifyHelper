using System.Collections.Generic;

namespace SpotifyApiWrapper.API.Helpers {
    public static class ObjectFromStringListHelper {
        public static string CreateObject(string type, string name, IDictionary<string, string> properties) {
            var objectbuilder = new ObjectFromStringListBuilder(type, name);

            foreach (var propertyName in properties) {
                objectbuilder.AddProperty(propertyName.Value, propertyName.Key);
            }

            return objectbuilder.GetObjectAsString();
        }
    }
}