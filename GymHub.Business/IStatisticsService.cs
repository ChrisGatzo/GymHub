using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public interface IStatisticsService
    {
        GetActiveUsersStatisticsResponse GetActiveUsersStatistics(GetActiveUsersStatisticsRequest request);        
        GetStatisticsForAthleteResponse GetStatisticsForAthlete(GetStatisticsForAthleteRequest request);
        GetExercisesOfTheDayResponse GetExercisesOfTheDay(GetExercisesOfTheDayRequest request);
        GetExercisesPerformedByAthleteResponse GetExercisesPerformedByAthlete(GetExercisesPerformedByAthleteRequest request);
        UpdateAthleteStatisticsResponse UpdateAthleteStatistics(UpdateAthleteStatisticsRequest request);
    }  
}