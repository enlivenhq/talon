using Talon.Web.Helpers;
using Talon.Web.Views;

namespace Talon.Web.Presenters
{
    public class DefaultPresenter : BasePresenter
    {
        protected IDefaultView View { get; set; }

        public DefaultPresenter(IDefaultView view)
        {
            View = view;
        }

        public void Initialize()
        {
            AccountHelper.RequireLogin();
        }
    }
}