using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;

namespace SpotifyApiWrapper.API.Helpers.Recommendations {
    public class RecommendationsParameters : IParameters {
        private RecommendationsParameters() {
        }

        public RecommendationsParameters(IEnumerable<RecommendationsGenre> genres) {
            var formattedGenres = this.FormatGenres(genres.Select(x => x.ToString()));
            this.Genres = formattedGenres;
        }

        [JsonProperty("target_mode")]
        public string TargetMode { get; set; }

        [JsonProperty("min_energy")]
        public string MinEnergy { get; set; }

        [JsonProperty("max_mode")]
        public string MaxMode { get; set; }

        [JsonProperty("min_tempo")]
        public string MinTempo { get; set; }

        [JsonProperty("min_acousticness")]
        public string MinAcousticness { get; set; }

        [JsonProperty("target_duration_ms")]
        public string TargetDuration { get; set; }

        [JsonProperty("min_danceability")]
        public string MinDanceability { get; set; }

        [JsonProperty("seed_tracks")]
        public IEnumerable<string> Tracks { get; set; }

        [JsonProperty("target_liveness")]
        public string TargetLiveness { get; set; }

        [JsonProperty("target_acousticness")]
        public string TargetAcousticness { get; set; }

        [JsonProperty("seed_artists")]
        public IEnumerable<string> Artists { get; set; }

        [JsonProperty("min_duration_ms")]
        public string MinDuration { get; set; }

        [JsonProperty("max_popularity")]
        public string MaxPopularity { get; set; }

        [JsonProperty("max_duration_ms")]
        public string MaxDuration { get; set; }

        [JsonProperty("seed_genres")]
        public IEnumerable<string> Genres { get; set; }

        [JsonProperty("target_key")]
        public string TargetKey { get; set; }

        [JsonProperty("max_valence")]
        public string MaxValance { get; set; }

        [JsonProperty("limit")]
        public string Limit { get; set; }

        [JsonProperty("max_energy")]
        public string MaxEnergy { get; set; }

        [JsonProperty("target_loudness")]
        public string TargetLaudness { get; set; }

        [JsonProperty("max_tempo")]
        public string MaxTempo { get; set; }

        [JsonProperty("max_danceability")]
        public string MaxDanceability { get; set; }

        [JsonProperty("max_instrumentalness")]
        public string MaxInstrumentalness { get; set; }

        [JsonProperty("target_tempo")]
        public string TargetTempo { get; set; }

        [JsonProperty("target_speechiness")]
        public string TargetSpeechiness { get; set; }

        [JsonProperty("min_popularity")]
        public string MinPopularity { get; set; }

        [JsonProperty("target_instrumentalness")]
        public string TargetInstrumentalness { get; set; }

        [JsonProperty("target_valence")]
        public string TargetValence { get; set; }

        [JsonProperty("min_instrumentalness")]
        public string MinInstrumentalness { get; set; }

        [JsonProperty("max_liveness")]
        public string MaxLiveness { get; set; }

        [JsonProperty("min_mode")]
        public string MinMode { get; set; }

        [JsonProperty("max_speechiness")]
        public string MaxSpeechiness { get; set; }

        [JsonProperty("max_time_signature")]
        public string MaxTimeSignature { get; set; }

        [JsonProperty("min_time_signature")]
        public string MinTimeSignature { get; set; }

        [JsonProperty("target_popularity")]
        public string TargetPopularity { get; set; }

        [JsonProperty("min_key")]
        public string MinKey { get; set; }

        [JsonProperty("max_key")]
        public string MaxKey { get; set; }

        [JsonProperty("min_speechiness")]
        public string MinSpeechiness { get; set; }

        [JsonProperty("max_acousticness")]
        public string MaxAcousticness { get; set; }

        [JsonProperty("target_energy")]
        public string TargetEnergy { get; set; }

        [JsonProperty("max_loudness")]
        public string MaxLaudeness { get; set; }

        [JsonProperty("min_valence")]
        public string MinValence { get; set; }

        [JsonProperty("min_liveness")]
        public string MinLivenes { get; set; }

        [JsonProperty("target_time_signature")]
        public string TargetTimeSignature { get; set; }

        [JsonProperty("target_danceability")]
        public string TargetDanceability { get; set; }

        [JsonProperty("min_loudness")]
        public string MinLaudeness { get; set; }

        public override string ToString() {
            var asJson = JsonConvert.SerializeObject(this, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
            var sb = new StringBuilder();

            sb.AppendLine(nameof(RecommendationsParameters));

            foreach (var s in asJson.Split(',')) {
                sb.AppendLine($"\t{s}");
            }

            sb.AppendLine();

            return sb.ToString();
        }

        private IEnumerable<string> FormatGenres(IEnumerable<string> genres) {
            return genres.Select(x => x.ToLowerInvariant().Replace("_", "-")).ToList();
        }
    }
}