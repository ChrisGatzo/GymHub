using System.Web.Mvc;
using GymHub.Business;
using GymHub.DataAccess;
using GymHub.Models.Helpers;
using GymHub.WebClient.ViewModelBuilders;

namespace GymHub.WebClient.Controllers
{
    public class WorkoutOfTheDayController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITraineeService _traineeService;
        private readonly IScheduleService _scheduleService;
        private readonly IStatisticsService _statisticsService;

        public WorkoutOfTheDayController(IUnitOfWork unitOfWork,
            ITraineeService traineeService,
            IScheduleService scheduleService,
            IStatisticsService statisticsService)
        {
            _unitOfWork = unitOfWork;
            _traineeService = traineeService;
            _scheduleService = scheduleService;
            _statisticsService = statisticsService;
        }

        public ActionResult ActiveTrainees()
        {
            var exercisesOfTheDay = _scheduleService.GetExercisesOfTheDay();

            var workoutOfTheDayViewModel =
                new WorkoutOfTheDayViewModelBuilder(_unitOfWork)
                    .WithValues(exercisesOfTheDay)
                    .Build();

            ViewBag.WorkoutOfTheDayActive = "active";
            return View(workoutOfTheDayViewModel);
        }

        public ActionResult ServerSideProcessing([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            requestModel.Draw++;

            var orderedEnumerable = requestModel.Columns.GetSortedColumns();

            var pagedTrainees = _traineeService.GetPagedTrainees(orderedEnumerable, requestModel.Start, requestModel.Length, requestModel.Search);
            var exercisesOfTheDay = _scheduleService.GetExercisesOfTheDay();
            var activeUsersStatistics = _statisticsService.GetActiveUsersStatistics(pagedTrainees, exercisesOfTheDay);

            var workoutOfTheDayViewModel =
                new WorkoutOfTheDayViewModelBuilder(_unitOfWork)
                    .WithDataTableRows(pagedTrainees, exercisesOfTheDay, activeUsersStatistics)
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