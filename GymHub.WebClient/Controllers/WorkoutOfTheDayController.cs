using System.Linq;
using System.Web.Mvc;
using GymHub.DataAccess;
using GymHub.Models.Helpers;
using GymHub.Service;
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

        public ActionResult ServerSideProcessing([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            requestModel.Draw++;

            var orderedEnumerable = requestModel.Columns.GetSortedColumns();

            var pagedTrainees = _traineeService.GetPagedTrainees(orderedEnumerable, requestModel.Start, requestModel.Length, requestModel.Search).ToList();
            var response = _statisticsService.GetExercisesOfTheDay(new GetExercisesOfTheDayRequest());
            var activeUsersStatistics = _statisticsService.GetActiveUsersStatistics(pagedTrainees, response.Exercises).ToList();

            var workoutOfTheDayViewModel =
                new WorkoutOfTheDayViewModelBuilder()
                    .WithDataTableRows(pagedTrainees, response.Exercises, activeUsersStatistics)
                    .Build();

            var recordsTotal = _traineeService.GetTraineesCount();
            var recordsFiltered = _traineeService.GetFilteredTraineesCount(requestModel.Search);
            var paged = workoutOfTheDayViewModel.DataTableRows;

            return Json(new DataTablesResponse(requestModel.Draw, paged, recordsFiltered, recordsTotal), JsonRequestBehavior.AllowGet);
        }


        //public ActionResult ServerSideProcessingB(int draw, IList<Dictionary<string, string>> columns,
        //                                        IList<Dictionary<string, string>> order,
        //                                        int start, int length, Dictionary<string, string> search, string _)
        //{
        //    draw++;

        //    var pagedTrainees = _traineeService.GetPagedTrainees(order, start, length, search);
        //    var exercisesOfTheDay = _scheduleService.GetExercisesOfTheDay();
        //    var activeUsersStatistics = _statisticsService.GetActiveUsersStatistics(pagedTrainees, exercisesOfTheDay);

        //    var workoutOfTheDayViewModel =
        //        new WorkoutOfTheDayViewModelBuilder(_unitOfWork)
        //            .WithDataTableRows(pagedTrainees, exercisesOfTheDay, activeUsersStatistics)
        //            .Build();

        //    var recordsTotal = _traineeService.GetTraineesCount();
        //    var recordsFiltered = _traineeService.GetFilteredTraineesCount(search);
        //    var data = workoutOfTheDayViewModel.DataTableRows;

        //    return Json(new { draw, recordsTotal, recordsFiltered, data }, JsonRequestBehavior.AllowGet);
        //}

    }

}