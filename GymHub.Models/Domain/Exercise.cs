using System.Collections.Generic;

namespace GymHub.Models.Domain
{
    public class Exercise
    {        
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AthleteStatistic> AthleteStatistics { get; set; }
        public virtual ICollection<TrainingSchedule> TrainingSchedules { get; set; }
    }
}