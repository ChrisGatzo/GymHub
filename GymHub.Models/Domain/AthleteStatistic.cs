namespace GymHub.Models.Domain
{
    public class AthleteStatistic
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public int ExerciseId { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Weight { get; set; }

        public virtual Exercise Exercises { get; set; }
        public virtual Athlete Athletes { get; set; }
    }
}