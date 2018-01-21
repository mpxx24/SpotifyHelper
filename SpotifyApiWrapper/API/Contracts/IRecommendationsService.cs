using System.Collections.Generic;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Contracts {
    internal interface IRecommendationsService {
        IEnumerable<Track> GetTracksReccomendationsBasedOnTrack(string trackId, int limit = 10);
        IEnumerable<Album> GetAlbumsReccomendationsBasedOnTrack(string trackId, int limit = 10);
        IEnumerable<Artist> GetArtistsReccomendationsBasedOnTrack(string trackId, int limit = 10);
        IEnumerable<Track> GetTracksReccomendationsBasenOnCustomCriteria(IParameters parameters);
    }
}