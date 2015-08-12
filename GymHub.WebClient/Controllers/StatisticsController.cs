using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using GymHub.Business;
using GymHub.DataAccess;
using GymHub.DataAccess.DomainModels;
using GymHub.WebClient.Resources;
using GymHub.WebClient.ViewModelBuilders;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticsService _statisticsService;
        private readonly IScheduleService _scheduleService;
        private readonly ITraineeService _traineeService;


        public StatisticsController(IUnitOfWork unitOfWork,
            IStatisticsService statisticsService,
            IScheduleService scheduleService,
            ITraineeService traineeService)
        {
            _unitOfWork = unitOfWork;
            _statisticsService = statisticsService;
            _scheduleService = scheduleService;
            _traineeService = traineeService;
        }

        public ActionResult TraineeStatistics(int traineeId)
        {
            var trainee = new Trainee() { Id = traineeId, FirstName = "Chris", LastName = "Gatzo" };
            //var trainee = _unitOfWork.TraineeRepository.GetById(traineeId);
            if (trainee == null)
            {
                //TODO: fix to return 404 in ajax call
                // return new HttpNotFoundResult();
            }

            var traineeStatisticViewModels = new List<TraineeStatisticViewModel>();
            var exercisesOfTheDay = _scheduleService.GetExercisesOfTheDay();

            foreach (var exercise in exercisesOfTheDay)
            {
                var traineeStatisticViewModel = new TraineeStatisticViewModelBuilder()
                    .WithDefaultValues(exercise)
                    .WithTraineeId(trainee)
                    .Build();

                traineeStatisticViewModels.Add(traineeStatisticViewModel);
            }

            ViewBag.TraineeName = trainee.LastName + " " + trainee.FirstName;
            return PartialView(traineeStatisticViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult TraineeStatistics(List<TraineeStatisticViewModel> traineeStatisticViewModels)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsValid = false, Message = Strings.ModelNotValid });
            }

            var traineeStatistics = Mapper.Map<List<TraineeStatisticViewModel>, List<TraineeStatistic>>(traineeStatisticViewModels);
            _statisticsService.UpdateTraineeStatistics(traineeStatistics);

            return Json(new { IsValid = true, Message = Strings.SuccessfulSave });
        }

        public ActionResult Trainees()
        {
            var trainees = _traineeService.GetAllTrainees();

            var traineeViewModels = Mapper.Map<List<Trainee>, List<TraineeViewModel>>(trainees);


            ViewBag.StatisticsActive = "active";
            return View(traineeViewModels);
        }


        public ActionResult TraineeExercises(int id)
        {
            var performedExercises = _statisticsService.GetExercisesPerformedByTrainee(id);

            var performedExercisesViewModel = Mapper.Map<List<Exercise>, List<ExerciseViewModel>>(performedExercises);

            ViewBag.StatisticsActive = "active";
            ViewBag.TraineeId = id;
            return View(performedExercisesViewModel);
        }

        public ActionResult ExerciseGraph(int traineeId, int exerciseId)
        {
            var statisticsForTrainee = _statisticsService.GetStatisticsForTrainee(traineeId, exerciseId, new DateTime(), new DateTime());

            var statisticsForTraineeViewModel = Mapper.Map<List<TraineeStatistic>, List<TraineeStatisticViewModel>>(statisticsForTrainee);

            return View(statisticsForTraineeViewModel);
        }
    }
}