using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using SpotifyApiWrapper.API.Authorization;
using SpotifyApiWrapper.API.Contracts;
using SpotifyApiWrapper.API.Features;

namespace SpotifyApiWrapper.Core {
    internal class ApiProviderModule : Module {
        private readonly string clientId;
        private readonly string secretId;

        public ApiProviderModule(string clientId, string secretId) {
            this.clientId = clientId;
            this.secretId = secretId;
        }

        protected override void Load(ContainerBuilder builder) {
            //not sure if this is a proper/the best way
            var token = new AuthorizationCodeService(this.clientId, this.secretId).GetToken().access_token;

            builder.RegisterType<AuthorizationCodeService>().As<IAuthorizationCodeService>()
                   .WithParameters(new List<Parameter> {new NamedParameter("clientId", this.clientId), new NamedParameter("clientSecretId", this.secretId)});
            builder.RegisterType<RequestHelper>().As<IRequestHelper>()
                   .WithParameters(new List<Parameter> {new NamedParameter("token", token)});
            builder.RegisterType<PlaylistService>().As<IPlaylistService>();
            builder.RegisterType<AudioAnalysisService>().As<IAudioAnalysisService>();
        }
    }
}