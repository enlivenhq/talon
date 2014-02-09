using System.Collections.Generic;

namespace Talon.Data.Models
{
    public class CategorizedTopOpportunities
    {
        public List<TopOpportunity> HotOpportunites;
        public List<TopOpportunity> MediumOpportunities;
        public List<TopOpportunity> ColdOpportunities;

        public CategorizedTopOpportunities()
        {
            HotOpportunites = new List<TopOpportunity>();
            MediumOpportunities = new List<TopOpportunity>();
            ColdOpportunities = new List<TopOpportunity>();
        }
    }
}
