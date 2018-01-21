using System.Collections.Generic;
using SpotifyApiWrapper.API.Helpers.Playlist;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Contracts {
    internal interface IPlaylistService {
        PlaylistsRoot GetPlaylistFromJson(string json);
        TracksRoot GetTracksFromJson(string json);
        IEnumerable<Track> GetTracksFromPlaylist(string username, string playlistId);
        void CreatePlaylistForUser(IParameters parameters);
        IEnumerable<Playlist> GetUserPlaylists(string username);
    }
}