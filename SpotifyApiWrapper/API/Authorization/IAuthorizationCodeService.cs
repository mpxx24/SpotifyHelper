namespace SpotifyApiWrapper.API.Authorization {
    internal interface IAuthorizationCodeService {
        Token GetToken();
        string GetAuthKey();
    }
}