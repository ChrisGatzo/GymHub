using System.Web.Http;
using GymHub.DataAccess.Infrastructure;
using GymHub.Service;
using GymHub.Service.DataTransferObjects;
using GymHub.WebClient.Hubs;
using GymHub.WebClient.Resources;

namespace GymHub.WebClient.Controllers
{
    public class CheckInController : ApiController
    {
        private readonly IAthleteService _athleteService;

        public CheckInController()
        {
            _athleteService = new AthleteService(new UnitOfWork(), new StatisticsService(new UnitOfWork()));
        }

        public IHttpActionResult Post([FromBody]int athleteId)
        {
            var request = new CheckInAthleteRequest
            {
                AthleteId = athleteId
            };

            var response = _athleteService.CheckInAthlete(request);

            ActiveAthletesHub.DispatchToClient();

            return Ok(Strings.AthleteCheckedInSuccessfully);
        }
    }
}
