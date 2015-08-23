using System.Data.Entity;
using GymHub.Models.Domain;
using GymHub.DataAccess.Migrations;

namespace GymHub.DataAccess
{
    public class GymHubEntities : DbContext
    {
        public GymHubEntities()
            : base("GymHubEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GymHubEntities, Configuration>());
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<AthleteCheckIn> AthleteCheckIns { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<AthleteStatistic> AthleteStatistics { get; set; }
        public DbSet<TrainingSchedule> TrainingSchedules { get; set; }
        
    }
}