using System;

namespace GymHub.WebClient.ViewModels
{
    public class DietViewModel
    {
        public int AthleteId { get; set; }

        public string FileName { get; set; }

        public DateTime UploadDate { get; set; }

        public string Comment { get; set; }
    }
}