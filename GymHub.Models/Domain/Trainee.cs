using System.Collections.Generic;

namespace GymHub.Models.Domain
{
    public class Trainee
    {       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string AspNetUserId { get; set; }

        public virtual ICollection<TraineeCheckIn> TraineeCheckIns { get; set; }
        public virtual ICollection<TraineeStatistic> TraineeStatistics { get; set; }
        //public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
