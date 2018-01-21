using System.Collections.Generic;

//TODO: clean up namespace + class names (dupl with playlist...)
//abracadabra summon [attributes]
namespace SpotifyApiWrapper.API.Models {
    public class ExternalUrls {
        public string spotify { get; set; }
    }

    public class Image {
        public int? height { get; set; }
        public string url { get; set; }
        public int? width { get; set; }
    }

    public class Owner {
        public string display_name { get; set; }
        public string href { get; set; }
        public string id { get; set; }
    }

    public class Tracks {
        public string href { get; set; }
        public int total { get; set; }
    }

    public class Playlist {
        public bool collaborative { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
        public Tracks tracks { get; set; }
        public string uri { get; set; }
    }

    public class PlaylistsRoot{
        public string href { get; set; }
        public List<Playlist> items { get; set; }
    }
}