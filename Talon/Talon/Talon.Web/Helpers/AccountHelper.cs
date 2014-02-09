using System.Web;
using Salesforce.Force;

namespace Talon.Web.Helpers
{
    public class AccountHelper
    {
        public static string AccessToken
        {
            get { return (string) HttpContext.Current.Session["AccessToken"]; }
            set { HttpContext.Current.Session["AccessToken"] = value; }
        }

        public static string ApiVersion
        {
            get { return (string) HttpContext.Current.Session["ApiVersion"]; }
            set { HttpContext.Current.Session["ApiVersion"] = value; }
        }

        public static string InstanceUrl
        {
            get { return (string) HttpContext.Current.Session["InstanceUrl"]; }
            set { HttpContext.Current.Session["InstanceUrl"] = value; }
        }

        public static bool LoggedIn
        {
            get { return AccessToken != null; }
        }

        public static ForceClient Client
        {
            get { return new ForceClient(InstanceUrl, AccessToken, ApiVersion); }
        }

        public static void RequireLogin()
        {
            if (!LoggedIn) HttpContext.Current.Response.Redirect("/Login.aspx", false);
        }
    }
}