using System.Collections.Generic;
using GymHub.DataAccess.DomainModels;

namespace GymHub.Services
{
    public interface IScheduleService
    {
        List<Exercise> GetExercisesOfTheDay();
    }
}