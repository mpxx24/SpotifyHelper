using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Helpers.Recommendations;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class RecommendationsService : IRecommendationsService {
        private readonly IRequestHelper requestHelper;

        public RecommendationsService(IRequestHelper requestHelper) {
            this.requestHelper = requestHelper;
        }

        public IEnumerable<Track> GetTracksReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            var tracksAsJson = this.requestHelper.GetData(ApiAdresses.Reccomendations, new RecommendationsParameters(new List<RecommendationsGenre>()) {Tracks = new List<string> {trackId}, Limit = limit.ToString()});
            return this.GetTracksFromJson(tracksAsJson);
        }

        public IEnumerable<Album> GetAlbumsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            var tracksAsJson = this.requestHelper.GetData(ApiAdresses.Reccomendations, new RecommendationsParameters(new List<RecommendationsGenre>()) {Tracks = new List<string> {trackId}, Limit = limit.ToString()});
            var tracks = this.GetTracksFromJson(tracksAsJson);
            return tracks.Select(x => x.album).Distinct();
        }

        public IEnumerable<Artist> GetArtistsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            var tracksAsJson = this.requestHelper.GetData(ApiAdresses.Reccomendations, new RecommendationsParameters(new List<RecommendationsGenre>()) {Tracks = new List<string> {trackId}, Limit = limit.ToString()});
            var tracks = this.GetTracksFromJson(tracksAsJson);
            return tracks.SelectMany(x => x.artists).Distinct();
        }

        public IEnumerable<Track> GetTracksReccomendationsBasedOnCustomCriteria(IParameters parameters, int limit = 10) {
            if (parameters is RecommendationsParameters recommendationsParameters) {
                recommendationsParameters.Limit = recommendationsParameters.Limit ?? (recommendationsParameters.Limit = limit.ToString());
            }

            var tracksAsJson = this.requestHelper.GetData(ApiAdresses.Reccomendations, parameters);
            return this.GetTracksFromJson(tracksAsJson);
        }

        private IEnumerable<Track> GetTracksFromJson(string jsonString) {
            try {
                return JsonConvert.DeserializeObject<ReccomendationTracksRoot>(jsonString)?.tracks;
            }
            catch (JsonSerializationException ex) {
                //TODO: log and handle
                throw;
            }
        }
    }
}