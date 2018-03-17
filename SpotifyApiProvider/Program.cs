using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using SpotifyApiWrapper.API.Helpers;
using SpotifyApiWrapper.API.Helpers.Recommendations;
using SpotifyApiWrapper.API.Models;
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
                var testTrackId = "0aAvVcHH0eN1fnKUkPcZ0y";

                //
                //DisplayUserPlaylists("mpxx24");
                //DisplayRecommendedTracks(testTrackId, features);
                //DisplayRecommendedAlbums(testTrackId);
                //DisplayRecommendedArtists(testTrackId);
                //

                //var features = AudioAnalysisWrapper.GetTrackFeatures(testTrackId);
                //var analisys = AudioAnalysisWrapper.GetTrackAudioAnalysis(testTrackId);
            }
            catch (Exception ex) {
                WriteLine($"exception type: {ex.GetType()}\nexception message: {ex.Message}");
            }
            ReadLine();
        }

        private static void DisplayRecommendedArtists(string testTrackId) {
            var artists = RecommendationsWrapper.GetArtistsReccomendationsBasedOnTrack(testTrackId);
            OutputItemsToConsole.PrintRecommendedArtists(artists);
        }

        private static void DisplayRecommendedTracks(string testTrackId) {
            var features = AudioAnalysisWrapper.GetTrackFeatures(testTrackId);
            var genres = new List<RecommendationsGenre> {RecommendationsGenre.Rock};

            var criteria = new RecommendationsParameters(genres) {
                Tracks = new List<string> {testTrackId},
                MinDanceability = features.danceability.ToString(CultureInfo.InvariantCulture),
                MinEnergy = features.energy.ToString(CultureInfo.InvariantCulture),
                MinTempo = features.tempo.ToString(CultureInfo.InvariantCulture)
            };

            var tracks = RecommendationsWrapper.GetTracksReccomendationsBasedOnCustomCriteria(criteria);
            WriteLine(criteria);
            OutputItemsToConsole.PrintRecommendedTracks(tracks);
        }

        private static void DisplayRecommendedAlbums(string testTrackId) {
            var albums = RecommendationsWrapper.GetAlbumsReccomendationsBasedOnTrack(testTrackId);
            OutputItemsToConsole.PrintRecommendedAlbums(albums);
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

        private static void CreateObjectWithPropertiesFromString() {
            var properties = "acoustic, afrobeat, alt - rock, alternative, ambient, anime, black - metal, bluegrass, blues, bossanova, brazil, breakbeat, british, cantopop, chicago - house, children, chill, classical, club, comedy, country, dance, dancehall, death - metal, deep - house, detroit - techno, disco, disney, drum - and - bass, dub, dubstep, edm, electro, electronic, emo, folk, forro, french, funk, garage, german, gospel, goth, grindcore, groove, grunge, guitar, happy, hard - rock, hardcore, hardstyle, heavy - metal, hip - hop, holidays, honky - tonk, house, idm, indian, indie, indie - pop, industrial, iranian, j - dance, j - idol, j - pop, j - rock, jazz, k - pop, kids, latin, latino, malay, mandopop, metal, metal - misc, metalcore, minimal - techno, movies, mpb, new- age, new- release, opera, pagode, party, philippines - opm, piano, pop, pop - film, post - dubstep, power - pop, progressive - house, psych - rock, punk, punk - rock, r - n - b, rainy - day, reggae, reggaeton, road - trip, rock, rock - n - roll, rockabilly, romance, sad, salsa, samba, sertanejo, show - tunes, singer - songwriter, ska, sleep, songwriter, soul, soundtracks, spanish, study, summer, swedish, synth - pop, tango, techno, trance, trip - hop, turkish, work -out , world - music".Split(',').ToList();
            IDictionary<string, string> propsAsDict = new Dictionary<string, string>();

            foreach (var property in properties) {
                var propName = property.Replace(" ", string.Empty).Replace("-", "_");
                propName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(propName);
                propsAsDict.Add(propName, "string");
            }

            var objectFromStringHelper = ObjectFromStringListHelper.CreateObject("enum", "RecommendationsGenre", propsAsDict);
        }
    }
}