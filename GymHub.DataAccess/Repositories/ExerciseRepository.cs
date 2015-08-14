using GymHub.Models;

namespace GymHub.DataAccess.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(GymHubDBContext context)
            : base(context)
        {

        }
    }
}