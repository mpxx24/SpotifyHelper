using System;
using System.Globalization;
using SpotifyApiWrapper.API.Helpers.Recommendations;

namespace SpotifyApiWrapper.API.Helpers {
    internal static class GenresHelper {
        public static RecommendationsGenre GetGenreByApiName(string name) {
            var realName = name.Replace(" ", string.Empty).Replace("-", "_");
            realName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(realName);

            return (RecommendationsGenre) Enum.Parse(typeof(RecommendationsGenre), realName);
        }
    }
}