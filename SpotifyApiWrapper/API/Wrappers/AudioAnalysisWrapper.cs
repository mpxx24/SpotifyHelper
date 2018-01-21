using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;
using SpotifyApiWrapper.Core;

namespace SpotifyApiWrapper.API.Wrappers {
    public class AudioAnalysisWrapper {
        public static TrackFeatures GetTrackFeatures(string trackId) {
            return IoC.Resolve<IAudioAnalysisService>().GetTrackFeatures(trackId);
        }

        public static AudioAnalysis GetTrackAudioAnalysis(string trackId) {
            return IoC.Resolve<IAudioAnalysisService>().GetTrackAudioAnalysis(trackId);
        }
    }
}