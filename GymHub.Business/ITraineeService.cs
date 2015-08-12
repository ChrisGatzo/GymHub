using System.Collections.Generic;
using System.Linq;
using GymHub.DataAccess.DomainModels;
using GymHub.Models.Helpers;

namespace GymHub.Business
{
    public interface ITraineeService
    {
        List<Trainee> GetActiveTrainees();
        List<Trainee> GetAllTrainees();
        List<Trainee> GetPagedTrainees(IOrderedEnumerable<Column> order, int start, int length, Search search);
        int GetTraineesCount();
        int GetFilteredTraineesCount(Search search);
    }
}