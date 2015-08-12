using System;
using System.Collections.Generic;
using GymHub.DataAccess.DomainModels;

namespace GymHub.Business
{
    public interface IStatisticsService
    {
        List<TraineeStatistic> GetActiveUsersStatistics(List<Trainee> activeUsers, List<Exercise> exercisesOfTheDay);
        List<TraineeStatistic> GetStatisticsForTrainee(int traineeId, int exerciseId, DateTime dateFrom, DateTime dateTo);
        List<Exercise> GetExercisesPerformedByTrainee(int traineeId); 
        void UpdateTraineeStatistics(List<TraineeStatistic> traineeStatistics);
    }
}