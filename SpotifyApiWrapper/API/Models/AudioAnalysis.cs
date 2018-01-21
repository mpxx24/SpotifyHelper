using System.Collections.Generic;

namespace SpotifyApiWrapper.API.Models {
    public class Meta {
        public string analyzer_version { get; set; }
        public string platform { get; set; }
        public string detailed_status { get; set; }
        public int status_code { get; set; }
        public int timestamp { get; set; }
        public double analysis_time { get; set; }
        public string input_process { get; set; }
    }

    public class TrackAnalysis {
        public int num_samples { get; set; }
        public double duration { get; set; }
        public string sample_md5 { get; set; }
        public int offset_seconds { get; set; }
        public int window_seconds { get; set; }
        public int analysis_sample_rate { get; set; }
        public int analysis_channels { get; set; }
        public double end_of_fade_in { get; set; }
        public double start_of_fade_out { get; set; }
        public double loudness { get; set; }
        public double tempo { get; set; }
        public double tempo_confidence { get; set; }
        public int time_signature { get; set; }
        public double time_signature_confidence { get; set; }
        public int key { get; set; }
        public double key_confidence { get; set; }
        public int mode { get; set; }
        public double mode_confidence { get; set; }
        public string codestring { get; set; }
        public double code_version { get; set; }
        public string echoprintstring { get; set; }
        public double echoprint_version { get; set; }
        public string synchstring { get; set; }
        public double synch_version { get; set; }
        public string rhythmstring { get; set; }
        public double rhythm_version { get; set; }
    }

    public class Bar {
        public double start { get; set; }
        public double duration { get; set; }
        public double confidence { get; set; }
    }

    public class Beat {
        public double start { get; set; }
        public double duration { get; set; }
        public double confidence { get; set; }
    }

    public class Tatum {
        public double start { get; set; }
        public double duration { get; set; }
        public double confidence { get; set; }
    }

    public class Section {
        public double start { get; set; }
        public double duration { get; set; }
        public double confidence { get; set; }
        public double loudness { get; set; }
        public double tempo { get; set; }
        public double tempo_confidence { get; set; }
        public int key { get; set; }
        public double key_confidence { get; set; }
        public int mode { get; set; }
        public double mode_confidence { get; set; }
        public int time_signature { get; set; }
        public double time_signature_confidence { get; set; }
    }

    public class Segment {
        public double start { get; set; }
        public double duration { get; set; }
        public double confidence { get; set; }
        public double loudness_start { get; set; }
        public double loudness_max_time { get; set; }
        public double loudness_max { get; set; }
        public List<double> pitches { get; set; }
        public List<double> timbre { get; set; }
        public double? loudness_end { get; set; }
    }

    public class AudioAnalysis {
        public Meta meta { get; set; }
        public TrackAnalysis track { get; set; }
        public List<Bar> bars { get; set; }
        public List<Beat> beats { get; set; }
        public List<Tatum> tatums { get; set; }
        public List<Section> sections { get; set; }
        public List<Segment> segments { get; set; }
    }
}