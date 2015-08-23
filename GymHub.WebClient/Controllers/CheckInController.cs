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
        private readonly ITraineeService _traineeService;

        public CheckInController()
        {
            _traineeService = new TraineeService(new UnitOfWork(), new StatisticsService(new UnitOfWork()));
        }

        public IHttpActionResult Post([FromBody]int traineeId)
        {
            var request = new CheckInTraineeRequest
            {
                TraineeId = traineeId
            };

            var response = _traineeService.CheckInTrainee(request);

            ActiveTraineesHub.DispatchToClient();

            return Ok(Strings.TraineeCheckedInSuccessfully);
        }
    }
}
