namespace SpotifyApiWrapper.API.Models {
    internal static class ApiAdresses {
        public static readonly string Token = "https://accounts.spotify.com/api/token";
        public static readonly string User = "https://api.spotify.com/v1/users/{0}/playlists";
        public static readonly string TracksFromPlaylist = "https://api.spotify.com/v1/users/{0}/playlists/{1}/tracks";
        public static readonly string CreatePlaylist = "https://api.spotify.com/v1/users/{0}/playlists";
        public static readonly string Authorization = "https://accounts.spotify.com/authorize";
        public static readonly string AudioFeatures = "https://api.spotify.com/v1/audio-features/{0}";
        public static readonly string AudioAnalysis = "https://api.spotify.com/v1/audio-analysis/{0}";
        public static readonly string Reccomendations = "https://api.spotify.com/v1/recommendations";
    }
}