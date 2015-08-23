using System.Collections.Generic;

namespace GymHub.WebClient.ViewModels
{
    public class AthleteViewModel
    {
        public AthleteViewModel()
        {
            AthleteStatisticViewModels = new List<AthleteStatisticViewModel>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<AthleteStatisticViewModel> AthleteStatisticViewModels { get; set; }
    }
}