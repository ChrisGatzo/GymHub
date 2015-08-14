﻿using System;
using System.Collections.Generic;
using System.Linq;
using GymHub.DataAccess;
using GymHub.Models;
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

        public IEnumerable<TraineeStatistic> GetActiveUsersStatistics(IEnumerable<Trainee> activeUsers, IEnumerable<Exercise> exercisesOfTheDay)
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

            return traineeStatistics;
        }

        public IEnumerable<TraineeStatistic> GetStatisticsForTrainee(int traineeId, int exerciseId, DateTime dateFrom, DateTime dateTo)
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

            return traineeStatistics;
        }

        public IEnumerable<Exercise> GetExercisesPerformedByTrainee(int traineeId)
        {
            var exercises = new List<Exercise>();

            var traineeStatistics = _unitOfWork.TraineeStatisticsRepository.Get(m => m.TraineeId == traineeId);

            var exercisesPerformedByUser = traineeStatistics.DistinctBy(m => m.ExerciseId).ToList();

            foreach (var exercise in exercisesPerformedByUser)
            {
                exercises.Add(new Exercise{Id = exercise.Exercises.Id, Name = exercise.Exercises.Name});
            }

            return exercises;
        }

        public void UpdateTraineeStatistics(IEnumerable<TraineeStatistic> traineeStatistics)
        {
            foreach (var traineeStatistic in traineeStatistics)
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

                //_unitOfWork.Save();
            }
        }

    }
}