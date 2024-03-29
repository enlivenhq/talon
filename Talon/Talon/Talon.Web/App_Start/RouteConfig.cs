using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

// ReSharper disable once CheckNamespace
namespace Talon.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);
        }
    }
}
