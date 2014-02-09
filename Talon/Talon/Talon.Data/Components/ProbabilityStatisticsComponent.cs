namespace Talon.Data.Components
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using Models;
    using Repositories;
    using Repositories.Interfaces;

    public class ProbabilityStatisticsComponent
    {
        #region Public Properties

        public IProbabilityStatisticsRepository Repository { get; set; }

        #endregion

        #region Public Methods

        public ProbabilityStatisticsComponent()
        {
            Repository = new ProbabilityStatisticsRepository();
        }

        public ProbabilityStatisticsComponent(IProbabilityStatisticsRepository probabilityStatisticsRepository)
        {
            Repository = probabilityStatisticsRepository;
        }

        public TopOpportunity GetTopOpportunity(Opportunity opportunity)
        {
            var topOpportunity = GetTopOpportunityWithWeights();

            topOpportunity = AddProjectedsToTopOpportunity(topOpportunity, opportunity);

            topOpportunity = AddInputsToTopOpportunity(topOpportunity, opportunity);

            topOpportunity = AddProbabilityOfClose(topOpportunity);

            topOpportunity = AddMetaDataToTopOpportunity(topOpportunity, opportunity);

            topOpportunity = AddExpectedRevenueNumbers(topOpportunity);

            return topOpportunity;
        }

        public CategorizedTopOpportunities CategorizeTopOpportunities(List<TopOpportunity> topOpportunities)
        {
            var categorizedTopCategories = new CategorizedTopOpportunities();
            foreach (var topOpportunity in topOpportunities)
            {
                if (topOpportunity.CalculatedProbabilityOfClose >= .7)
                {
                    categorizedTopCategories.HotOpportunites.Add(topOpportunity);
                }
                else if (topOpportunity.CalculatedProbabilityOfClose < .7 &&
                         topOpportunity.CalculatedProbabilityOfClose > .3)
                {
                    categorizedTopCategories.MediumOpportunities.Add(topOpportunity);
                }
                else
                {
                    categorizedTopCategories.ColdOpportunities.Add(topOpportunity);
                }
            }
            return categorizedTopCategories;
        }

        public string CalculateEstimatedRevenue(List<TopOpportunity> topOpportunities)
        {
            float amount = topOpportunities.Sum(topOpportunity => topOpportunity.ExpectedRevenue);
            return (amount/1000000).ToString("0.00");
        }

        #endregion

        #region Private Methods

        private static TopOpportunity AddExpectedRevenueNumbers(TopOpportunity topOpportunity)
        {
            topOpportunity.ExpectedRevenue = topOpportunity.ProjectedProbabilityOfClose*topOpportunity.Amount;
            topOpportunity.ExpectedRevenueLower = GetExpectedRevenueLower(topOpportunity.ExpectedRevenue);
            topOpportunity.ExpectedRevenueUpper = GetExpectedRevenueUpper(topOpportunity.ExpectedRevenue);
            return topOpportunity;
        }

        private static float GetExpectedRevenueUpper(float expectedRevenue)
        {
            return (float) 1.1*expectedRevenue;
        }

        private static float GetExpectedRevenueLower(float expectedRevenue)
        {
            return (float) .9 * expectedRevenue;
        }

        private static TopOpportunity AddInputsToTopOpportunity(TopOpportunity topOpportunity, Opportunity opportunity)
        {
            topOpportunity.ForecastRating = NormalizeForecast(topOpportunity.ForecastString);
            topOpportunity.PainRating = NormalizeThreeLetterRatings(opportunity.PainRating);
            topOpportunity.ProductFitRating = NormalizeThreeLetterRatings(opportunity.ProductFitRating);
            topOpportunity.DemoRating = NormalizeThreeLetterRatings(opportunity.DemoRating);
            topOpportunity.CompetitorRating = NormalizeThreeLetterRatings(opportunity.CompetitorRating);
            topOpportunity.Amount = opportunity.Amount;

            return topOpportunity;
        }

        private static double NormalizeThreeLetterRatings(char? demoRating)
        {
            if (demoRating == null || demoRating == '\0') return 0;

            switch (demoRating.ToString().ToLower())
            {
                case "a":
                    return 1;

                case "b":
                    return .5;

                case "c":
                    return 0;

                default:
                    throw new Exception("Rating is set to "+ demoRating + ". Please set to a, b, or c.");
            }
        }

        private static double NormalizeForecast(string forecast)
        {
            switch (forecast)
            {
                case "Pipeline":
                    return 0;

                case "Upside":
                    return 0.33;

                case "Likely":
                    return 0.67;

                case "Commit":
                    return 1;

                default:
                    throw new Exception(forecast + " is not of an expected string!");
            }
        }

        private string StringifyForecast(float probability)
        {
            if (probability < 0)
                throw new Exception(probability + " is less than 0.");

            if (probability >= 0 && probability < GetUpperPipeline() )
                return "Pipeline";

            if (probability >= GetUpperPipeline() && probability < GetUpperUpside())
                return "Upside";

            if (probability >= GetUpperUpside() && probability < GetUpperLikely())
                return "Likely";

            if (probability >= GetUpperLikely() && probability <= 100)
                return "Commit";

            throw new Exception(probability + " is greater than 100.");
        }

        private static int GetUpperPipeline()
        {
            return int.Parse(ConfigurationManager.AppSettings["UpperPipeline"]);
        }

        private static int GetUpperUpside()
        {
            return int.Parse(ConfigurationManager.AppSettings["UpperUpside"]);
        }

        private static int GetUpperLikely()
        {
            return int.Parse(ConfigurationManager.AppSettings["UpperLikely"]);
        }

        private static TopOpportunity AddMetaDataToTopOpportunity(TopOpportunity topOpportunity, Opportunity opportunity)
        {
            topOpportunity.CurrentStageName = GetCurrentStageFromNextStep(opportunity.NextStep);
            topOpportunity.MainCompetitors = opportunity.MainCompetitors;
            topOpportunity.OpportunityId = opportunity.OpportunityId;
            topOpportunity.OpportunityName = opportunity.OpportunityName;
            topOpportunity.AccountName = opportunity.Account;
            topOpportunity.Description = opportunity.Description;
            topOpportunity.OwnerId = opportunity.OwnerId;
            topOpportunity.OwnerName = opportunity.OwnerName;
            topOpportunity.PainRatingChar = opportunity.PainRating;
            topOpportunity.ProductFitRatingChar = opportunity.ProductFitRating;
            topOpportunity.DemoRatingChar = opportunity.DemoRating;
            topOpportunity.CompetitorRatingChar = opportunity.CompetitorRating;
            topOpportunity.CurrentStageId = GetCurrentStageIdFromNextStep(opportunity.NextStep);

            return topOpportunity;
        }

        private TopOpportunity AddProjectedsToTopOpportunity(TopOpportunity topOpportunity, Opportunity opportunity)
        {
            topOpportunity.ProjectedCloseDate = opportunity.CloseDate;
            topOpportunity.ProjectedProbabilityOfClose = (opportunity.Probability/100);
            topOpportunity.ForecastString = StringifyForecast(opportunity.Probability);

            return topOpportunity;
        }

        private static string GetCurrentStageFromNextStep(string nextStep)
        {
            switch (nextStep)
            {
                case "Defining/Developing Stage":
                    return "Qualifying Stage";

                case "Negotiations Stage":
                    return "Defining/Developing Stage";

                case "Pending Stage":
                    return "Negotiations Stage";

                case "Won/Lost Stage":
                    return "Pending Stage";

                default: 
                    throw new Exception(nextStep + " does not match any of the known stages");
            }
        }

        private static int GetCurrentStageIdFromNextStep(string nextStep)
        {
            switch (nextStep)
            {
                case "Defining/Developing Stage":
                    return 1;

                case "Negotiations Stage":
                    return 2;

                case "Pending Stage":
                    return 3;

                case "Won/Lost Stage":
                    return 4;

                default:
                    throw new Exception(nextStep + " does not match any of the known stages");
            }
        }

        private TopOpportunity GetTopOpportunityWithWeights()
        {
            var forecastWeight = Repository.GetForecastWeight();
            var painRatingWeight = Repository.GetPainRatingWeight();
            var productFitRatingWeight = Repository.GetProductFitRatingWeight();
            var demoRatingWeight = Repository.GetDemoRatingWeight();
            var competitorWeight = Repository.GetCompetitorRatingWeight();
            var amountWeight = Repository.GetAmountWeight();

            var topOpportunity = new TopOpportunity
            {
                ForecastWeight = forecastWeight,
                PainRatingWeight = painRatingWeight,
                ProductFitRatingWeight = productFitRatingWeight,
                DemoRatingWeight = demoRatingWeight,
                CompetitorRatingWeight = competitorWeight,
                AmountWeight = amountWeight
            };

            return topOpportunity;
        }

        private TopOpportunity AddProbabilityOfClose(TopOpportunity topOpportunity)
        {
            var probabilityOfClose = topOpportunity.ForecastWeight.Weight*topOpportunity.ProjectedProbabilityOfClose +
                                     topOpportunity.PainRatingWeight.Weight*topOpportunity.PainRating +
                                     topOpportunity.ProductFitRatingWeight.Weight*topOpportunity.ProductFitRating +
                                     topOpportunity.DemoRatingWeight.Weight*topOpportunity.DemoRating +
                                     topOpportunity.CompetitorRatingWeight.Weight*topOpportunity.CompetitorRating +
                                     GetProbabilityFromAmount(topOpportunity.Amount, topOpportunity.AmountWeight.Weight);

            topOpportunity.CalculatedProbabilityOfClose = probabilityOfClose;

            return topOpportunity;
        }

        private double GetProbabilityFromAmount(float amount, double amountWeight)
        {
            var averageAmount = Repository.GetAverageAmountForCompany();
            var percentOff = GetAbsoluteValueOfPercentOff(amount, averageAmount);
            var cappedAtOne = CapAtOne(percentOff);

            return CalculateProbabilityFromAmount(amountWeight, cappedAtOne);
        }

        private static double CalculateProbabilityFromAmount(double amountWeight, double cappedAtOne)
        {
            return amountWeight - cappedAtOne * amountWeight;
        }

        private static double GetAbsoluteValueOfPercentOff(float amount, double averageAmount)
        {
            return Math.Abs((amount - averageAmount)/averageAmount);
        }

        private static double CapAtOne(double percentOff)
        {
            return Math.Min(percentOff, 1);
        }

        #endregion
    }
}
