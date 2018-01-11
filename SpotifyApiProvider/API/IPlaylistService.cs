using SpotifyApiProvider.API.Classes.Playlist;
using SpotifyApiProvider.API.Models;

namespace SpotifyApiProvider.API {
    public interface IPlaylistService {
        Playlist GetPlaylistFromJson(string json);
        PlaylistTracks GetTracksFromJson(string json);
        PlaylistTracks GetTracksFromPlaylist(Playlist playlist, string username);
        void CreatePlaylistForUser(string userame);
        Playlist GetUserPlaylists(string username);
    }
}