using System.Collections.Generic;
using SpotifyApiWrapper.API.Contracts;

namespace SpotifyApiWrapper.API.Helpers.Recommendations {
    public class RecommendationsParameters : IParameters {
        public string TargetMode { get; set; }
        public string MinEnergy { get; set; }
        public string MaxMode { get; set; }
        public string MinTempo { get; set; }
        public string MinAcousticness { get; set; }
        public string TargetDuration { get; set; }
        public string MinDanceability { get; set; }
        public string TrackId { get; set; }
        public string TargetLiveness { get; set; }
        public string TargetAcousticness { get; set; }
        public string ArtistId { get; set; }
        public string MinDuration { get; set; }
        public string MaxPopularity { get; set; }
        public string MaxDuration { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public string TargetKey { get; set; }
        public string MaxValance { get; set; }
        public string Limit { get; set; }
        public string MaxEnergy { get; set; }
        public string TargetLaudness { get; set; }
        public string MaxTempo { get; set; }
        public string MaxDanceability { get; set; }
        public string MaxInstrumentalness { get; set; }
        public string TargetTempo { get; set; }
        public string TargetSpeechiness { get; set; }
        public string MinPopularity { get; set; }
        public string TargetInstrumentalness { get; set; }
        public string TargetValence { get; set; }
        public string MinInstrumentalness { get; set; }
        public string MaxLiveness { get; set; }
        public string MinMode { get; set; }
        public string MaxSpeechiness { get; set; }
        public string MaxTimeSignature { get; set; }
        public string MinTimeSignature { get; set; }
        public string TargetPopularity { get; set; }
        public string MinKey { get; set; }
        public string MaxKey { get; set; }
        public string MinSpeechiness { get; set; }
        public string MaxAcousticness { get; set; }
        public string TargetEnergy { get; set; }
        public string MaxLaudeness { get; set; }
        public string MinValence { get; set; }
        public string MinLivenes { get; set; }
        public string TargetTimeSignature { get; set; }
        public string TargetDanceability { get; set; }
        public string MinLaudeness { get; set; }
    }
}