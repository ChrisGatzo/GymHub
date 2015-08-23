using System.Collections.Generic;
using GymHub.Models.Domain;
using GymHub.Models.Helpers;

namespace GymHub.Service.DataTransferObjects
{
    public class GetFilteredAthletesRequest
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public int OrderByColumn { get; set; }
        public OrderDirection OrderDirection { get; set; }

        public bool WithExercisesOfTheDay { get; set; }
        public bool WithStatistics { get; set; }
    }

    public class GetFilteredAthletesResponse
    {
        public IEnumerable<Athlete> FilteredAthletes { get; set; }
        public IEnumerable<Exercise> ExercisesOfTheDay { get; set; }

        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
    }

    public class GetAllAthletesRequest
    {

    }

    public class GetAllAthletesResponse
    {
        public IEnumerable<Athlete> Athletes { get; set; }
    }

    public class GetActiveAthletesRequest
    {
        public string IncludeProperties { get; set; }
    }

    public class GetActiveAthletesResponse
    {
        public IEnumerable<Athlete> Athletes { get; set; }
    }

    public class CheckInAthleteResponse
    {

    }

    public class CheckInAthleteRequest
    {
        public int AthleteId { get; set; }
    }

    public class GetInactiveAthletesRequest
    {

    }

    public class GetInactiveAthletesResponse
    {
        public IEnumerable<Athlete> InactiveAthletes { get; set; }
    }

    internal class FilterAthletesResponse
    {
        public IEnumerable<Athlete> PagedAthletes { get; set; }
        public int PagedAthletesCount { get; set; }
        public int ActiveAthletesCount { get; set; }
    }
}
