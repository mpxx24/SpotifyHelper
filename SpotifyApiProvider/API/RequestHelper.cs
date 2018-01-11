using System;
using System.IO;
using System.Net;
using System.Text;
using SpotifyApiProvider.API.Models;

namespace SpotifyApiProvider.API {
    public class RequestHelper : IRequestHelper {
        private readonly string token;

        public RequestHelper(string token) {
            this.token = token;
        }

        //TODO: split into GET/POST? or just make a bunch of ifs
        public string PerformRequest(string address, RequestType requestType = RequestType.GET, string parameters = null) {
            var request = (HttpWebRequest) WebRequest.Create(address);
            request.Method = this.GetRequestTypeAsString(requestType);
            request.ContentType = "application/json";
            request.Headers.Add($"Authorization: Bearer {this.token}");

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

        private string GetRequestTypeAsString(RequestType requestType) {
            return Enum.GetName(typeof(RequestType), requestType);
        }
    }
}