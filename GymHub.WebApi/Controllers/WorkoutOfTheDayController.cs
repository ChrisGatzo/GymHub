using System.Web.Http;
using GymHub.Service;
using GymHub.Service.DataTransferObjects;

namespace GymHub.WebApi.Controllers
{
    [RoutePrefix("api/workoutOfTheDay")]
    public class WorkoutOfTheDayController : ApiController
    {
        private readonly IAthleteService _athleteService;
        private readonly IStatisticsService _statisticsService;

        public WorkoutOfTheDayController(
            IAthleteService athleteService,
            IStatisticsService statisticsService)
        {
            _athleteService = athleteService;
            _statisticsService = statisticsService;
        }

        [Route("InactiveAthletes")]
        public IHttpActionResult GetInactiveAthletes()
        {
            var request = new GetInactiveAthletesRequest();

            var inactiveAthletes =
                _athleteService
                .GetInactiveAthletes(request)
                .InactiveAthletes;

            return Ok(inactiveAthletes);
        }

        [Route("ActiveAthletes")]
        public IHttpActionResult GetActiveAthletes()
        {

            var request = new GetFilteredAthletesRequest
            {
                //OrderByColumn = orderByColumn,
                //OrderDirection = orderDirection,
                //SearchValue = searchValue,
                //Start = requestModel.Start,
                //Length = requestModel.Length,
                WithExercisesOfTheDay = true,
                WithStatistics = true
            };

            var response = _athleteService.GetFilteredAthletes(request);

            return Ok(response);
        }

        public IHttpActionResult AthleteCheckIn([FromBody]int athleteId)
        {
            var request = new CheckInAthleteRequest
            {
                AthleteId = athleteId
            };

            var response = _athleteService.CheckInAthlete(request);

            //TODO: Enable SingnalR.
            //ActiveAthletesHub.DispatchToClient();

            return Ok("Athlete Checked In Successfully");
        }
    }
}