using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using GymHub.Models.Domain;
using GymHub.Service;
using GymHub.Service.DataTransferObjects;
using GymHub.WebClient.Hubs;
using GymHub.WebClient.Resources;
using GymHub.WebClient.ViewModelBuilders;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private readonly IAthleteService _athleteService;


        public StatisticsController(
            IStatisticsService statisticsService,
            IAthleteService athleteService)
        {
            _statisticsService = statisticsService;
            _athleteService = athleteService;
        }

        public ActionResult AthleteStatistics(int athleteId)
        {
            var athleteStatisticViewModels = new List<AthleteStatisticViewModel>();

            var request = new GetExercisesOfTheDayRequest
            {
                WithAthleteStatistics = true,
                AthleteId = athleteId
            };
            var response = _statisticsService.GetExercisesOfTheDay(request);

            foreach (var exercise in response.Exercises)
            {
                var athleteStatisticForExercise = response.AthleteStatistics.FirstOrDefault(t => t.ExerciseId == exercise.Id);

                var athleteStatisticViewModel = new AthleteStatisticViewModelBuilder()
                    .WithDefaultValues(exercise)
                    .WithAthleteId(response.Athlete)
                    .WithWeight(athleteStatisticForExercise != null ? athleteStatisticForExercise.Weight : (decimal?)null)
                    .Build();

                athleteStatisticViewModels.Add(athleteStatisticViewModel);
            }

            ViewBag.AthleteName = response.Athlete.FirstName + " " + response.Athlete.LastName;
            return PartialView(athleteStatisticViewModels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AthleteStatistics(List<AthleteStatisticViewModel> athleteStatisticViewModels)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsValid = false, Message = Strings.ModelNotValid });
            }

            var athleteStatistics = Mapper.Map<List<AthleteStatisticViewModel>, List<AthleteStatistic>>(athleteStatisticViewModels);
            var request = new UpdateAthleteStatisticsRequest
            {
                AthleteStatistics = athleteStatistics
            };
            var response = _statisticsService.UpdateAthleteStatistics(request);

            ActiveAthletesHub.DispatchToClient();

            return Json(new { IsValid = true, Message = Strings.StatisticsSuccessfulSave });
        }

        public ActionResult Athletes()
        {
            var response = _athleteService.GetAllAthletes(new GetAllAthletesRequest());

            var athleteViewModels = Mapper.Map<List<Athlete>, List<AthleteViewModel>>(response.Athletes.ToList());

            ViewBag.StatisticsActive = "active";
            return View(athleteViewModels);
        }


        public ActionResult AthleteExercises(int id)
        {
            var request = new GetExercisesPerformedByAthleteRequest
            {
                AthleteId = id
            };
            var response = _statisticsService.GetExercisesPerformedByAthlete(request);

            var performedExercisesViewModel = Mapper.Map<List<Exercise>, List<ExerciseViewModel>>(response.Exercises.ToList());

            ViewBag.StatisticsActive = "active";
            ViewBag.AthleteId = id;
            return View(performedExercisesViewModel);
        }

        public ActionResult ExerciseGraph(int athleteId, int exerciseId)
        {
            var request = new GetStatisticsForAthleteRequest
            {
                AthleteId = athleteId,
                ExerciseId = exerciseId,
                DateFrom = new DateTime(),
                DateTo = new DateTime()
            };

            var response = _statisticsService.GetStatisticsForAthlete(request);

            var statisticsForAthleteViewModel = Mapper.Map<IEnumerable<AthleteStatistic>, IEnumerable<AthleteStatisticViewModel>>(response.AthleteStatistics);

            return View(statisticsForAthleteViewModel);
        }
    }
}