using GymHub.Models;

namespace GymHub.DataAccess.Repositories
{
    public class TraineeStatisticsRepository : GenericRepository<TraineeStatistic>, ITraineeStatisticsRepository
    {
        public TraineeStatisticsRepository(GymHubDBContext context)
            : base(context)
        {

        }
    }
}