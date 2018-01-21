using System;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;

namespace SpotifyApiWrapper.API.Helpers.Playlist {
    [Serializable]
    public class PlaylistParameters : IParameters {
        [JsonProperty(PropertyName = "name")]
        public string PlaylistName { get; set; }

        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }
    }
}