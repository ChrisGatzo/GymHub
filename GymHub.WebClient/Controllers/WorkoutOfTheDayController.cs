using System.Linq;
using System.Web.Mvc;
using GymHub.Models.Helpers;
using GymHub.Service;
using GymHub.Service.DataTransferObjects;
using GymHub.WebClient.Models;
using GymHub.WebClient.ViewModelBuilders;

namespace GymHub.WebClient.Controllers
{
    public class WorkoutOfTheDayController : Controller
    {
        private readonly ITraineeService _traineeService;
        private readonly IStatisticsService _statisticsService;

        public WorkoutOfTheDayController(
            ITraineeService traineeService,
            IStatisticsService statisticsService)
        {
            _traineeService = traineeService;
            _statisticsService = statisticsService;
        }

        public ActionResult ActiveTrainees()
        {
            var request = new GetExercisesOfTheDayRequest();
            var response = _statisticsService.GetExercisesOfTheDay(request);

            var workoutOfTheDayViewModel =
                new WorkoutOfTheDayViewModelBuilder()
                    .WithValues(response.Exercises)
                    .Build();

            ViewBag.WorkoutOfTheDayActive = "active";
            return View(workoutOfTheDayViewModel);
        }

        public ActionResult ActiveTraineesPaging([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            requestModel.Draw++;

            var orderedEnumerable = requestModel.Columns.GetSortedColumns();
            var orderByColumn = int.Parse(orderedEnumerable.First().Data);
            var orderDirection = orderedEnumerable.First().SortDirection == 0 ? OrderDirection.Ascendant : OrderDirection.Descendant;
            var searchValue = requestModel.Search.Value;

            var request = new GetPagedTraineesRequest
            {
                OrderByColumn = orderByColumn,
                OrderDirection = orderDirection,
                SearchValue = searchValue,
                Start = requestModel.Start,
                Length = requestModel.Length,
                WithExercises = true,
                WithStatistics = true
            };

            var response = _traineeService.GetPagedTrainees(request);

            var workoutOfTheDayViewModel =
                new WorkoutOfTheDayViewModelBuilder()
                    .WithDataTableRows(response.PagedTrainees, response.Exercises, response.TraineeStatistics.ToList())
                    .Build();

            var recordsTotal = response.RecordsTotal;  
            var recordsFiltered = response.RecordsFiltered; 
            var paged = workoutOfTheDayViewModel.DataTableRows;

            return Json(new DataTablesResponse(requestModel.Draw, paged, recordsFiltered, recordsTotal), JsonRequestBehavior.AllowGet);
        }

    }

}