namespace GymHub.Models.Domain
{
    public class TraineeStatistic
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int ExerciseId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Weight { get; set; }

        public virtual Exercise Exercises { get; set; }
        public virtual Trainee Trainees { get; set; }
    }
}