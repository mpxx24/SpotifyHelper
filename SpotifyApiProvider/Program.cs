using System;
using System.Linq;
using Autofac;
using SpotifyApiProvider.API;
using SpotifyApiProvider.API.Authorization;
using SpotifyApiProvider.API.Models;
using SpotifyApiProvider.Core;

namespace SpotifyApiProvider {
    internal class Program {
        private static void Main() {
            IoC.Initialize(new Module[] {new ApiProviderModule()});

            var acs = IoC.Resolve<IAuthorizationCodeService>();
            var rh = IoC.Resolve<IRequestHelper>();
            var playlistService = IoC.Resolve<IPlaylistService>();

            var t2 = acs.GetToken();
            var playlists = rh.GetData(string.Format(ApiAdresses.User, "mpxx24"), t2.access_token);
            var p = playlistService.GetPlaylistFromJson(playlists);

            foreach (var pItem in p.items) {
                Console.WriteLine(pItem.name);
                try {
                    var playlistTracks = rh.GetData(string.Format(ApiAdresses.TracksFromPlaylist, "mpxx24", pItem.id), t2.access_token);
                    var ohTracks = playlistService.GetTracksFromJson(playlistTracks);
                    foreach (var item in ohTracks.items) {
                        Console.WriteLine($"\t{string.Join("&", item.track.artists.Select(x => x.name))} - {item.track.name}");
                    }
                }
                catch (Exception) {
                    continue;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}