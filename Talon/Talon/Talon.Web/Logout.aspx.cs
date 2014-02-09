using System;
using Talon.Web.Presenters;
using Talon.Web.Views;

namespace Talon.Web
{
    public partial class Logout : System.Web.UI.Page, ILogoutView
    {
        protected LogoutPresenter Presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter = new LogoutPresenter(this);
            Presenter.Logout();
            Response.Redirect("/", false);
        }
    }
}