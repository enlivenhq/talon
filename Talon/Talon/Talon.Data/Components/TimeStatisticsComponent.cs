namespace Talon.Data.Components
{
    using System;
    using Models;
    using Repositories;
    using Repositories.Interfaces;

    public class TimeStatisticsComponent
    {
        public ITimeStatisticsRepository Repository { get; set; }

        public TimeStatisticsComponent()
        {
            Repository = new TimeStatisticsRepository();
        }

        public TimeStatisticsComponent(ITimeStatisticsRepository timeStatisticsRepository)
        {
            Repository = timeStatisticsRepository;
        }

        public TopOpportunity AddCalculatedCloseDate(TopOpportunity topOpportunity)
        {
            var time1To2 = Repository.GetTimeStatisticsForStage1To2();
            var time2To3 = Repository.GetTimeStatisticsForStage2To3();
            var time3To4 = Repository.GetTimeStatisticsForStage3To4();
            var time4To5 = Repository.GetTimeStatisticsForStage4To5();

            var enhancedPainRating = DoubleAndSubtractOne(topOpportunity.PainRating);
            var enhancedProductFitRating = DoubleAndSubtractOne(topOpportunity.ProductFitRating);
            var enhancedDemoRating = DoubleAndSubtractOne(topOpportunity.DemoRating);
            var enhancedCompetitorRating = DoubleAndSubtractOne(topOpportunity.CompetitorRating);

            var calculated1To2 = GetCalculatedInterval(enhancedPainRating, enhancedProductFitRating, enhancedDemoRating,
                enhancedCompetitorRating, time1To2);
            var calculated2To3 = GetCalculatedInterval(enhancedPainRating, enhancedProductFitRating, enhancedDemoRating,
                enhancedCompetitorRating, time2To3);
            var calculated3To4 = GetCalculatedInterval(enhancedPainRating, enhancedProductFitRating, enhancedDemoRating,
                enhancedCompetitorRating, time3To4);
            var calculated4To5 = GetCalculatedInterval(enhancedPainRating, enhancedProductFitRating, enhancedDemoRating,
                enhancedCompetitorRating, time4To5);

            topOpportunity.CalculatedCloseDate = DateTime.Now.AddDays(calculated1To2 + calculated2To3 + calculated3To4 + calculated4To5).Date;
            return topOpportunity;

        }

        private static double GetCalculatedInterval(double? enhancedPainRating, double? enhancedProductFitRating, double? enhancedDemoRating, double? enhancedCompetitorRating, TimeStatistics timeStat)
        {
            var baseDays = timeStat.AverageNumberOfDays;
            return baseDays + (enhancedPainRating ?? 0)*(timeStat.PainRatingWeight ?? 0) +
                   (enhancedProductFitRating ?? 0)*(timeStat.ProductFitRatingWeight ?? 0) +
                   (enhancedDemoRating ?? 0)*(timeStat.DemoRatingWeight ?? 0) +
                   (enhancedCompetitorRating ?? 0)*(timeStat.CompetitorWeight ?? 0);
        }

        private static double DoubleAndSubtractOne(double rating)
        {
            return rating * 2 - 1;
        }
    }
}
