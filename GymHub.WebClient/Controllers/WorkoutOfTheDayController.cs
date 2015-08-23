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
        private readonly IAthleteService _athleteService;
        private readonly IStatisticsService _statisticsService;

        public WorkoutOfTheDayController(
            IAthleteService athleteService,
            IStatisticsService statisticsService)
        {
            _athleteService = athleteService;
            _statisticsService = statisticsService;
        }

        public ActionResult ActiveAthletes()
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

        public ActionResult ActiveAthletesPaging([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            requestModel.Draw++;

            var orderedEnumerable = requestModel.Columns.GetSortedColumns();
            var orderByColumn = int.Parse(orderedEnumerable.First().Data);
            var orderDirection = orderedEnumerable.First().SortDirection == 0 ? OrderDirection.Ascendant : OrderDirection.Descendant;
            var searchValue = requestModel.Search.Value;

            var request = new GetFilteredAthletesRequest
            {
                OrderByColumn = orderByColumn,
                OrderDirection = orderDirection,
                SearchValue = searchValue,
                Start = requestModel.Start,
                Length = requestModel.Length,
                WithExercisesOfTheDay = true,
                WithStatistics = true
            };

            var response = _athleteService.GetFilteredAthletes(request);

            var workoutOfTheDayViewModel =
                new WorkoutOfTheDayViewModelBuilder()
                    .WithDataTableRows(response.FilteredAthletes, response.ExercisesOfTheDay.ToList())
                    .Build();

            var recordsTotal = response.RecordsTotal;
            var recordsFiltered = response.RecordsFiltered;
            var paged = workoutOfTheDayViewModel.DataTableRows;

            return Json(new DataTablesResponse(requestModel.Draw, paged, recordsFiltered, recordsTotal), JsonRequestBehavior.AllowGet);
        }

        public ActionResult InactiveAthletes()
        {
            var inactiveAthletes = _athleteService.GetInactiveAthletes(new GetInactiveAthletesRequest()).InactiveAthletes.ToList();

            return PartialView(inactiveAthletes);
        }

    }

}