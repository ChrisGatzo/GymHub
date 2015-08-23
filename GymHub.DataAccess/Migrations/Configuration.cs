using GymHub.Models.Domain;

namespace GymHub.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GymHubEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GymHubEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Athletes.AddOrUpdate(
             t => t.Id,
              new Athlete
              {
                  Id = 1,
                  FirstName = "Chris",
                  LastName = "Gatzonis",
              },
               new Athlete
               {
                   Id = 2,
                   FirstName = "James",
                   LastName = "Papadopoulos",
               },
                new Athlete
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Smith"
                }
            );

            context.Exercises.AddOrUpdate(
                e => e.Id,
                new Exercise
                {
                    Id = 1,
                    Name = "Air squat"
                },
                new Exercise
                {
                    Id = 2,
                    Name = "Burpee"
                },
                new Exercise
                {
                    Id = 3,
                    Name = "Thruster"
                }
            );

        }
    }
}
