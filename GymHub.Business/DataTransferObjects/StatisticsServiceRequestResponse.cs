using System;
using System.Collections.Generic;
using GymHub.Models.Domain;

namespace GymHub.Service.DataTransferObjects
{
    public class GetActiveUsersStatisticsResponse
    {
        public IEnumerable<AthleteStatistic> AthleteStatistics { get; set; }
    }

    public class GetActiveUsersStatisticsRequest
    {
        public IEnumerable<Athlete> ActiveUsers { get; set; }
        public IEnumerable<Exercise> ExercisesOfTheDay { get; set; }
    }

    public class UpdateAthleteStatisticsRequest
    {
        public IEnumerable<AthleteStatistic> AthleteStatistics { get; set; }
    }

    public class UpdateAthleteStatisticsResponse
    {
    }

    public class GetExercisesOfTheDayRequest
    {
        public bool WithAthleteStatistics { get; set; }
        public int AthleteId { get; set; }
    }

    public class GetExercisesOfTheDayResponse
    {
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<AthleteStatistic> AthleteStatistics { get; set; }
        public Athlete Athlete { get; set; }
    }   

    public class GetExercisesPerformedByAthleteRequest
    {
        public int AthleteId { get; set; }
    }

    public class GetExercisesPerformedByAthleteResponse
    {
        public IEnumerable<Exercise> Exercises { get; set; }
    }

    public class GetStatisticsForAthleteResponse
    {
        public IEnumerable<AthleteStatistic> AthleteStatistics { get; set; }
    }

    public class GetStatisticsForAthleteRequest
    {
        public int AthleteId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
