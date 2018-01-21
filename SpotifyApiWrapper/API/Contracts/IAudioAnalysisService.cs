using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Contracts {
    internal interface IAudioAnalysisService {
        TrackFeatures GetTrackFeatures(string trackId);
        AudioAnalysis GetTrackAudioAnalysis(string trackId);
    }
}