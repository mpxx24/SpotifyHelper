using System.Collections.Generic;
using Autofac;
using SpotifyApiProvider.API;
using SpotifyApiProvider.API.Models;
using SpotifyApiProvider.Core;
using static System.Console;

namespace SpotifyApiProvider {
    internal class Program {
        private static void Main() {
            IoC.Initialize(new Module[] {new ApiProviderModule()});

            var playlistService = IoC.Resolve<IPlaylistService>();

            //var playlists = playlistService.GetUserPlaylists("mpxx24");

            //foreach (var playlist in playlists.items) {
            //    WriteLine(playlist.name);
            //}

            var authorize = IoC.Resolve<IRequestHelper>().GetData(ApiAdresses.Authorization, new Dictionary<string, string>());

            playlistService.CreatePlaylistForUser("mpxx24", "name = created by api, public = true");

            ReadLine();
        }
    }
}