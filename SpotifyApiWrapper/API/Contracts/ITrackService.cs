using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Contracts {
    internal interface ITrackService {
        Artist GetArtistBasedOnTrack(string trackId);
    }
}