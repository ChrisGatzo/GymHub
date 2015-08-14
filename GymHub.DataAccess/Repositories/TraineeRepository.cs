using GymHub.Models;

namespace GymHub.DataAccess.Repositories
{
    public class TraineeRepository : GenericRepository<Trainee>, ITraineeRepository
    {
        public TraineeRepository(GymHubDBContext context)
            : base(context)
        {

        }
    }
}
