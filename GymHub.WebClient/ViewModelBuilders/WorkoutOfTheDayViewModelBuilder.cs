using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GymHub.Models.Domain;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient.ViewModelBuilders
{
    public class WorkoutOfTheDayViewModelBuilder
    {
        private readonly WorkoutOfTheDayViewModel _workoutOfTheDayViewModel;

        public WorkoutOfTheDayViewModelBuilder()
        {
            _workoutOfTheDayViewModel = new WorkoutOfTheDayViewModel();
        }

        public WorkoutOfTheDayViewModelBuilder WithValues(IEnumerable<Exercise> exercisesOfTheDay)
        {
            foreach (var exercise in exercisesOfTheDay)
            {
                _workoutOfTheDayViewModel.ExerciseViewModels.Add(Mapper.Map<ExerciseViewModel>(exercise));
            }

            return this;
        }

        public WorkoutOfTheDayViewModelBuilder WithDataTableRows(
            IEnumerable<Trainee> activeTrainees, List<Exercise> exercisesOfTheDay)
        {

            foreach (var activeTrainee in activeTrainees)
            {
                var traineeRow = new List<string>();
                MapEditColumn(activeTrainee, traineeRow);
                MapNameColumn(activeTrainee, traineeRow);
                MapMostRecentStatisticColumn(exercisesOfTheDay, activeTrainee, traineeRow);
                _workoutOfTheDayViewModel.DataTableRows.Add(traineeRow);
            }

            return this;
        }
    
        public WorkoutOfTheDayViewModel Build()
        {
            return _workoutOfTheDayViewModel;
        }


        private static void MapMostRecentStatisticColumn(IEnumerable<Exercise> exercisesOfTheDay, Trainee activeTrainee, ICollection<string> traineeRow)
        {
            foreach (var exercise in exercisesOfTheDay)
            {
                var mostRecentStatistic =
                    activeTrainee.TraineeStatistics
                        .Where(m => m.ExerciseId == exercise.Id)
                        .OrderByDescending(m => m.Date)
                        .FirstOrDefault();

                var exerciseColumn = "";
                if (mostRecentStatistic != null)
                {
                    exerciseColumn = string.Format("{0} kg ({1})", mostRecentStatistic.Weight.ToString("0"),
                        mostRecentStatistic.Date.ToString("dd-MM-yyy"));
                }

                traineeRow.Add(exerciseColumn);
            }
        }

        private static void MapNameColumn(Trainee activeTrainee, ICollection<string> traineeRow)
        {
            var nameColumn = string.Format("{0} {1}", activeTrainee.FirstName, activeTrainee.LastName);
            traineeRow.Add(nameColumn);
        }

        private static void MapEditColumn(Trainee activeTrainee, ICollection<string> traineeRow)
        {
            var editStatisticsColumn =
                string.Format(
                    "<button type='button' class='btn-link edit-statistics' data-trainee-id={0}><span class='glyphicon glyphicon-pencil'></span></button>",
                    activeTrainee.Id);
            traineeRow.Add(editStatisticsColumn);
        }
    }
}