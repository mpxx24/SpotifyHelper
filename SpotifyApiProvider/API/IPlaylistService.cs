using SpotifyApiProvider.API.Models;

namespace SpotifyApiProvider.API {
    public interface IPlaylistService {
        PlaylistsWrapper GetPlaylistFromJson(string json);
        PlaylistTracks GetTracksFromJson(string json);
        PlaylistTracks GetTracksFromPlaylist(Playlist playlist, string username);
        void CreatePlaylistForUser(string userame, string parameters);
        PlaylistsWrapper GetUserPlaylists(string username);
    }
}