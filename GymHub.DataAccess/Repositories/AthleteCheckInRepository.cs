using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class AthleteCheckInRepository : GenericRepository<AthleteCheckIn>, IAthleteCheckInRepository
    {
        public AthleteCheckInRepository(GymHubEntities context)
            : base(context)
        {

        }

    }
}