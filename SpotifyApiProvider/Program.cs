using Autofac;
using SpotifyApiProvider.API;
using SpotifyApiProvider.Core;
using static System.Console;

namespace SpotifyApiProvider {
    internal class Program {
        private static void Main() {
            IoC.Initialize(new Module[] {new ApiProviderModule()});

            var playlistService = IoC.Resolve<IPlaylistService>();

            var playlists = playlistService.GetUserPlaylists("mpxx24");

            foreach (var playlist in playlists.items) {
                WriteLine(playlist.name);
            }

            //playlistService.CreatePlaylistForUser(rh, playlistService, t2.access_token, "mpxx24");

            ReadLine();
        }
    }
}