using System.Collections.Generic;
using GymHub.Models.Domain;
using GymHub.Models.Helpers;

namespace GymHub.Service.DataTransferObjects
{
    public class GetFilteredTraineesRequest
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public int OrderByColumn { get; set; }
        public OrderDirection OrderDirection { get; set; }

        public bool WithExercisesOfTheDay { get; set; }
        public bool WithStatistics { get; set; }
    }

    public class GetFilteredTraineesResponse
    {
        public IEnumerable<Trainee> FilteredTrainees { get; set; }
        public IEnumerable<Exercise> ExercisesOfTheDay { get; set; }

        public int RecordsTotal { get; set; }
        public int RecordsFiltered { get; set; }
    }

    public class GetAllTraineesRequest
    {

    }

    public class GetAllTraineesResponse
    {
        public IEnumerable<Trainee> Trainees { get; set; }
    }

    public class GetActiveTraineesRequest
    {
        public string IncludeProperties { get; set; }
    }

    public class GetActiveTraineesResponse
    {
        public IEnumerable<Trainee> Trainees { get; set; }
    }

    public class CheckInTraineeResponse
    {

    }

    public class CheckInTraineeRequest
    {
        public int TraineeId { get; set; }
    }

    public class GetInactiveTraineesRequest
    {

    }

    public class GetInactiveTraineesResponse
    {
        public IEnumerable<Trainee> InactiveTrainees { get; set; }
    }

    internal class FilterTraineesResponse
    {
        public IEnumerable<Trainee> PagedTrainees { get; set; }
        public int PagedTraineesCount { get; set; }
        public int ActiveTraineesCount { get; set; }
    }
}
