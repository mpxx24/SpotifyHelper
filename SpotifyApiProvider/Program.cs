using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using SpotifyApiWrapper.API.Helpers.Recommendations;
using SpotifyApiWrapper.API.Wrappers;
using SpotifyApiWrapper.Core;
using static System.Console;

namespace SpotifyApiWrapperTester {
    internal class Program {
        private static void Main() {
            try {
                var clientId = ConfigurationManager.AppSettings["clientId"];
                var secretId = ConfigurationManager.AppSettings["secretId"];

                SpotifyApiWrapperInitializer.Initialize(clientId, secretId);

                //DisplayUserPlaylists("mpxx24");

                var features = AudioAnalysisWrapper.GetTrackFeatures("0aAvVcHH0eN1fnKUkPcZ0y");
                //var analisys = AudioAnalysisWrapper.GetTrackAudioAnalysis("0aAvVcHH0eN1fnKUkPcZ0y");

                var criteria = new RecommendationsParameters {MinDanceability = features.danceability.ToString(CultureInfo.InvariantCulture), MinEnergy = features.energy.ToString(CultureInfo.InvariantCulture), Tracks = new List<string>(){features.id}};
                var tracks = RecommendationsWrapper.GetTracksReccomendationsBasenOnCustomCriteria(criteria);
                foreach (var track in tracks) {
                    WriteLine($"{string.Join("&", track.artists.Select(x => x.name))} - {track.name}");
                }
                
            }
            catch (Exception ex) {
                WriteLine($"exception type: {ex.GetType()}\nexception message: {ex.Message}");
            }
            ReadLine();
        }

        private static void DisplayUserPlaylists(string username) {
            var playlists = PlaylistsWrapper.GetUsersPlaylists(username);
            foreach (var playlist in playlists) {
                WriteLine(playlist.name);
                var songs = PlaylistsWrapper.GetSongsFromPlaylist(username, playlist.id);
                foreach (var song in songs) {
                    WriteLine($"\t{string.Join("&", song.artists.Select(x => x.name))} - {song.name}");
                }
            }
        }
    }
}