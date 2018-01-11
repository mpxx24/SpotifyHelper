using Newtonsoft.Json;
using SpotifyApiProvider.API.Classes.Playlist;
using SpotifyApiProvider.API.Models;

namespace SpotifyApiProvider.API {
    public class PlaylistService : IPlaylistService {
        private readonly IRequestHelper requestHelper;

        public PlaylistService(IRequestHelper requestHelper) {
            this.requestHelper = requestHelper;
        }

        public Playlist GetPlaylistFromJson(string json) {
            return JsonConvert.DeserializeObject<Playlist>(json);
        }

        public PlaylistTracks GetTracksFromJson(string json) {
            return JsonConvert.DeserializeObject<PlaylistTracks>(json);
        }

        //TODO: this should be IEnumerable<T>
        public Playlist GetUserPlaylists(string username) {
            var playlists = this.requestHelper.PerformRequest(string.Format(ApiAdresses.User, username));
            return this.GetPlaylistFromJson(playlists);
        }

        //TODO: IMPLEMENT once again
        //this should be IEnumerable<T>
        public PlaylistTracks GetTracksFromPlaylist(Playlist playlist, string username) {
            //PlaylistTracks result;
            //foreach (var pItem in playlist.items) {
            //    try {
            //        var playlistTracks = this.requestHelper.PerformRequest(string.Format(ApiAdresses.TracksFromPlaylist, username, pItem.id));
            //        var tracks = this.GetTracksFromJson(playlistTracks);
            //    }
            //    catch (Exception) {
            //    }
            //}
            //return result;

            return new PlaylistTracks();
        }

        //TODO: pass parameters
        public void CreatePlaylistForUser(string userame) {
            //this.requestHelper.PerformRequest(string.Format(ApiAdresses.CreatePlaylist, userame));
        }
    }
}