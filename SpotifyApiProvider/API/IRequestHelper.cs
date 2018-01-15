using System.Collections.Generic;

namespace SpotifyApiProvider.API {
    public interface IRequestHelper {
        string GetData(string address, IDictionary<string, string> parameters = null);
        string PostData(string address, string parameters);
    }
}