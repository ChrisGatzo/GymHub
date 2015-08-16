using System.Collections.Generic;
using GymHub.Models;
using GymHub.Models.Domain;

namespace GymHub.Service
{
    public interface IScheduleService
    {
        IEnumerable<Exercise> GetExercisesOfTheDay();
    }
}