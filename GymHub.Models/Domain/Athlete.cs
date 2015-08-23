using System.Collections.Generic;

namespace GymHub.Models.Domain
{
    public class Athlete
    {       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        

        public virtual ICollection<AthleteCheckIn> AthleteCheckIns { get; set; }
        public virtual ICollection<AthleteStatistic> AthleteStatistics { get; set; }        
    }
}
