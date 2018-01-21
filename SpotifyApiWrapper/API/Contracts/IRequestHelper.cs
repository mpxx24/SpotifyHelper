namespace SpotifyApiWrapper.API.Contracts {
    internal interface IRequestHelper {
        string GetData(string address, IParameters parameters = null);
        string PostData(string address, string parameters);
    }
}