using System.Data.Entity;
using GymHub.Models.Domain;

namespace GymHub.DataAccess
{
    public class GymHubEntities : DbContext
    {
        public GymHubEntities()
            : base("GymHubEntities")
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<TraineeCheckIn> TraineeCheckIns { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<TraineeStatistic> TraineeStatistics { get; set; }
        public DbSet<TrainingSchedule> TrainingSchedules { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //}        
    }
}