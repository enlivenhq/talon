using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Talon.Data.Repositories
{
    using Interfaces;
    using Models;

    public class TimeStatisticsRepository : BaseRepository, ITimeStatisticsRepository
    {
        #region Protected Fields

        protected int NumberOfExposures = 30;

        protected MongoCollection<TimeStatistics> Collection;

        #endregion

        #region Public Methods

        public TimeStatisticsRepository()
        {
            Collection = Database.GetCollection<TimeStatistics>("time_statistics");
        }

        public TimeStatistics GetTimeStatisticsForStage1To2()
        {
            var query = Query<TimeStatistics>.EQ(t => t.Name, "Stage1To2");
            return Collection.Find(query).FirstOrDefault();
        }

        public TimeStatistics GetTimeStatisticsForStage2To3()
        {
            var query = Query<TimeStatistics>.EQ(t => t.Name, "Stage2To3");
            return Collection.Find(query).FirstOrDefault();
        }

        public TimeStatistics GetTimeStatisticsForStage3To4()
        {
            var query = Query<TimeStatistics>.EQ(t => t.Name, "Stage3To4");
            return Collection.Find(query).FirstOrDefault();
        }

        public TimeStatistics GetTimeStatisticsForStage4To5()
        {
            var query = Query<TimeStatistics>.EQ(t => t.Name, "Stage4To5");
            return Collection.Find(query).FirstOrDefault();
        }

        #endregion
    }
}
