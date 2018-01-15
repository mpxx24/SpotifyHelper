using System.Collections.Generic;
using System.Configuration;
using Autofac;
using Autofac.Core;
using SpotifyApiProvider.API;
using SpotifyApiProvider.API.Authorization;

namespace SpotifyApiProvider.Core {
    public class ApiProviderModule : Module {
        protected override void Load(ContainerBuilder builder) {
            var clientId = ConfigurationManager.AppSettings["clientId"];
            var secretId = ConfigurationManager.AppSettings["secretId"];
            var redirectAddress = ConfigurationManager.AppSettings["redirectAddress"];

            //not sure if this is a proper/the best way
            var token = new AuthorizationCodeService(clientId, secretId).GetToken().access_token;

            builder.RegisterType<AuthorizationCodeService>().As<IAuthorizationCodeService>()
                   .WithParameters(new List<Parameter> {new NamedParameter("clientId", clientId), new NamedParameter("clientSecretId", secretId) });
            builder.RegisterType<RequestHelper>().As<IRequestHelper>()
                   .WithParameters(new List<Parameter> {new NamedParameter("token", token), new NamedParameter("redirectAddress", redirectAddress) });
            builder.RegisterType<PlaylistService>().As<IPlaylistService>();
        }
    }
}