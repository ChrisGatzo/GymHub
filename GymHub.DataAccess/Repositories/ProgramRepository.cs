using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;

namespace GymHub.DataAccess.Repositories
{
    public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        public ProgramRepository(GymHubEntities context)
            : base(context)
        {

        }
    }
}