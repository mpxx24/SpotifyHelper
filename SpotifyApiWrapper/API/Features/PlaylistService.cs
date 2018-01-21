using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Helpers.Playlist;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class PlaylistService : IPlaylistService {
        private readonly IRequestHelper requestHelper;

        public PlaylistService(IRequestHelper requestHelper) {
            this.requestHelper = requestHelper;
        }

        public PlaylistsRoot GetPlaylistFromJson(string json) {
            try {
                return JsonConvert.DeserializeObject<PlaylistsRoot>(json);
            }
            catch (Exception ex) {
                throw new SerializationException(ex.Message);
            }
        }

        public TracksRoot GetTracksFromJson(string json) {
            try {
                return JsonConvert.DeserializeObject<TracksRoot>(json);
            }
            catch (Exception ex) {
                throw new SerializationException(ex.Message);
            }
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

        [Obsolete]
        public void CreatePlaylistForUser(IParameters parameters) {
            string playlistParameters;
            try {
                playlistParameters = JsonConvert.SerializeObject(parameters);

                var auth = this.requestHelper.GetData(ApiAdresses.Authorization);
            }
            catch (SerializationException) {
                //TODO: log
                throw;
            }

            this.requestHelper.PostData(string.Format(ApiAdresses.CreatePlaylist, ((PlaylistParameters)parameters).UserId), playlistParameters);
        }
    }
}