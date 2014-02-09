using MongoDB.Bson;

namespace Talon.Data.Models
{
    public class TimeStatistics
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public double AverageNumberOfDays { get; set; }

        public double StandardDeviation { get; set; }

        public int NumberOfExposures { get; set; }

        /// <summary>
        /// number of days sped up in best case scenario
        /// </summary>
        public double? PainRatingWeight { get; set; } 

        public double? ProductFitRatingWeight { get; set; } 

        public double? DemoRatingWeight { get; set; }

        public double? CompetitorWeight { get; set; }
    }
}
