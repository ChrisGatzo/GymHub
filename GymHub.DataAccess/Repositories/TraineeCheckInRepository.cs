using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class TraineeCheckInRepository : GenericRepository<TraineeCheckIn>, ITraineeCheckInRepository
    {
        public TraineeCheckInRepository(GymHubEntities context)
            : base(context)
        {

        }

    }
}