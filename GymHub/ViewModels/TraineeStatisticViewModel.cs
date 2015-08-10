﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GymHub.Resources;

namespace GymHub.ViewModels
{
    public class TraineeStatisticViewModel
    {
        //public TraineeStatisticViewModel()
        //{
        //    ExercisesList = new List<SelectListItem>();
        //}

        public int? Id { get; set; }
        
        public int TraineeId { get; set; }
        
        //[Display(Name = "Name", ResourceType = typeof(Strings))]
        //public string TraineeName { get; set; }
        
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