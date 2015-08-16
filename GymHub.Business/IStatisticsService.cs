using System;
using System.Collections.Generic;
using GymHub.Models.Domain;

namespace GymHub.Service
{
    public interface IStatisticsService
    {
        IEnumerable<TraineeStatistic> GetActiveUsersStatistics(IEnumerable<Trainee> activeUsers, IEnumerable<Exercise> exercisesOfTheDay);
        IEnumerable<TraineeStatistic> GetStatisticsForTrainee(int traineeId, int exerciseId, DateTime dateFrom, DateTime dateTo);
        GetExercisesOfTheDayResponse GetExercisesOfTheDay(GetExercisesOfTheDayRequest request);
        GetExercisesPerformedByTraineeResponse GetExercisesPerformedByTrainee(GetExercisesPerformedByTraineeRequest request);
        UpdateTraineeStatisticsResponse UpdateTraineeStatistics(UpdateTraineeStatisticsRequest request);            
    }

    public class UpdateTraineeStatisticsRequest
    {
        public IEnumerable<TraineeStatistic> TraineeStatistics { get; set; }
    }

    public class UpdateTraineeStatisticsResponse
    {
    }

    public class GetExercisesOfTheDayRequest
    {
        public bool WithTraineeStatistics { get; set; }
        public int TraineeId { get; set; }
    }

    public class GetExercisesOfTheDayResponse
    {
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<TraineeStatistic> TraineeStatistics { get; set; }
        public Trainee Trainee { get; set; }
    }

    public class GetExercisesOfTheDayWithTraineeRequest
    {
    }

    public class GetExercisesOfTheDayWithTraineeResponse
    {
    }

    public class GetExercisesPerformedByTraineeRequest
    {
        public int TraineeId { get; set; }
    }

    public class GetExercisesPerformedByTraineeResponse
    {
        public IEnumerable<Exercise> Exercises { get; set; }
    }
}