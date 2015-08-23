using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class AthleteStatisticsRepository : GenericRepository<AthleteStatistic>, IAthleteStatisticsRepository
    {
        public AthleteStatisticsRepository(GymHubEntities context)
            : base(context)
        {

        }
    }
}