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

            //TODO: check ifthere is another way to pass params via ctor 
            builder.RegisterType<RequestHelper>().As<IRequestHelper>()
                .WithParameters(new List<Parameter> {new NamedParameter("clientId", clientId), new NamedParameter("clientSecretId", secretId)});
            builder.RegisterType<AuthorizationCodeService>().As<IAuthorizationCodeService>()
                .WithParameters(new List<Parameter> {new NamedParameter("clientId", clientId), new NamedParameter("clientSecretId", secretId)});
            builder.RegisterType<PlaylistService>().As<IPlaylistService>();
        }
    }
}