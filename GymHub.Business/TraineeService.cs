using System;
using System.Collections.Generic;
using System.Linq;
using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;
using GymHub.Models.Helpers;
using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public class TraineeService : ITraineeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticsService _statisticsService;

        public TraineeService(IUnitOfWork unitOfWork, IStatisticsService statisticsService)
        {
            _unitOfWork = unitOfWork;
            _statisticsService = statisticsService;
        }

        public GetAllTraineesResponse GetAllTrainees(GetAllTraineesRequest request)
        {
            IEnumerable<Trainee> trainees = _unitOfWork.TraineeRepository.Get().ToList();

            var response = new GetAllTraineesResponse
            {
                Trainees = trainees
            };

            return response;
        }

        public GetFilteredTraineesResponse GetFilteredTrainees(GetFilteredTraineesRequest request)
        {
            var response = new GetFilteredTraineesResponse();

            var includeProperties = "";
            if (request.WithStatistics)
            {
                includeProperties = "TraineeStatistics";
            }

            var activeTrainees = GetActiveTrainees(includeProperties).Trainees.ToList();

            var filteredTraineesResponse = FilterTrainees(request, activeTrainees);

            response.FilteredTrainees = filteredTraineesResponse.PagedTrainees;
            response.RecordsTotal = filteredTraineesResponse.ActiveTraineesCount;
            response.RecordsFiltered = filteredTraineesResponse.PagedTraineesCount;

            if (request.WithExercisesOfTheDay)
            {
                response.ExercisesOfTheDay = GetExercisesOfTheDay();
            }
           
            return response;
        }

        public CheckInTraineeResponse CheckInTrainee(CheckInTraineeRequest request)
        {
            var traineeCheckIn = new TraineeCheckIn
            {
                TraineeId = request.TraineeId,
                CheckInDateTime = DateTime.Now,
            };

            _unitOfWork.TraineeCheckInRepository.Insert(traineeCheckIn);
            _unitOfWork.Save();

            var response = new CheckInTraineeResponse();

            return response;
        }

        public GetInactiveTraineesResponse GetInactiveTrainees(GetInactiveTraineesRequest request)
        {
            var inactiveTrainees =
              _unitOfWork.TraineeRepository
              .Get(t => t.TraineeCheckIns
                  .All(c => c.CheckInDateTime.Day != DateTime.Today.Day
                      || c.CheckInDateTime.Month != DateTime.Today.Month
                      || c.CheckInDateTime.Year != DateTime.Today.Year));


            return new GetInactiveTraineesResponse
            {
                InactiveTrainees = inactiveTrainees
            };
        }


        private GetActiveTraineesResponse GetActiveTrainees(string includeProperties = null)
        {
            var activeTrainees =
                _unitOfWork.TraineeRepository
                .Get(t => t.TraineeCheckIns
                    .Any(c => c.CheckInDateTime.Day == DateTime.Today.Day
                        && c.CheckInDateTime.Month == DateTime.Today.Month
                        && c.CheckInDateTime.Year == DateTime.Today.Year), includeProperties: includeProperties);

            var response = new GetActiveTraineesResponse
            {
                Trainees = activeTrainees
            };

            return response;
        }

        private IEnumerable<Exercise> GetExercisesOfTheDay()
        {
            return _statisticsService.GetExercisesOfTheDay(new GetExercisesOfTheDayRequest()).Exercises;
        }
       
        private static FilterTraineesResponse FilterTrainees(GetFilteredTraineesRequest request, List<Trainee> activeTrainees)
        {
            var filterTrainees = new List<Trainee>();

            switch (request.OrderByColumn)
            {
                case 1:
                    {
                        if (request.OrderDirection == OrderDirection.Ascendant)
                        {
                            filterTrainees = activeTrainees
                                .Where(q => q.FirstName.Contains(request.SearchValue) || q.LastName.Contains(request.SearchValue))
                                .OrderBy(p => p.LastName)
                                .Skip(request.Start)
                                .Take(request.Length)
                                .ToList();
                        }
                        if (request.OrderDirection == OrderDirection.Descendant)
                        {
                            filterTrainees = activeTrainees
                                .Where(q => q.FirstName.Contains(request.SearchValue) || q.LastName.Contains(request.SearchValue))
                                .OrderByDescending(p => p.LastName)
                                .Skip(request.Start)
                                .Take(request.Length)
                                .ToList();
                        }
                        break;
                    }
                default:
                    {
                        filterTrainees = activeTrainees;
                        break;
                    }
            }

            return new FilterTraineesResponse
            {
                PagedTrainees = filterTrainees,
                PagedTraineesCount = filterTrainees.Count,
                ActiveTraineesCount = activeTrainees.Count
            };
        }

    }
}