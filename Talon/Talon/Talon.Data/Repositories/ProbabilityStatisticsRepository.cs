using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Talon.Data.Repositories
{
    using Interfaces;
    using Models;

    public class ProbabilityStatisticsRepository : BaseRepository, IProbabilityStatisticsRepository
    {
        #region Protected Fields

        protected const int NumberOfExposures = 30;

        protected MongoCollection<InputWeight> Collection; 

        #endregion

        #region Public Methods

        public ProbabilityStatisticsRepository()
        {
            Collection = Database.GetCollection<InputWeight>("probability_statistics");
        }

        public InputWeight GetForecastWeight()
        {
            var query = Query<InputWeight>.EQ(weight => weight.Name, "Forecast");
            var results = Collection.Find(query);
            return results.FirstOrDefault();
        }

        public InputWeight GetPainRatingWeight()
        {
            var query = Query<InputWeight>.EQ(weight => weight.Name, "PainRating");
            var results = Collection.Find(query);
            return results.FirstOrDefault();
        }

        public InputWeight GetProductFitRatingWeight()
        {
            var query = Query<InputWeight>.EQ(weight => weight.Name, "ProductFitRating");
            var results = Collection.Find(query);
            return results.FirstOrDefault();
        }

        public InputWeight GetDemoRatingWeight()
        {
            var query = Query<InputWeight>.EQ(weight => weight.Name, "DemoRating");
            var results = Collection.Find(query);
            return results.FirstOrDefault();
        }

        public InputWeight GetCompetitorRatingWeight()
        {
            var query = Query<InputWeight>.EQ(weight => weight.Name, "CompetitorRating");
            var results = Collection.Find(query);
            return results.FirstOrDefault();
        }

        public InputWeight GetAmountWeight()
        {
            var query = Query<InputWeight>.EQ(weight => weight.Name, "Amount");
            var results = Collection.Find(query);
            return results.FirstOrDefault();
        }

        public double GetAverageAmountForCompany()
        {
            return 98333.33;
        }

        #endregion
    }
}
