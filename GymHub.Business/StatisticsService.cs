using System;
using System.Collections.Generic;
using System.Linq;
using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;
using GymHub.Service.DataTransferObjects;
using Microsoft.Ajax.Utilities;

namespace GymHub.Service
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatisticsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetActiveUsersStatisticsResponse GetActiveUsersStatistics(GetActiveUsersStatisticsRequest request)
        {
            var athleteStatistics = new List<AthleteStatistic>
            {
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 1,
                    Weight = 20,
                    Date = new DateTime(2014, 2, 2)
                },
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 2,
                    Weight = 30,
                    Date = new DateTime(2014, 2, 2)
                },
                new AthleteStatistic
                {
                    AthleteId = 2,
                    ExerciseId = 1,
                    Weight = 25,
                    Date = new DateTime(2014, 2, 2)
                },
                new AthleteStatistic
                {
                    AthleteId = 2,
                    ExerciseId = 2,
                    Weight = 25,
                    Date = new DateTime(2014, 2, 2)
                },
                new AthleteStatistic
                {
                    AthleteId = 2,
                    ExerciseId = 3,
                    Weight = 40,
                    Date = new DateTime(2014, 1, 28)
                }
            };

            var response = new GetActiveUsersStatisticsResponse
            {
                AthleteStatistics = athleteStatistics
            };

            return response;
        }

        public GetStatisticsForAthleteResponse GetStatisticsForAthlete(GetStatisticsForAthleteRequest request)
        {
            var athleteStatistics = new List<AthleteStatistic>
            {
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 1,
                    Weight = 20,
                    Date = new DateTime(2014, 1, 5)
                },
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 1,
                    Weight = 25,
                    Date = new DateTime(2014, 1, 8)
                },
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 1,
                    Weight = 25,
                    Date = new DateTime(2014, 1, 18)
                },
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 1,
                    Weight = 30,
                    Date = new DateTime(2014, 1, 30)
                },
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 2,
                    Weight = 25,
                    Date = new DateTime(2014, 1, 5)
                },
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 2,
                    Weight = 30,
                    Date = new DateTime(2014, 1, 7)
                },
                new AthleteStatistic
                {
                    AthleteId = 1,
                    ExerciseId = 3,
                    Weight = 14,
                    Date = new DateTime(2014, 1, 15)
                },
            };

            var response = new GetStatisticsForAthleteResponse
            {
                AthleteStatistics = athleteStatistics
            };

            return response;
        }

        public GetExercisesOfTheDayResponse GetExercisesOfTheDay(GetExercisesOfTheDayRequest request)
        {
            var exercises = _unitOfWork.ExerciseRepository.Get();

            var response = new GetExercisesOfTheDayResponse
            {
                Exercises = exercises
            };

            if (request.WithAthleteStatistics)
            {
                response.AthleteStatistics =
                    _unitOfWork
                    .AthleteStatisticsRepository
                    .Get(t => t.AthleteId == request.AthleteId);

                response.Athlete = _unitOfWork.AthleteRepository.GetById(request.AthleteId);
            }

            return response;
        }

        public GetExercisesPerformedByAthleteResponse GetExercisesPerformedByAthlete(GetExercisesPerformedByAthleteRequest request)
        {
            var exercises = new List<Exercise>();

            var athleteStatistics = _unitOfWork.AthleteStatisticsRepository.Get(m => m.AthleteId == request.AthleteId);

            var exercisesPerformedByUser = athleteStatistics.DistinctBy(m => m.ExerciseId).ToList();

            foreach (var exercise in exercisesPerformedByUser)
            {
                exercises.Add(new Exercise { Id = exercise.Exercises.Id, Name = exercise.Exercises.Name });
            }

            var response = new GetExercisesPerformedByAthleteResponse
            {
                Exercises = exercises
            };

            return response;
        }

        public UpdateAthleteStatisticsResponse UpdateAthleteStatistics(UpdateAthleteStatisticsRequest request)
        {
            foreach (var athleteStatistic in request.AthleteStatistics)
            {
                if (athleteStatistic.Id == 0 && athleteStatistic.Weight != 0)
                {
                    _unitOfWork.AthleteStatisticsRepository.Insert(athleteStatistic);
                }
                else if (athleteStatistic.Id != 0 && athleteStatistic.Weight != 0)
                {
                    _unitOfWork.AthleteStatisticsRepository.Update(athleteStatistic);
                }
                else if (athleteStatistic.Id != 0 && athleteStatistic.Weight == 0)
                {
                    _unitOfWork.AthleteStatisticsRepository.Delete(athleteStatistic);
                }
            }

            _unitOfWork.Save();

            var response = new UpdateAthleteStatisticsResponse();

            return response;
        }

    }
}