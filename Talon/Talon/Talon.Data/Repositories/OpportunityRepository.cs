using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talon.Data.Repositories.Interfaces;

namespace Talon.Data.Repositories
{
    using Models;
    using Salesforce.Force;

    public class OpportunityRepository : BaseRepository, IOpportunityRepository
    {
        #region Public Methods

        public async Task<IEnumerable<Opportunity>> GetOpportunities(ForceClient forceClient)
        {
            if (forceClient == null) throw new ArgumentNullException("forceClient");
            var dynamicResults = await forceClient.Query<dynamic>(
                @"SELECT 
                    AccountId, Amount, CloseDate, IsClosed, 
                    IsWon, Competitor__c, CreatedDate, Demo_Rating__c, 
                    Description, ExpectedRevenue, Fiscal, FiscalYear, 
                    LastActivityDate, LastModifiedDate, MainCompetitors__c, 
                    Name, NextStep, Id, OwnerId, Pain_Rating__c, Probability, 
                    Product_Fit_Rating__c FROM Opportunity 
                WHERE IsDeleted = false 
                AND FiscalYear != 2007");

            var converted =
                from o in dynamicResults.ToList()
                select ConvertDynamicOpportunity(o) 
                as Opportunity;

            return converted;
        }

        public async Task<Opportunity> GetOpportunity(ForceClient forceClient, string opportunityId)
        {
            if (forceClient == null) throw new ArgumentNullException("forceClient");
            var query = string.Format(@"SELECT 
                    AccountId, Amount, CloseDate, IsClosed, 
                    IsWon, Competitor__c, CreatedDate, Demo_Rating__c, 
                    Description, ExpectedRevenue, Fiscal, FiscalYear, 
                    LastActivityDate, LastModifiedDate, MainCompetitors__c, 
                    Name, NextStep, Id, OwnerId, Pain_Rating__c, Probability, 
                    Product_Fit_Rating__c FROM Opportunity 
                WHERE IsDeleted = false 
                AND FiscalYear != 2007
                AND Id = '{0}' LIMIT 1", opportunityId);

            var dynamicResults = await forceClient.Query<dynamic>(query);
            var converted =
                from o in dynamicResults.ToList()
                select ConvertDynamicOpportunity(o)
                as Opportunity;

            return converted.First();
        }

        #endregion

        #region Private Methods

        private static Opportunity ConvertDynamicOpportunity(dynamic o)
        {
            var opportunity = new Opportunity
            {
                // Disabling ReSharper checking on ternary to null coalescing
                // because of odd behavior when converting from a JSON string
                // and null detection.

                // ReSharper disable ConvertConditionalTernaryToNullCoalescing
                OpportunityId = o.Id,
                Account = o.AccountId,
                Amount = (float) ((o.Amount == null) ? 0 : o.Amount),
                CloseDate = o.CloseDate,
                Description = o.Description,
                ExpectedRevenue = (float) ((o.ExpectedRevenue == null) ? 0 : o.ExpectedRevenue),
                NextStep = o.NextStep,
                OpportunityName = o.Name,
                OwnerId = o.OwnerId,
                Campaign = o.CampaignId,
                Probability = (float) ((o.Probability == null) ? 0 : o.Probability),
                StageName = o.StageName,
                CompetitorRating = o.Competitor__c,
                DemoRating = o.Demo_Rating__c,
                MainCompetitors = o.MainCompetitors__c,
                PainRating = o.Pain_Rating__c,
                ProductFitRating = o.Product_Fit_Rating__c
                // ReSharper restore ConvertConditionalTernaryToNullCoalescing
            };

            opportunity.OwnerName = GenerateRandomizedOwnerNameFromId(opportunity.OwnerId);

            return opportunity;
        }

        private static string GenerateRandomizedOwnerNameFromId(string ownerId)
        {
            switch (ownerId)
            {
                case "1":
                    return "Carrie Samuels";

                case "2":
                    return "Matthew O'Brien";

                case "3":
                    return "Arnold Ryan";

                case "4":
                    return "Lucy Stevens";

                default:
                    return "John Smith";
            }
        }

        #endregion
    }
}
