using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public interface IStatisticsService
    {
        GetActiveUsersStatisticsResponse GetActiveUsersStatistics(GetActiveUsersStatisticsRequest request);        
        GetStatisticsForTraineeResponse GetStatisticsForTrainee(GetStatisticsForTraineeRequest request);
        GetExercisesOfTheDayResponse GetExercisesOfTheDay(GetExercisesOfTheDayRequest request);
        GetExercisesPerformedByTraineeResponse GetExercisesPerformedByTrainee(GetExercisesPerformedByTraineeRequest request);
        UpdateTraineeStatisticsResponse UpdateTraineeStatistics(UpdateTraineeStatisticsRequest request);
    }  
}