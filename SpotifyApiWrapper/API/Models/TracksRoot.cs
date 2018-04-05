using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyApiWrapper.API.Models {
    public class AddedBy {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class Artist {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("genres")]
        public IEnumerable<string> Genres { get; set; }
    }

    public class Album {
        [JsonProperty("album_type")]
        public string AlbumType { get; set; }

        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class Track {
        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("artists")]
        public List<Artist> Artists { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public int Popularity { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public class TrackWrapper {
        [JsonProperty("track")]
        public Track Track { get; set; }
    }

    public class TracksRoot {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public List<TrackWrapper> Items { get; set; }
    }

    public class ReccomendationTracksRoot {
        [JsonProperty("tracks")]
        public List<Track> Tracks { get; set; }

        [JsonProperty("seeds")]
        public List<Seed> Seeds { get; set; }
    }

    public class Seed {
        [JsonProperty("initialPoolSize")]
        public int Initialpoolsize { get; set; }

        [JsonProperty("afterFilteringSize")]
        public int Afterfilteringsize { get; set; }

        [JsonProperty("afterRelinkingSize")]
        public int Afterrelinkingsize { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
    }
}