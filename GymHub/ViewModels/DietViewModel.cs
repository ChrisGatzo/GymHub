using System;

namespace GymHub.ViewModels
{
    public class DietViewModel
    {
        public int TraineeId { get; set; }

        public string FileName { get; set; }

        public DateTime UploadDate { get; set; }

        public string Comment { get; set; }
    }
}