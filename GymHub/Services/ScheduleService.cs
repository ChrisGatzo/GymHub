using System.Collections.Generic;
using GymHub.DataAccess;
using GymHub.DataAccess.DomainModels;

namespace GymHub.Services
{
    class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Exercise> GetExercisesOfTheDay()
        {
            // _unitOfWork.exerciseRepository.Get();

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