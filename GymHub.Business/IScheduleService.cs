using System.Collections.Generic;
using GymHub.DataAccess.DomainModels;

namespace GymHub.Business
{
    public interface IScheduleService
    {
        List<Exercise> GetExercisesOfTheDay();
    }
}