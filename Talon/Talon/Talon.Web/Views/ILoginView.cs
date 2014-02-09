namespace Talon.Web.Views
{
    public interface ILoginView
    {
        string Username { get; set; }

        string Password { get; set; }

        bool AuthenticationFailureErrorVisible { get; set; }

        void RedirectToLoginHandler(string formattedQueryString);
    }
}
