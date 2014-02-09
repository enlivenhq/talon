using System;

namespace Talon.Data.Models
{
    public class TopOpportunity
    {
        #region Meta Info

        public string CurrentStageName { get; set; }

        public string MainCompetitors { get; set; }

        public string OpportunityId { get; set; }

        public string OpportunityName { get; set; }

        public string AccountName { get; set; }

        public string Description { get; set; }

        public string OwnerId { get; set; }

        public string OwnerName { get; set; }

        public char? PainRatingChar { get; set; }

        public char? ProductFitRatingChar { get; set; }

        public char? DemoRatingChar { get; set; }

        public char? CompetitorRatingChar { get; set; }

        #endregion

        #region Calculated Or Projected

        public string ForecastString { get; set; }

        public int CurrentStageId { get; set; }

        public DateTime ProjectedCloseDate { get; set; }

        public DateTime CalculatedCloseDate { get; set; }

        public double ForecastRating { get; set; }

        public InputWeight ForecastWeight { get; set; }

        public float ExpectedRevenue { get; set; }

        public float ExpectedRevenueUpper { get; set; }

        public float ExpectedRevenueLower { get; set; }

        public double CalculatedProbabilityOfClose { get; set; }

        public float ProjectedProbabilityOfClose { get; set; }

        public float Amount { get; set; }

        public InputWeight AmountWeight { get; set; }

        public double CompetitorRating { get; set; }

        public InputWeight CompetitorRatingWeight { get; set; }

        public double DemoRating { get; set; }

        public InputWeight DemoRatingWeight { get; set; }

        public double PainRating { get; set; }

        public InputWeight PainRatingWeight { get; set; }

        public double ProductFitRating { get; set; }

        public InputWeight ProductFitRatingWeight { get; set; }

        public int FormattedCalculatedProbabilityOfClose
        {
            get { return (int)(CalculatedProbabilityOfClose * 100); }
        }

        #endregion
    }
}
