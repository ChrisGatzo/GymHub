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
            context.Trainees.AddOrUpdate(
             t => t.Id,
              new Trainee {
                    Id = 1,
                    FirstName = "Chris",
                    LastName = "Gatzonis",
                },
               new Trainee {
                    Id = 2,
                    FirstName = "James",
                    LastName = "Papadopoulos",
                },
                new Trainee {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Smith"
                }           
            );
            
        }
    }
}
