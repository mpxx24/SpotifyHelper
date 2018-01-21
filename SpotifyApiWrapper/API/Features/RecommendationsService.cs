using System;
using System.Collections.Generic;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class RecommendationsService : IRecommendationsService {
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
            throw new NotImplementedException();
        }
    }
}