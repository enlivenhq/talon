namespace Talon.Data.Repositories.Interfaces
{
    using Models;

    public interface ITimeStatisticsRepository
    {
        TimeStatistics GetTimeStatisticsForStage1To2();

        TimeStatistics GetTimeStatisticsForStage2To3();

        TimeStatistics GetTimeStatisticsForStage3To4();

        TimeStatistics GetTimeStatisticsForStage4To5();
    }
}
