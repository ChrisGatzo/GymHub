using System.Collections.Generic;
using GymHub.Models.Domain;
using GymHub.Models.Helpers;

namespace GymHub.Service.DataTransferObjects
{
    public class GetPagedTraineesRequest
    {
        public int Start { get; set; }
        public int Length { get; set; }
        public string SearchValue { get; set; }
        public int OrderByColumn { get; set; }
        public OrderDirection OrderDirection { get; set; }

        public bool WithExercises { get; set; }
        public bool WithStatistics { get; set; }
    }

    public class GetPagedTraineesResponse
    {
        public IEnumerable<Trainee> PagedTrainees { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public IEnumerable<TraineeStatistic> TraineeStatistics { get; set; }

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
}
