using System.Collections.Generic;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;
using SpotifyApiWrapper.Core;

namespace SpotifyApiWrapper.API.Wrappers {
    public static class PlaylistsWrapper {
        public static IEnumerable<Playlist> GetUsersPlaylists(string username) {
            return IoC.Resolve<IPlaylistService>().GetUserPlaylists(username);
        }

        public static IEnumerable<Track> GetSongsFromPlaylist(string username, string playlistId) {
            return IoC.Resolve<IPlaylistService>().GetTracksFromPlaylist(username, playlistId);
        }
    }
}