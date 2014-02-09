using System;
using System.Web.UI;
using Talon.Web.Presenters;
using Talon.Web.Views;

namespace Talon.Web
{
    public partial class Login : Page, ILoginView
    {
        #region Public Properties

        public string Username
        {
            get { return UsernameTextBox.Text; }
            set { UsernameTextBox.Text = value; }
        }

        public string Password
        {
            get { return PasswordTextBox.Text; }
            set { PasswordTextBox.Text = value; }
        }

        public bool AuthenticationFailureErrorVisible
        {
            get { return ErrorMessageDiv.Visible; }
            set { ErrorMessageDiv.Visible = value; }
        }

        #endregion

        #region Protected Properties

        protected LoginPresenter Presenter;

        #endregion

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            Presenter = new LoginPresenter(this);
        }

        protected void AttemptLogin(object sender, EventArgs e)
        {
            Presenter.AttemptLogin();
        }

        #endregion

        #region Public Methods

        public void RedirectToLoginHandler(string formattedQueryString)
        {
            Response.Redirect("/FinishLogin.aspx" + formattedQueryString, false);
        }

        #endregion
    }
}