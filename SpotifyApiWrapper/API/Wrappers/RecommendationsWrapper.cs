using System.Collections.Generic;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;
using SpotifyApiWrapper.Core;

namespace SpotifyApiWrapper.API.Wrappers {
    public static class RecommendationsWrapper {
        public static IEnumerable<Track> GetTracksReccomendationsBasedOnCustomCriteria(IParameters parameters) {
            return IoC.Resolve<IRecommendationsService>().GetTracksReccomendationsBasenOnCustomCriteria(parameters);
        }
    }
}