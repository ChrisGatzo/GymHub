using System;
using GymHub.Models;
using GymHub.Models.Domain;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient.ViewModelBuilders
{
    public class TraineeStatisticViewModelBuilder
    {        
        private readonly TraineeStatisticViewModel _traineeStatisticViewModel;

        public TraineeStatisticViewModelBuilder()
        {        
            _traineeStatisticViewModel = new TraineeStatisticViewModel();
        }

        public TraineeStatisticViewModelBuilder WithDefaultValues(Exercise exercise)
        {
            _traineeStatisticViewModel.Date = DateTime.Now;
            _traineeStatisticViewModel.ExerciseId = exercise.Id;
            _traineeStatisticViewModel.ExerciseName = exercise.Name;

            return this;
        }

        public TraineeStatisticViewModelBuilder WithTraineeId(Trainee trainee)
        {
            _traineeStatisticViewModel.TraineeId = trainee.Id;           

            return this;
        }

        public TraineeStatisticViewModel Build()
        {
            return _traineeStatisticViewModel;
        }
    }
}