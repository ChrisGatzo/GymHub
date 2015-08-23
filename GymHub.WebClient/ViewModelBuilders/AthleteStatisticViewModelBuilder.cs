using System;
using GymHub.Models.Domain;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient.ViewModelBuilders
{
    public class AthleteStatisticViewModelBuilder
    {
        private readonly AthleteStatisticViewModel _athleteStatisticViewModel;

        public AthleteStatisticViewModelBuilder()
        {
            _athleteStatisticViewModel = new AthleteStatisticViewModel();
        }

        public AthleteStatisticViewModelBuilder WithDefaultValues(Exercise exercise)
        {
            _athleteStatisticViewModel.Date = DateTime.Now;
            _athleteStatisticViewModel.ExerciseId = exercise.Id;
            _athleteStatisticViewModel.ExerciseName = exercise.Name;

            return this;
        }

        public AthleteStatisticViewModelBuilder WithAthleteId(Athlete athlete)
        {
            _athleteStatisticViewModel.AthleteId = athlete.Id;

            return this;
        }

        public AthleteStatisticViewModelBuilder WithWeight(decimal? weight)
        {
            _athleteStatisticViewModel.Weight = weight;

            return this;
        }

        public AthleteStatisticViewModel Build()
        {
            return _athleteStatisticViewModel;
        }
    }
}