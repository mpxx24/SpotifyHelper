using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class RecommendationsService : IRecommendationsService {
        private readonly IRequestHelper requestHelper;

        public RecommendationsService(IRequestHelper requestHelper) {
            this.requestHelper = requestHelper;
        }

        public IEnumerable<Track> GetTracksReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAlbumsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetArtistsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            throw new NotImplementedException();
        }

        public IEnumerable<Track> GetTracksReccomendationsBasenOnCustomCriteria(IParameters parameters) {
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