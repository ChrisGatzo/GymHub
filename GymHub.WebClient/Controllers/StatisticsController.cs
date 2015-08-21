using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using GymHub.Models.Domain;
using GymHub.Service;
using GymHub.Service.DataTransferObjects;
using GymHub.WebClient.Resources;
using GymHub.WebClient.ViewModelBuilders;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ITraineeService _traineeService;


        public StatisticsController(
            IStatisticsService statisticsService,
            ITraineeService traineeService)
        {
            _statisticsService = statisticsService;
            _traineeService = traineeService;
        }

        public ActionResult TraineeStatistics(int traineeId)
        {
            var traineeStatisticViewModels = new List<TraineeStatisticViewModel>();

            var request = new GetExercisesOfTheDayRequest
            {
                WithTraineeStatistics = true,
                TraineeId = traineeId
            };
            var response = _statisticsService.GetExercisesOfTheDay(request);

            foreach (var exercise in response.Exercises)
            {
                var traineeStatisticForExercise = response.TraineeStatistics.FirstOrDefault(t => t.ExerciseId == exercise.Id);

                var traineeStatisticViewModel = new TraineeStatisticViewModelBuilder()
                    .WithDefaultValues(exercise)
                    .WithTraineeId(response.Trainee)
                    .WithWeight(traineeStatisticForExercise != null ? traineeStatisticForExercise.Weight : (decimal?)null)
                    .Build();

                traineeStatisticViewModels.Add(traineeStatisticViewModel);
            }

            ViewBag.TraineeName = response.Trainee.LastName + " " + response.Trainee.FirstName;
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
            var request = new UpdateTraineeStatisticsRequest
            {
                TraineeStatistics = traineeStatistics
            };
            var response = _statisticsService.UpdateTraineeStatistics(request);

            return Json(new { IsValid = true, Message = Strings.StatisticsSuccessfulSave });
        }

        public ActionResult Trainees()
        {
            var response = _traineeService.GetAllTrainees(new GetAllTraineesRequest());

            var traineeViewModels = Mapper.Map<List<Trainee>, List<TraineeViewModel>>(response.Trainees.ToList());

            ViewBag.StatisticsActive = "active";
            return View(traineeViewModels);
        }


        public ActionResult TraineeExercises(int id)
        {
            var request = new GetExercisesPerformedByTraineeRequest
            {
                TraineeId = id
            };
            var response = _statisticsService.GetExercisesPerformedByTrainee(request);

            var performedExercisesViewModel = Mapper.Map<List<Exercise>, List<ExerciseViewModel>>(response.Exercises.ToList());

            ViewBag.StatisticsActive = "active";
            ViewBag.TraineeId = id;
            return View(performedExercisesViewModel);
        }

        public ActionResult ExerciseGraph(int traineeId, int exerciseId)
        {
            var request = new GetStatisticsForTraineeRequest
            {
                TraineeId = traineeId,
                ExerciseId = exerciseId,
                DateFrom = new DateTime(),
                DateTo = new DateTime()
            };

            var response = _statisticsService.GetStatisticsForTrainee(request);

            var statisticsForTraineeViewModel = Mapper.Map<IEnumerable<TraineeStatistic>, IEnumerable<TraineeStatisticViewModel>>(response.TraineeStatistics);

            return View(statisticsForTraineeViewModel);
        }
    }
}