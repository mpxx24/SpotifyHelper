using SpotifyApiProvider.API.Classes.Playlist;
using SpotifyApiProvider.API.Models;

namespace SpotifyApiProvider.API {
    public interface IPlaylistService {
        Playlist GetPlaylistFromJson(string json);

        PlaylistTracks GetTracksFromJson(string json);
    }
}