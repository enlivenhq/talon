using MongoDB.Bson;

namespace Talon.Data.Models
{
    public class InputWeight
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// % of numerical score that contributes to Probability of Close
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Number of trials that have given rise to this weight calculation
        /// </summary>
        public int NumberOfExposures { get; set; }

        public double StandardDeviation { get; set; }
    }
}
