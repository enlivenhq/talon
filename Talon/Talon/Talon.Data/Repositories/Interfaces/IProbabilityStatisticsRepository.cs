using System.Collections.Generic;

namespace Talon.Data.Repositories.Interfaces
{
    using Models;

    public interface IProbabilityStatisticsRepository
    {
        InputWeight GetForecastWeight();

        InputWeight GetPainRatingWeight();

        InputWeight GetProductFitRatingWeight();

        InputWeight GetDemoRatingWeight();

        InputWeight GetCompetitorRatingWeight();

        InputWeight GetAmountWeight();

        double GetAverageAmountForCompany();
    }
}
