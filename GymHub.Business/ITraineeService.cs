using System.Collections.Generic;
using System.Linq;
using GymHub.Models;
using GymHub.Models.Domain;
using GymHub.Models.Helpers;

namespace GymHub.Service
{
    public interface ITraineeService
    {
        IEnumerable<Trainee> GetActiveTrainees();
        GetAllTraineesResponse GetAllTrainees(GetAllTraineesRequest request);
        IEnumerable<Trainee> GetPagedTrainees(IOrderedEnumerable<Column> order, int start, int length, Search search);
        int GetTraineesCount();
        int GetFilteredTraineesCount(Search search);
    }

    public class GetAllTraineesRequest
    {
    }

    public class GetAllTraineesResponse
    {
        public IEnumerable<Trainee> Trainees { get; set; }
    }
}