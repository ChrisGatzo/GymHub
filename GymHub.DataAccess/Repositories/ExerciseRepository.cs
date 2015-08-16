using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(GymHubEntities context)
            : base(context)
        {

        }
    }
}