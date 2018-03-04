using System;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class AudioAnalysisService : IAudioAnalysisService {
        private readonly IRequestHelper requestHelper;

        public AudioAnalysisService(IRequestHelper requestHelper) {
            this.requestHelper = requestHelper;
        }

        public TrackFeatures GetTrackFeatures(string trackId) {
            try {
                var trackFeatures = this.requestHelper.GetData(string.Format(ApiAdresses.AudioFeatures, trackId));
                return JsonConvert.DeserializeObject<TrackFeatures>(trackFeatures);
            }
            catch (Exception ex) {
                //TODO: log
                throw;
            }
        }

        public AudioAnalysis GetTrackAudioAnalysis(string trackId) {
            try {
                var audioAnalysis = this.requestHelper.GetData(string.Format(ApiAdresses.AudioAnalysis, trackId));
                return JsonConvert.DeserializeObject<AudioAnalysis>(audioAnalysis);
            }
            catch (Exception ex) {
                //TODO: log
                throw;
            }
        }
    }
}