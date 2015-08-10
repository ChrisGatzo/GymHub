using System.Collections.Generic;

namespace GymHub.ViewModels
{
    public class WorkoutOfTheDayViewModel   
    {
        public WorkoutOfTheDayViewModel()
        {
            ActiveTraineeViewModels = new List<TraineeViewModel>();
            ExerciseViewModels = new List<ExerciseViewModel>();
            DataTableRows = new List<List<string>>();
        }

        public string CurrentTrainingDate { get; set; }
        public List<TraineeViewModel> ActiveTraineeViewModels { get; set; }
        public List<ExerciseViewModel> ExerciseViewModels { get; set; }
        public List<List<string>> DataTableRows { get; set; }
    }    
}