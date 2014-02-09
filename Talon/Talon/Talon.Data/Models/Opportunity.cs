using System;

namespace Talon.Data.Models
{
    public class Opportunity
    {
        public string OpportunityId { get; set; }

        public string Account { get; set; }

        public float Amount { get; set; }

        public DateTime CloseDate { get; set; }

        public string Description { get; set; }

        public float ExpectedRevenue { get; set; }

        public string NextStep { get; set; }

        public string OpportunityName { get; set; }

        public string OwnerName { get; set; }

        public string OwnerId { get; set; }

        public string Campaign { get; set; }

        public float Probability { get; set; }

        public string StageName { get; set; }

        public char? CompetitorRating { get; set; }

        public char? DemoRating { get; set; }

        public string MainCompetitors { get; set; }

        public char? PainRating { get; set; }

        public char? ProductFitRating { get; set; }
    }
}
