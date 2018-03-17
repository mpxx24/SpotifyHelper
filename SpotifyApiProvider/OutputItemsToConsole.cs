using System.Collections.Generic;
using System.Linq;
using SpotifyApiWrapper.API.Models;
using static System.Console;

namespace SpotifyApiWrapperTester {
    public static class OutputItemsToConsole {
        public static void PrintRecommendedTracks(IEnumerable<Track> tracks) {
            var i = 1;

            WriteLine("Recommended tracks:");
            foreach (var track in tracks) {
                WriteLine($"\t{i}. {string.Join("&", track.artists.Select(x => x.name))} - {track.name}");
                i++;
            }
        }

        public static void PrintRecommendedAlbums(IEnumerable<Album> albums) {
            var i = 1;

            WriteLine("Recommended albums:");
            foreach (var album in albums) {
                WriteLine($"\t{i}. {string.Join("&", album.artists.Select(x => x.name))} - {album.name}");
                i++;
            }
        }

        public static void PrintRecommendedArtists(IEnumerable<Artist> artists) {
            var i = 1;

            WriteLine("Recommended artists:");
            foreach (var artist in artists) {
                WriteLine($"\t{i}. {artist.name}");
                i++;
            }
        }
    }
}