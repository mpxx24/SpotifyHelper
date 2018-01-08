using Newtonsoft.Json;
using SpotifyApiProvider.API.Classes.Playlist;
using SpotifyApiProvider.API.Models;

namespace SpotifyApiProvider.API {
    public class PlaylistService : IPlaylistService {
        public Playlist GetPlaylistFromJson(string json) {
            return JsonConvert.DeserializeObject<Playlist>(json);
        }

        public PlaylistTracks GetTracksFromJson(string json) {
            return JsonConvert.DeserializeObject<PlaylistTracks>(json);
        }
    }
}