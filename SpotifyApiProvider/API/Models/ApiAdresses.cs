namespace SpotifyApiProvider.API.Models {
    public static class ApiAdresses {
        public static readonly string Token = "https://accounts.spotify.com/api/token";
        public static readonly string User = "https://api.spotify.com/v1/users/{0}/playlists";
        public static readonly string TracksFromPlaylist = "https://api.spotify.com/v1/users/{0}/playlists/{1}/tracks";

    }
}