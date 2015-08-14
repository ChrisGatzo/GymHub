using System.Collections.Generic;
using GymHub.Models;

namespace GymHub.Service
{
    public interface IScheduleService
    {
        IEnumerable<Exercise> GetExercisesOfTheDay();
    }
}