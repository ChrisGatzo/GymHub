namespace GymHub.Models.Domain
{
    public class TrainingSchedule
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int ProgramId { get; set; }
        public int ExerciseId { get; set; }

        public virtual Exercise Exercises { get; set; }
        public virtual Program Programs { get; set; }
    }
}