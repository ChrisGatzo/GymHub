using System.Collections.Generic;

namespace GymHub.Models.Domain
{
    public class Program
    {       
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TrainingSchedule> TrainingSchedules { get; set; }
    }
}