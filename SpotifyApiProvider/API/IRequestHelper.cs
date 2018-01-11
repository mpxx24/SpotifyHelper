using SpotifyApiProvider.API.Models;

namespace SpotifyApiProvider.API {
    public interface IRequestHelper {
        string PerformRequest(string address, RequestType requestType = RequestType.GET, string parameters = null);
    }
}