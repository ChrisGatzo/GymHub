using System.Collections.Generic;

namespace GymHub.WebClient.ViewModels
{
    public class TraineeViewModel
    {
        public TraineeViewModel()
        {
            TraineeStatisticViewModels = new List<TraineeStatisticViewModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TraineeStatisticViewModel> TraineeStatisticViewModels { get; set; }
    }
}