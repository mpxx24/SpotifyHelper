using System;
using System.Collections.Generic;

namespace SpotifyApiProvider.API.Models {
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

    public class PlaylistTracks {
        public string href { get; set; }
        public List<TrackWrapper> items { get; set; }
    }
}