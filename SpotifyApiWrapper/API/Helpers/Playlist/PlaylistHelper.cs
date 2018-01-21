using SpotifyApiWrapper.API.Contracts;

namespace SpotifyApiWrapper.API.Helpers.Playlist {
    internal class PlaylistHelper {
        public static IParameters GetDefaultPlaylistParameters() {
            return new PlaylistParameters();
        }
    }
}