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
            var traineeStatistics = new List<TraineeStatistic>
            {
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 1,
                    Weight = 20,
                    Date = new DateTime(2014, 2, 2)
                },
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 2,
                    Weight = 30,
                    Date = new DateTime(2014, 2, 2)
                },
                new TraineeStatistic
                {
                    TraineeId = 2,
                    ExerciseId = 1,
                    Weight = 25,
                    Date = new DateTime(2014, 2, 2)
                },
                new TraineeStatistic
                {
                    TraineeId = 2,
                    ExerciseId = 2,
                    Weight = 25,
                    Date = new DateTime(2014, 2, 2)
                },
                new TraineeStatistic
                {
                    TraineeId = 2,
                    ExerciseId = 3,
                    Weight = 40,
                    Date = new DateTime(2014, 1, 28)
                }
            };

            var response = new GetActiveUsersStatisticsResponse
            {
                TraineeStatistics = traineeStatistics
            };

            return response;
        }

        public GetStatisticsForTraineeResponse GetStatisticsForTrainee(GetStatisticsForTraineeRequest request)
        {
            var traineeStatistics = new List<TraineeStatistic>
            {
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 1,
                    Weight = 20,
                    Date = new DateTime(2014, 1, 5)
                },
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 1,
                    Weight = 25,
                    Date = new DateTime(2014, 1, 8)
                },
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 1,
                    Weight = 25,
                    Date = new DateTime(2014, 1, 18)
                },
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 1,
                    Weight = 30,
                    Date = new DateTime(2014, 1, 30)
                },
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 2,
                    Weight = 25,
                    Date = new DateTime(2014, 1, 5)
                },
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 2,
                    Weight = 30,
                    Date = new DateTime(2014, 1, 7)
                },
                new TraineeStatistic
                {
                    TraineeId = 1,
                    ExerciseId = 3,
                    Weight = 14,
                    Date = new DateTime(2014, 1, 15)
                },
            };

            var response = new GetStatisticsForTraineeResponse
            {
                TraineeStatistics = traineeStatistics
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

            if (request.WithTraineeStatistics)
            {
                response.TraineeStatistics =
                    _unitOfWork
                    .TraineeStatisticsRepository
                    .Get(t => t.TraineeId == request.TraineeId);

                response.Trainee = _unitOfWork.TraineeRepository.GetById(request.TraineeId);
            }

            return response;
        }

        public GetExercisesPerformedByTraineeResponse GetExercisesPerformedByTrainee(GetExercisesPerformedByTraineeRequest request)
        {
            var exercises = new List<Exercise>();

            var traineeStatistics = _unitOfWork.TraineeStatisticsRepository.Get(m => m.TraineeId == request.TraineeId);

            var exercisesPerformedByUser = traineeStatistics.DistinctBy(m => m.ExerciseId).ToList();

            foreach (var exercise in exercisesPerformedByUser)
            {
                exercises.Add(new Exercise { Id = exercise.Exercises.Id, Name = exercise.Exercises.Name });
            }

            var response = new GetExercisesPerformedByTraineeResponse
            {
                Exercises = exercises
            };

            return response;
        }

        public UpdateTraineeStatisticsResponse UpdateTraineeStatistics(UpdateTraineeStatisticsRequest request)
        {
            foreach (var traineeStatistic in request.TraineeStatistics)
            {
                if (traineeStatistic.Id == 0 && traineeStatistic.Weight != 0)
                {
                    _unitOfWork.TraineeStatisticsRepository.Insert(traineeStatistic);
                }
                else if (traineeStatistic.Id != 0 && traineeStatistic.Weight != 0)
                {
                    _unitOfWork.TraineeStatisticsRepository.Update(traineeStatistic);
                }
                else if (traineeStatistic.Id != 0 && traineeStatistic.Weight == 0)
                {
                    _unitOfWork.TraineeStatisticsRepository.Delete(traineeStatistic);
                }
            }

            _unitOfWork.Save();

            var response = new UpdateTraineeStatisticsResponse();

            return response;
        }

    }
}