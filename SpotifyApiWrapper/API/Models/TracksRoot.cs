using System.Collections.Generic;

namespace SpotifyApiWrapper.API.Models {
    public class AddedBy {
        public string href { get; set; }
        public string id { get; set; }
        public string uri { get; set; }
    }

    public class Artist {
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
    }

    public class Album {
        public string album_type { get; set; }
        public List<Artist> artists { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
    }

    public class Track {
        public Album album { get; set; }
        public List<Artist> artists { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public string uri { get; set; }
    }

    public class TrackWrapper {
        public Track track { get; set; }
    }

    public class TracksRoot {
        public string href { get; set; }
        public List<TrackWrapper> items { get; set; }
    }


    public class ReccomendationTracksRoot {
        public List<Track> tracks { get; set; }
        public List<Seed> seeds { get; set; }
    }

    public class Seed {
        public int initialPoolSize { get; set; }
        public int afterFilteringSize { get; set; }
        public int afterRelinkingSize { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }
}