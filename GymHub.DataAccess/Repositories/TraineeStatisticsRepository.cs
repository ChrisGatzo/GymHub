using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class TraineeStatisticsRepository : GenericRepository<TraineeStatistic>, ITraineeStatisticsRepository
    {
        public TraineeStatisticsRepository(GymHubEntities context)
            : base(context)
        {

        }
    }
}