namespace SpotifyApiProvider.API {
    public interface IRequestHelper {
        string GetData(string address, string token = null);
    }
}