using MongoDB.Driver;
using Talon.Data.Components;

namespace Talon.Data.Repositories
{
    public class BaseRepository
    {
        #region Protected Properties

        protected MongoClient Client;

        protected MongoServer Server;

        protected MongoDatabase Database;

        #endregion

        #region Protected Methods

        protected BaseRepository()
        {
            Client = new MongoClient(ConfigurationComponent.MongoConnectionString);
            Server = Client.GetServer();
            Database = Server.GetDatabase(ConfigurationComponent.MongoDatabaseName);
        }

        #endregion
    }
}
