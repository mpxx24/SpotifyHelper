using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class ArtistService : IArtistService {
        private readonly IRequestHelper requestHelper;

        public ArtistService(IRequestHelper requestHelper) {
            this.requestHelper = requestHelper;
        }

        public Artist GetArtist(string id) {
            var artistAsJson = requestHelper.GetData(string.Format(ApiAdresses.Artist, id));
            var artist = GetArtistFromJson(artistAsJson);
            return artist;
        }

        private Artist GetArtistFromJson(string artistAsJson) {
            try {
                return JsonConvert.DeserializeObject<Artist>(artistAsJson);
            }
            catch (JsonSerializationException e) {
                throw;
            }
        }
    }
}