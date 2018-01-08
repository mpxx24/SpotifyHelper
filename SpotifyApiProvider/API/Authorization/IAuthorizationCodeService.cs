namespace SpotifyApiProvider.API.Authorization {
    public interface IAuthorizationCodeService {
        Token GetToken();
        string GetAuthKey();
    }
}