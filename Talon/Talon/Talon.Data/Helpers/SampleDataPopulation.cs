using MongoDB.Bson;
using MongoDB.Driver;
using Talon.Data.Components;

namespace Talon.Data.Helpers
{
    public class SampleDataPopulation
    {
        #region Protected Fields

        protected MongoDatabase Database;

        #endregion

        #region Private Fields

        private const int NumberOfExposures = 30;

        #endregion

        #region Public Methods

        public SampleDataPopulation()
        {
            Database =
                new MongoClient(ConfigurationComponent.MongoConnectionString).GetServer()
                    .GetDatabase(ConfigurationComponent.MongoDatabaseName);
        }

        public void InsertProbabilityStatistics()
        {
            var collection = Database.GetCollection("probability_statistics");

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Forecast",
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = .005,
                Weight = .05
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "PainRating",
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = .03,
                Weight = .17
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "ProductFitRating",
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = .04,
                Weight = .22
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "DemoRating",
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = .01,
                Weight = .16
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "CompetitorRating",
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = .01,
                Weight = .25
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Amount", 
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = .02,
                Weight = .15
            });
        }

        public void InsertTimeStatistics()
        {
            var collection = Database.GetCollection("time_statistics");

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Stage1To2",
                AverageNumberOfDays = 5,
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = .9
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Stage2To3",
                AverageNumberOfDays = 15,
                PainRatingWeight = .8,
                ProductFitRatingWeight = .7,
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = 2.7
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Stage3To4",
                AverageNumberOfDays = 10,
                PainRatingWeight = .8,
                ProductFitRatingWeight = .7,
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = 2,
                DemoRatingWeight = 2.1,
                CompetitorWeight = 4.3
            });

            collection.Save(new
            {
                Id = ObjectId.GenerateNewId(),
                Name = "Stage4To5",
                AverageNumberOfDays = 25,
                PainRatingWeight = .8,
                ProductFitRatingWeight = .7,
                NumberOfExposures = NumberOfExposures,
                StandardDeviation = 5,
                DemoRatingWeight = 2.1,
                CompetitorWeight = 2.3
            });
        }

        public void InsertAllSampleData()
        {
            InsertProbabilityStatistics();
            InsertTimeStatistics();
        }

        #endregion
    }
}
