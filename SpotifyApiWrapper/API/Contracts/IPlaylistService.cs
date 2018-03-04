using System.Collections.Generic;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Contracts {
    internal interface IPlaylistService {
        IEnumerable<Track> GetTracksFromPlaylist(string username, string playlistId);
        IEnumerable<Playlist> GetUserPlaylists(string username);
    }
}