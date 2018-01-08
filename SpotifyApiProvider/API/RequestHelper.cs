using System;
using System.IO;
using System.Net;
using System.Text;

namespace SpotifyApiProvider.API {
    public class RequestHelper : IRequestHelper {
        protected string clientId;
        protected string clientSecretId;

        public RequestHelper(string clientId, string clientSecretId) {
            this.clientId = clientId;
            this.clientSecretId = clientSecretId;
        }
        
        public string GetData(string address, string token = null) {
            //TODO: use WebClient???
            var request = (HttpWebRequest) WebRequest.Create(address);
            request.Method = "GET";
            request.ContentType = "application/json";
            if (token != null) {
                request.Headers.Add($"Authorization: Bearer {token}");
            }

            try {
                var response = request.GetResponse();
                using (var responseStream = response.GetResponseStream()) {
                    if (responseStream != null) {
                        var reader = new StreamReader(responseStream, Encoding.UTF8);
                        var result = reader.ReadToEnd();
                        return result;
                    }
                    return string.Empty;
                }
            }
            catch (WebException ex) {
                var errorResponse = ex.Response;
                using (var responseStream = errorResponse.GetResponseStream()) {
                    if (responseStream != null) {
                        var reader = new StreamReader(responseStream, Encoding.UTF8);
                        var errorText = reader.ReadToEnd();
                        //TODO: log
                    }
                    return string.Empty;
                }
            }
            catch (Exception e) {
                //TODO: log
                throw;
            }
        }
    }
}