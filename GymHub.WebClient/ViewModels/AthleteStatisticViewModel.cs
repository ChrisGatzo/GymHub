using System.ComponentModel.DataAnnotations;
using GymHub.WebClient.Resources;

namespace GymHub.WebClient.ViewModels
{
    public class AthleteStatisticViewModel
    {
        //public AthleteStatisticViewModel()
        //{
        //    ExercisesList = new List<SelectListItem>();
        //}

        public int? Id { get; set; }
        
        public int AthleteId { get; set; }
        
        //[Display(Name = "Name", ResourceType = typeof(Strings))]
        //public string AthleteName { get; set; }
        
        [Display(Name = "Exercise", ResourceType = typeof(Strings))]
        public int ExerciseId { get; set; }

        public string ExerciseName { get; set; }

        [Display(Name = "Date", ResourceType = typeof(Strings))]
        public System.DateTime Date { get; set; }
        
        [Display(Name = "Weight", ResourceType = typeof(Strings))]
        public decimal? Weight { get; set; }

        //public List<SelectListItem> ExercisesList { get; set; }
    }
}