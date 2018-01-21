using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using SpotifyApiWrapper.API.Contracts;

namespace SpotifyApiWrapper.API.Features {
    internal class RequestHelper : IRequestHelper {
        private readonly string token;

        public RequestHelper(string token) {
            this.token = token;
        }

        public string GetData(string address, IParameters parameters = null) {
            if (parameters != null) {
                var addressWithQueryParams = this.CreateQueryStringFromParameters(address, parameters);
                address = addressWithQueryParams;
            }

            var request = (HttpWebRequest) WebRequest.Create(address);
            request.Method = "GET";
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

        //TODO: maybe try to use IParameters
        public string PostData(string address, string parameters) {
            var request = (HttpWebRequest) WebRequest.Create(address);
            var data = Encoding.ASCII.GetBytes(parameters);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add($"Authorization: Bearer {this.token}");
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream()) {
                stream.Write(data, 0, data.Length);
            }

            try {
                var response = (HttpWebResponse) request.GetResponse();
                using (var responseStream = response.GetResponseStream()) {
                    if (responseStream == null) {
                        return string.Empty;
                    }
                    var reader = new StreamReader(responseStream, Encoding.UTF8);
                    var result = reader.ReadToEnd();
                    return result;
                }
            }
            catch (Exception e) {
                //TODO: log
                throw;
            }
        }

        private string CreateQueryStringFromParameters(string address, IParameters parameters) {
            //temp solution only for auth
            using (var content = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("clientId", this.token),
                new KeyValuePair<string, string>("response_type", "code"),
                new KeyValuePair<string, string>("redirect_uri", string.Empty)
            })) {
                var resultContent = content.ReadAsStringAsync().Result;

                return $"{address}/?{resultContent}";
            }
        }
    }
}