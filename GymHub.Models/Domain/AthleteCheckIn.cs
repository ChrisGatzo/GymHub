using System;

namespace GymHub.Models.Domain
{
    public class AthleteCheckIn
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public DateTime CheckInDateTime { get; set; }

        public virtual Athlete Athletes { get; set; }
    }
}