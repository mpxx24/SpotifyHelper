using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Helpers;
using SpotifyApiWrapper.API.Helpers.Recommendations;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Features {
    internal class RecommendationsService : IRecommendationsService {
        private readonly IAudioAnalysisService audioAnalysisService;
        private readonly IRequestHelper requestHelper;
        private readonly ITrackService trackService;

        public RecommendationsService(IRequestHelper requestHelper, IAudioAnalysisService audioAnalysisService, ITrackService trackService) {
            this.requestHelper = requestHelper;
            this.audioAnalysisService = audioAnalysisService;
            this.trackService = trackService;
        }

        public IEnumerable<Track> GetTracksReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            var tracksAsJson = requestHelper.GetData(ApiAdresses.Reccomendations,
                                                     new RecommendationsParameters(new List<RecommendationsGenre>()) {
                                                         Tracks = new List<string> {trackId},
                                                         Limit = limit.ToString()
                                                     });
            return GetTracksFromJson(tracksAsJson);
        }

        public IEnumerable<Album> GetAlbumsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            var tracksAsJson = requestHelper.GetData(ApiAdresses.Reccomendations,
                                                     new RecommendationsParameters(new List<RecommendationsGenre>()) {
                                                         Tracks = new List<string> {trackId},
                                                         Limit = limit.ToString()
                                                     });
            var tracks = GetTracksFromJson(tracksAsJson);
            return tracks.Select(x => x.Album).Distinct();
        }

        public IEnumerable<Artist> GetArtistsReccomendationsBasedOnTrack(string trackId, int limit = 10) {
            var tracksAsJson = requestHelper.GetData(ApiAdresses.Reccomendations,
                                                     new RecommendationsParameters(new List<RecommendationsGenre>()) {
                                                         Tracks = new List<string> {trackId},
                                                         Limit = limit.ToString()
                                                     });
            var tracks = GetTracksFromJson(tracksAsJson);
            return tracks.SelectMany(x => x.Artists).Distinct();
        }

        public IEnumerable<Track> GetTracksReccomendationsBasedOnCustomCriteria(IParameters parameters, int limit = 10) {
            if (parameters is RecommendationsParameters recommendationsParameters) {
                recommendationsParameters.Limit = recommendationsParameters.Limit ?? (recommendationsParameters.Limit = limit.ToString());
            }

            var tracksAsJson = requestHelper.GetData(ApiAdresses.Reccomendations, parameters);
            return GetTracksFromJson(tracksAsJson);
        }

        //TODO: better name for 'margin'
        public IEnumerable<Track> GetCustomTracksReccomendationsBasedOnTrack(string trackId, int margin, int limit = 10) {
            if (margin <= 0 || margin > 100) {
                throw new InvalidOperationException("Margin must be set in range from 1 to 100.");
            }

            var criteria = this.GetCustomCriteriaBasedOnTrack(trackId, margin);
            return GetTracksReccomendationsBasedOnCustomCriteria(criteria, limit);
        }

        private IParameters GetCustomCriteriaBasedOnTrack(string trackId, int margin) {
            var features = audioAnalysisService.GetTrackFeatures(trackId);
            var artist = trackService.GetArtistBasedOnTrack(trackId);

            return TranslateTrackFeaturesToRecommendationsParameters(features, artist.Genres, margin);
        }

        private static RecommendationsParameters TranslateTrackFeaturesToRecommendationsParameters(TrackFeatures features, IEnumerable<string> genres, int margin) {
            return new RecommendationsParameters(genres.Select(GenresHelper.GetGenreByApiName)) {
                MinAcousticness = GetValueFixedByMarginAsString(features.Acousticness, margin, MinMaxProperty.Min),
                MaxAcousticness = GetValueFixedByMarginAsString(features.Acousticness, margin, MinMaxProperty.Max),
                MinDanceability = GetValueFixedByMarginAsString(features.Danceability, margin, MinMaxProperty.Min),
                MaxDanceability = GetValueFixedByMarginAsString(features.Danceability, margin, MinMaxProperty.Max),
                MinEnergy = GetValueFixedByMarginAsString(features.Energy, margin, MinMaxProperty.Min),
                MaxEnergy = GetValueFixedByMarginAsString(features.Energy, margin, MinMaxProperty.Max),
                MinInstrumentalness = GetValueFixedByMarginAsString(features.Instrumentalness, margin, MinMaxProperty.Min),
                MaxInstrumentalness = GetValueFixedByMarginAsString(features.Instrumentalness, margin, MinMaxProperty.Max),
                MinLivenes = GetValueFixedByMarginAsString(features.Liveness, margin, MinMaxProperty.Min),
                MaxLiveness = GetValueFixedByMarginAsString(features.Liveness, margin, MinMaxProperty.Max),
                MinLoudness = GetValueFixedByMarginAsString(features.Loudness, margin, MinMaxProperty.Min),
                MaxLoudness = GetValueFixedByMarginAsString(features.Loudness, margin, MinMaxProperty.Max),
                MinSpeechiness = GetValueFixedByMarginAsString(features.Speechiness, margin, MinMaxProperty.Min),
                MaxSpeechiness = GetValueFixedByMarginAsString(features.Speechiness, margin, MinMaxProperty.Max),
                MinTempo = GetValueFixedByMarginAsString(features.Tempo, margin, MinMaxProperty.Min),
                MaxTempo = GetValueFixedByMarginAsString(features.Tempo, margin, MinMaxProperty.Max),
                MinValence = GetValueFixedByMarginAsString(features.Valence, margin, MinMaxProperty.Min),
                MaxValance = GetValueFixedByMarginAsString(features.Valence, margin, MinMaxProperty.Max)
            };
        }

        private static string GetValueFixedByMarginAsString(double propValue, int margin, MinMaxProperty minMax) {
            var difference = (float)margin / 100;

            var resultAsDouble = minMax == MinMaxProperty.Min
                ? propValue - difference * propValue
                : propValue + difference * propValue;

            return Math.Round(resultAsDouble, 6).ToString(CultureInfo.InvariantCulture);
        }

        private IEnumerable<Track> GetTracksFromJson(string jsonString) {
            try {
                return JsonConvert.DeserializeObject<ReccomendationTracksRoot>(jsonString)?.Tracks;
            }
            catch (JsonSerializationException ex) {
                //TODO: log and handle
                throw;
            }
        }

        private enum MinMaxProperty {
            Min,
            Max
        }
    }
}