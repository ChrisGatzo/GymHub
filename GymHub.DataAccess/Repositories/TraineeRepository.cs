using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class TraineeRepository : GenericRepository<Trainee>, ITraineeRepository
    {
        public TraineeRepository(GymHubEntities context)
            : base(context)
        {

        }
    }
}
