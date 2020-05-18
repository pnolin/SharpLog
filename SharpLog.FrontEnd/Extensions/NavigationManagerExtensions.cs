using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace SharpLog.FrontEnd.Extensions
{
    public static class NavigationManagerExtensions
    {
        public static bool TryGetQueryString(this NavigationManager navigationManager, string key, out string? value)
        {
            var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
            StringValues parseQueryResult;
            var query = QueryHelpers.ParseQuery(uri.Query);
            var parseQuerySuccess = query.TryGetValue(key, out parseQueryResult);

            if (parseQuerySuccess)
            {
                value = parseQueryResult.ToString();

                return true;
            }

            value = null;

            return false;
        }

        public static bool TryGetQueryString(this NavigationManager navigationManager, string key, out int? value)
        {
            var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
            StringValues parseQueryResult;
            var query = QueryHelpers.ParseQuery(uri.Query);
            var parseQuerySuccess = query.TryGetValue(key, out parseQueryResult);

            if (parseQuerySuccess)
            {
                int parseIntResult;
                var parseIntSuccess = int.TryParse(parseQueryResult, out parseIntResult);

                if (parseIntSuccess)
                {
                    value = parseIntResult;

                    return true;
                }
            }

            value = null;

            return false;
        }
    }
}