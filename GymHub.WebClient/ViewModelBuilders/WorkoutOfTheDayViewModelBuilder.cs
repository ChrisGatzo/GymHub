using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GymHub.Models;
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

        public WorkoutOfTheDayViewModelBuilder WithDataTableRows(IEnumerable<Trainee> activeUsers,
             IEnumerable<Exercise> exercisesOfTheDay, List<TraineeStatistic> activeUsersStatistics)
        {
            foreach (var activeUser in activeUsers)
            {
                var activeUserViewModel = Mapper.Map<TraineeViewModel>(activeUser);
                var user = activeUser;
                foreach (var activeUsersStatistic in activeUsersStatistics
                    .Where(activeUsersStatistic => activeUsersStatistic.TraineeId == user.Id))
                {
                    var traineeStatisticViewModel = Mapper.Map<TraineeStatisticViewModel>(activeUsersStatistic);
                    activeUserViewModel.TraineeStatisticViewModels.Add(traineeStatisticViewModel);
                }

                _workoutOfTheDayViewModel.ActiveTraineeViewModels.Add(activeUserViewModel);
            }

            foreach (var exercise in exercisesOfTheDay)
            {
                _workoutOfTheDayViewModel.ExerciseViewModels.Add(Mapper.Map<ExerciseViewModel>(exercise));
            }

            foreach (var activeTrainee in _workoutOfTheDayViewModel.ActiveTraineeViewModels)
            {
                var traineeRow = new List<string>();
                var editStatisticsColumn =
                    string.Format(
                        "<button type='button' class='btn-link edit-statistics' data-trainee-id={0}><span class='glyphicon glyphicon-pencil'></span></button>",
                        activeTrainee.Id);
                traineeRow.Add(editStatisticsColumn);

                var nameColumn = string.Format("{0} {1}", activeTrainee.LastName, activeTrainee.FirstName);
                traineeRow.Add(nameColumn);


                foreach (var exerciseViewModel in _workoutOfTheDayViewModel.ExerciseViewModels)
                {
                    var traineeStatisticViewModel =
                        activeTrainee.TraineeStatisticViewModels.SingleOrDefault(
                            m => m.ExerciseId == exerciseViewModel.Id);

                    var exerciseColumn = string.Format("");
                    if (traineeStatisticViewModel != null)
                    {
                        exerciseColumn = string.Format("{0} kg ({1})", traineeStatisticViewModel.Weight, traineeStatisticViewModel.Date.ToString("dd-MM-yyy"));
                    }

                    traineeRow.Add(exerciseColumn);
                }

                _workoutOfTheDayViewModel.DataTableRows.Add(traineeRow);

            }

            return this;
        }

        public WorkoutOfTheDayViewModel Build()
        {
            return _workoutOfTheDayViewModel;
        }
    }
}