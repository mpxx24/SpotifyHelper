using System;

namespace SpotifyApiWrapper.Core.Exceptions {
    public class WrapperInitializationException : Exception {
        public WrapperInitializationException() {
        }

        public WrapperInitializationException(string message) : base(message) {
        }
    }
}