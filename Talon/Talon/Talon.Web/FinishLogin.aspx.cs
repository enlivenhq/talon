using System;
using Talon.Web.Helpers;

namespace Talon.Web
{
    public partial class FinishLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var apiVersion = Request["apiVersion"];
            var instanceUrl = Request["instanceUrl"];
            var accessToken = Request["accessToken"];

            AccountHelper.ApiVersion = apiVersion;
            AccountHelper.InstanceUrl = instanceUrl;
            AccountHelper.AccessToken = accessToken;

            Response.Redirect("/", false);
        }
    }
}