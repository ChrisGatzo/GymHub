using System;
using System.Collections.Generic;
using GymHub.Models;
using GymHub.Models.Domain;

namespace GymHub.Service
{
    public interface IStatisticsService
    {
        IEnumerable<TraineeStatistic> GetActiveUsersStatistics(IEnumerable<Trainee> activeUsers, IEnumerable<Exercise> exercisesOfTheDay);
        IEnumerable<TraineeStatistic> GetStatisticsForTrainee(int traineeId, int exerciseId, DateTime dateFrom, DateTime dateTo);
        IEnumerable<Exercise> GetExercisesPerformedByTrainee(int traineeId);
        void UpdateTraineeStatistics(IEnumerable<TraineeStatistic> traineeStatistics);
    }
}