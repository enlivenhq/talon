using System;
using Talon.Data.Components;
using Talon.Web.Views;

namespace Talon.Web.Presenters
{
    public class LoginPresenter
    {
        public ILoginView View { get; set; }

        public LoginPresenter(ILoginView view)
        {
            View = view;
        }

        public async void AttemptLogin()
        {
            try
            {
                var auth = 
                    await AuthenticationComponent.GetAuthenticationClient(View.Username, View.Password);

                var formattedQueryString =
                    string.Format("?apiVersion={0}&instanceUrl={1}&accessToken={2}",
                        auth.ApiVersion, auth.InstanceUrl, auth.AccessToken);

                View.AuthenticationFailureErrorVisible = false;
                View.RedirectToLoginHandler(formattedQueryString);
            }

            catch (Exception)
            {
                View.AuthenticationFailureErrorVisible = true;
            }
        }
    }
}