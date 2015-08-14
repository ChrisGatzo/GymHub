using GymHub.Models;

namespace GymHub.DataAccess.Repositories
{
    public class ProgramRepository : GenericRepository<Program>, IProgramRepository
    {
        public ProgramRepository(GymHubDBContext context)
            : base(context)
        {

        }
    }
}