using System;
using System.Collections.Generic;
using GymHub.Models.Domain;

namespace GymHub.Service.DataTransferObjects
{
    public class GetActiveUsersStatisticsResponse
    {
        public IEnumerable<TraineeStatistic> TraineeStatistics { get; set; }
    }

    public class GetActiveUsersStatisticsRequest
    {
        public IEnumerable<Trainee> ActiveUsers { get; set; }
        public IEnumerable<Exercise> ExercisesOfTheDay { get; set; }
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

    public class GetExercisesPerformedByTraineeRequest
    {
        public int TraineeId { get; set; }
    }

    public class GetExercisesPerformedByTraineeResponse
    {
        public IEnumerable<Exercise> Exercises { get; set; }
    }

    public class GetStatisticsForTraineeResponse
    {
        public IEnumerable<TraineeStatistic> TraineeStatistics { get; set; }
    }

    public class GetStatisticsForTraineeRequest
    {
        public int TraineeId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
