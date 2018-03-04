using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class PlaylistService : IPlaylistService {
        private readonly IRequestHelper requestHelper;

        public PlaylistService(IRequestHelper requestHelper) {
            this.requestHelper = requestHelper;
        }

        public IEnumerable<Playlist> GetUserPlaylists(string username) {
            try {
                var playlists = this.requestHelper.GetData(string.Format(ApiAdresses.User, username));
                var playlistRoot = this.GetPlaylistFromJson(playlists);

                return playlistRoot?.items;
            }
            catch (Exception ex) {
                //TODO: log & handle
                throw;
            }
        }

        public IEnumerable<Track> GetTracksFromPlaylist(string username, string playlistId) {
            var result = new List<Track>();
            try {
                var playlistTracks = this.requestHelper.GetData(string.Format(ApiAdresses.TracksFromPlaylist, username, playlistId));
                var tracksRoot = this.GetTracksFromJson(playlistTracks);
                if (tracksRoot == null) {
                    return result;
                }

                foreach (var tracksRootItem in tracksRoot.items) {
                    result.Add(tracksRootItem.track);
                }
                return result;
            }
            catch (Exception ex) {
                //TODO: log
                throw;
            }
        }

        private PlaylistsRoot GetPlaylistFromJson(string json) {
            try {
                return JsonConvert.DeserializeObject<PlaylistsRoot>(json);
            }
            catch (JsonSerializationException ex) {
                //TODO: log and handle
                throw;
            }
        }

        private TracksRoot GetTracksFromJson(string json) {
            try {
                return JsonConvert.DeserializeObject<TracksRoot>(json);
            }
            catch (JsonSerializationException ex) {
                //TODO: log and handle
                throw;
            }
        }
    }
}