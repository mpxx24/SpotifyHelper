using System.Collections.Generic;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;
using SpotifyApiWrapper.Core;

namespace SpotifyApiWrapper.API.Wrappers {
    public static class RecommendationsWrapper {
        public static IEnumerable<Track> GetTracksReccomendationsBasedOnCustomCriteria(IParameters parameters) {
            return IoC.Resolve<IRecommendationsService>().GetTracksReccomendationsBasedOnCustomCriteria(parameters);
        }

        public static IEnumerable<Track> GetTracksReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            return IoC.Resolve<IRecommendationsService>().GetTracksReccomendationsBasedOnTrack(trackId, limit);
        }

        public static IEnumerable<Album> GetAlbumsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            return IoC.Resolve<IRecommendationsService>().GetAlbumsReccomendationsBasedOnTrack(trackId, limit);
        }

        public static IEnumerable<Artist> GetArtistsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            return IoC.Resolve<IRecommendationsService>().GetArtistsReccomendationsBasedOnTrack(trackId, limit);
        }
    }
}