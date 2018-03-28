using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyApiWrapper.API.Models {
    public class ExternalUrls {
        [JsonProperty("spotify")]
        public string Spotify { get; set; }
    }

    public class Image {
        [JsonProperty("height")]
        public int? Height { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int? Width { get; set; }
    }

    public class Owner {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Tracks {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Playlist {
        [JsonProperty("collaborative")]
        public bool Collaborative { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("tracks")]
        public Tracks Tracks { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class PlaylistsRoot {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public List<Playlist> Items { get; set; }
    }
}