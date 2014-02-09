using Talon.Web.Helpers;
using Talon.Web.Views;

namespace Talon.Web.Presenters
{
    public class LogoutPresenter
    {
        protected ILogoutView View;

        public LogoutPresenter(ILogoutView view)
        {
            View = view;
        }

        public void Logout()
        {
            AccountHelper.AccessToken = null;
            AccountHelper.ApiVersion = null;
            AccountHelper.InstanceUrl = null;
        }
    }
}