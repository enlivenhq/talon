using System.Net.Http;
using System.Threading.Tasks;
using Salesforce.Common;

namespace Talon.Data.Components
{
    public class AuthenticationComponent
    {
        #region Public Properties

        public async static Task<AuthenticationClient> GetAuthenticationClient(string username, string password)
        {
            var consumerKey = ConfigurationComponent.SalesforceConsumerKey;
            var consumerSecret = ConfigurationComponent.SalesforceConsumerSecret;
            var httpClient = new HttpClient();

            var auth = new AuthenticationClient(httpClient);
            await auth.UsernamePassword(consumerKey, consumerSecret, username, password);

            return auth;
        }

        #endregion
    }
}
