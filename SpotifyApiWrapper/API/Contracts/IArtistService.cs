using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Contracts {
    internal interface IArtistService {
        Artist GetArtist(string id);
    }
}