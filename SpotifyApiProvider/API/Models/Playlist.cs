﻿using System.Collections.Generic;

//TODO: clean up namespace + class names (dupl with playlist...)
//abracadabra summon [attributes]
namespace SpotifyApiProvider.API.Classes.Playlist {
    public class ExternalUrls {
        public string spotify { get; set; }
    }

    public class Image {
        public int? height { get; set; }
        public string url { get; set; }
        public int? width { get; set; }
    }

    public class ExternalUrls2 {
        public string spotify { get; set; }
    }

    public class Owner {
        public string display_name { get; set; }
        public ExternalUrls2 external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Tracks {
        public string href { get; set; }
        public int total { get; set; }
    }

    public class Item {
        public bool collaborative { get; set; }
        public ExternalUrls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
        public bool @public { get; set; }
        public string snapshot_id { get; set; }
        public Tracks tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }

    public class Playlist {
        public string href { get; set; }
        public List<Item> items { get; set; }
        public int limit { get; set; }
        public string next { get; set; }
        public int offset { get; set; }
        public object previous { get; set; }
        public int total { get; set; }
    }
}