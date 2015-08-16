using System;

namespace GymHub.Models.Domain
{
    public class TraineeCheckIn
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public DateTime CheckInDateTime { get; set; }

        public virtual Trainee Trainees { get; set; }
    }
}