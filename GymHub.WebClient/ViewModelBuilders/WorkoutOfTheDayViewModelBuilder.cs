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
            IEnumerable<Athlete> activeAthletes, List<Exercise> exercisesOfTheDay)
        {

            foreach (var activeAthlete in activeAthletes)
            {
                var athleteRow = new List<string>();
                MapEditColumn(activeAthlete, athleteRow);
                MapNameColumn(activeAthlete, athleteRow);
                MapMostRecentStatisticColumn(exercisesOfTheDay, activeAthlete, athleteRow);
                _workoutOfTheDayViewModel.DataTableRows.Add(athleteRow);
            }

            return this;
        }
    
        public WorkoutOfTheDayViewModel Build()
        {
            return _workoutOfTheDayViewModel;
        }


        private static void MapMostRecentStatisticColumn(IEnumerable<Exercise> exercisesOfTheDay, Athlete activeAthlete, ICollection<string> athleteRow)
        {
            foreach (var exercise in exercisesOfTheDay)
            {
                var mostRecentStatistic =
                    activeAthlete.AthleteStatistics
                        .Where(m => m.ExerciseId == exercise.Id)
                        .OrderByDescending(m => m.Date)
                        .FirstOrDefault();

                var exerciseColumn = "";
                if (mostRecentStatistic != null)
                {
                    exerciseColumn = string.Format("{0} kg ({1})", mostRecentStatistic.Weight.ToString("0"),
                        mostRecentStatistic.Date.ToString("dd-MM-yyy"));
                }

                athleteRow.Add(exerciseColumn);
            }
        }

        private static void MapNameColumn(Athlete activeAthlete, ICollection<string> athleteRow)
        {
            var nameColumn = string.Format("{0} {1}", activeAthlete.FirstName, activeAthlete.LastName);
            athleteRow.Add(nameColumn);
        }

        private static void MapEditColumn(Athlete activeAthlete, ICollection<string> athleteRow)
        {
            var editStatisticsColumn =
                string.Format(
                    "<button type='button' class='btn-link edit-statistics' data-athlete-id={0}><span class='glyphicon glyphicon-pencil'></span></button>",
                    activeAthlete.Id);
            athleteRow.Add(editStatisticsColumn);
        }
    }
}