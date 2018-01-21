using Autofac;

namespace SpotifyApiWrapper.Core {
    public static class SpotifyApiWrapperInitializer {
        public static void Initialize(string clientId, string secretId) {
            if (IsInitialized) {
                return;
            }

            IoC.Initialize(new Module[] {new ApiProviderModule(clientId, secretId)});
            IsInitialized = true;
        }

        internal static bool IsInitialized { get; private set; }
    }
}