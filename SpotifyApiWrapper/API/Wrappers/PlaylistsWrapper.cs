using System;
using System.Collections.Generic;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Helpers.Playlist;
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

        public static void CreatePlaylistForUser(IParameters parameters) {
            throw new NotImplementedException();

            var playlistParameters = parameters ?? PlaylistHelper.GetDefaultPlaylistParameters();
            IoC.Resolve<IPlaylistService>().CreatePlaylistForUser(playlistParameters);
        }
    }
}