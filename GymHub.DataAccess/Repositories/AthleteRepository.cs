using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class AthleteRepository : GenericRepository<Athlete>, IAthleteRepository
    {
        public AthleteRepository(GymHubEntities context)
            : base(context)
        {

        }
    }
}
