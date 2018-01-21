using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using SpotifyApiWrapper.API.Models;

namespace SpotifyApiWrapper.API.Authorization {
    internal class AuthorizationCodeService : IAuthorizationCodeService {
        private readonly string clientId;
        private readonly string clientSecretId;

        public AuthorizationCodeService(string clientId, string clientSecretId) {
            this.clientId = clientId;
            this.clientSecretId = clientSecretId;
        }

        public Token GetToken() {
            var webClient = new WebClient();

            var postparams = new NameValueCollection {{"grant_type", "client_credentials"}};

            var authHeader = this.GetAuthKey();
            webClient.Headers.Add(HttpRequestHeader.Authorization, "Basic " + authHeader);

            var tokenResponse = webClient.UploadValues(ApiAdresses.Token, postparams);

            var textResponse = Encoding.UTF8.GetString(tokenResponse);
            return JsonConvert.DeserializeObject<Token>(textResponse);
        }

        public string GetAuthKey() {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes($"{this.clientId}:{this.clientSecretId}"));
        }
    }
}