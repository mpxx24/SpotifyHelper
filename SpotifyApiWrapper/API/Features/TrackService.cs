using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class TrackService : ITrackService {
        private readonly IArtistService artistService;
        private readonly IRequestHelper requestHelper;

        public TrackService(IRequestHelper requestHelper, IArtistService artistService) {
            this.requestHelper = requestHelper;
            this.artistService = artistService;
        }

        public Artist GetArtistBasedOnTrack(string trackId) {
            var trackAsJson = requestHelper.GetData(string.Format(ApiAdresses.Track, trackId));
            var track = GetTrackFromJson(trackAsJson);
            var artistId = track?.Artists[0]?.Id;
            return artistService.GetArtist(artistId);
        }

        private Track GetTrackFromJson(string trackAsJson) {
            try {
                return JsonConvert.DeserializeObject<Track>(trackAsJson);
            }
            catch (JsonSerializationException e) {
                throw;
            }
        }
    }
}