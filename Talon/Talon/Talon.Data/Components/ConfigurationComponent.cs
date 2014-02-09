namespace Talon.Data.Components
{
    using System.Configuration;

    public class ConfigurationComponent
    {
        #region Public Properties

        public static string SalesforceConsumerKey
        {
            get { return ConfigurationManager.AppSettings["SalesforceConsumerKey"]; }
        }

        public static string SalesforceConsumerSecret
        {
            get { return ConfigurationManager.AppSettings["SalesforceConsumerSecret"]; }
        }

        public static string MongoConnectionString
        {
            get { return ConfigurationManager.AppSettings["MongoDbConnectionString"]; }
        }

        public static string MongoDatabaseName
        {
            get { return ConfigurationManager.AppSettings["MongoDbDatabaseName"]; }
        }

        #endregion
    }
}
