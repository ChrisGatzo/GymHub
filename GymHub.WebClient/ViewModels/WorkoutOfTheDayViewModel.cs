using System.Collections.Generic;

namespace GymHub.WebClient.ViewModels
{
    public class WorkoutOfTheDayViewModel   
    {
        public WorkoutOfTheDayViewModel()
        {
            ActiveAthleteViewModels = new List<AthleteViewModel>();
            ExerciseViewModels = new List<ExerciseViewModel>();
            DataTableRows = new List<List<string>>();
        }

        public string CurrentTrainingDate { get; set; }
        public List<AthleteViewModel> ActiveAthleteViewModels { get; set; }
        public List<ExerciseViewModel> ExerciseViewModels { get; set; }
        public List<List<string>> DataTableRows { get; set; }
    }    
}