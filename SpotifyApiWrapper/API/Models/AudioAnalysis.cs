using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpotifyApiWrapper.API.Models {
    public class Meta {
        [JsonProperty("analyzer_version")]
        public string AnalyzerVersion { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("detailed_status")]
        public string DetailedStatus { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("analysis_time")]
        public double AnalysisTime { get; set; }

        [JsonProperty("input_process")]
        public string InputProcess { get; set; }
    }

    public class TrackAnalysis {
        [JsonProperty("num_samples")]
        public int NumSamples { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("sample_md5")]
        public string SampleMd5 { get; set; }

        [JsonProperty("offset_seconds")]
        public int OffsetSeconds { get; set; }

        [JsonProperty("window_seconds")]
        public int WindowSeconds { get; set; }

        [JsonProperty("analysis_sample_rate")]
        public int AnalysisSampleRate { get; set; }

        [JsonProperty("analysis_channels")]
        public int AnalysisChannels { get; set; }

        [JsonProperty("end_of_fade_in")]
        public double EndOfFadeIn { get; set; }

        [JsonProperty("start_of_fade_out")]
        public double StartOfFadeOut { get; set; }

        [JsonProperty("loudness")]
        public double Loudness { get; set; }

        [JsonProperty("tempo")]
        public double Tempo { get; set; }

        [JsonProperty("tempo_confidence")]
        public double TempoConfidence { get; set; }

        [JsonProperty("time_signature")]
        public int TimeSignature { get; set; }

        [JsonProperty("time_signature_confidence")]
        public double TimeSignatureConfidence { get; set; }

        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("key_confidence")]
        public double KeyConfidence { get; set; }

        [JsonProperty("mode")]
        public int Mode { get; set; }

        [JsonProperty("mode_confidence")]
        public double ModeConfidence { get; set; }

        [JsonProperty("codestring")]
        public string Codestring { get; set; }

        [JsonProperty("code_version")]
        public double CodeVersion { get; set; }

        [JsonProperty("echoprintstring")]
        public string Echoprintstring { get; set; }

        [JsonProperty("echoprint_version")]
        public double EchoprintVersion { get; set; }

        [JsonProperty("synchstring")]
        public string Synchstring { get; set; }

        [JsonProperty("synch_version")]
        public double SynchVersion { get; set; }

        [JsonProperty("rhythmstring")]
        public string Rhythmstring { get; set; }

        [JsonProperty("rhythm_version")]
        public double RhythmVersion { get; set; }
    }

    public class Bar {
        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public class Beat {
        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public class Tatum {
        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }
    }

    public class Section {
        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("loudness")]
        public double Loudness { get; set; }

        [JsonProperty("tempo")]
        public double Tempo { get; set; }

        [JsonProperty("tempo_confidence")]
        public double TempoConfidence { get; set; }

        [JsonProperty("key")]
        public int Key { get; set; }

        [JsonProperty("key_confidence")]
        public double KeyConfidence { get; set; }

        [JsonProperty("mode")]
        public int Mode { get; set; }

        [JsonProperty("mode_confidence")]
        public double ModeConfidence { get; set; }

        [JsonProperty("time_signature")]
        public int TimeSignature { get; set; }

        [JsonProperty("time_signature_confidence")]
        public double TimeSignatureConfidence { get; set; }
    }

    public class Segment {
        [JsonProperty("start")]
        public double Start { get; set; }

        [JsonProperty("duration")]
        public double Duration { get; set; }

        [JsonProperty("confidence")]
        public double Confidence { get; set; }

        [JsonProperty("loudness_start")]
        public double LoudnessStart { get; set; }

        [JsonProperty("loudness_max_time")]
        public double LoudnessMaxTime { get; set; }

        [JsonProperty("loudness_max")]
        public double LoudnessMax { get; set; }

        [JsonProperty("pitches")]
        public List<double> Pitches { get; set; }

        [JsonProperty("timbre")]
        public List<double> Timbre { get; set; }

        [JsonProperty("loudness_end")]
        public double? LoudnessEnd { get; set; }
    }

    public class AudioAnalysis {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("track")]
        public TrackAnalysis Track { get; set; }

        [JsonProperty("bars")]
        public List<Bar> Bars { get; set; }

        [JsonProperty("beats")]
        public List<Beat> Beats { get; set; }

        [JsonProperty("tatums")]
        public List<Tatum> Tatums { get; set; }

        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }

        [JsonProperty("segments")]
        public List<Segment> Segments { get; set; }
    }
}