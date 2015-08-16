using System.Collections.Generic;
using GymHub.DataAccess;
using GymHub.DataAccess.Infrastructure;
using GymHub.Models;
using GymHub.Models.Domain;

namespace GymHub.Service
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Exercise> GetExercisesOfTheDay()
        {
            // _unitOfWork.exerciseRepository.Get().ToList();

            var exercisesOfTheDay = new List<Exercise>
            {
                new Exercise {Id = 1, Name = "Squat"},
                new Exercise {Id = 2, Name = "Arnold"},
                new Exercise {Id = 3, Name = "Stallone"}
            };

            return exercisesOfTheDay;
        }
    }
}