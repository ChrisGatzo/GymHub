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

        public IEnumerable<Trainee> GetActiveTrainees()
        {
            IEnumerable<Trainee> allTrainees = _unitOfWork.TraineeRepository.Get();

            return allTrainees;

            //var activeUsers = new List<Trainee>
            //{
            //    new Trainee {Id = 1, FirstName = "Christos", LastName = "Gatzo"},
            //    new Trainee {Id = 2, FirstName = "Seb", LastName = "Kap"},
            //    new Trainee {Id = 3, FirstName = "Petros", LastName = "Papas"}
            //};

            //return activeUsers;
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

        public GetPagedTraineesResponse GetPagedTrainees(GetPagedTraineesRequest request)
        {
            var pagedTrainees = new List<Trainee>();
            IEnumerable<Exercise> exercises = new List<Exercise>();
            IEnumerable<TraineeStatistic> activeUsersStatistics = new List<TraineeStatistic>();

            switch (request.OrderByColumn)
            {
                case 1:
                    {
                        if (request.OrderDirection == OrderDirection.Ascendant)
                        {
                            pagedTrainees = _unitOfWork.TraineeRepository
                                .Get(q => q.FirstName.Contains(request.SearchValue) || q.LastName.Contains(request.SearchValue),
                                    q => q.OrderBy(p => p.LastName))
                                .Skip(request.Start).Take(request.Length)
                                .ToList();
                        }
                        if (request.OrderDirection == OrderDirection.Descendant)
                        {
                            pagedTrainees = _unitOfWork.TraineeRepository
                             .Get(q => q.FirstName.Contains(request.SearchValue) || q.LastName.Contains(request.SearchValue),
                                  q => q.OrderByDescending(p => p.LastName))
                             .Skip(request.Start).Take(request.Length)
                             .ToList();
                        }
                        break;
                    }
                default:
                    {
                        pagedTrainees = _unitOfWork.TraineeRepository.Get().ToList();
                        break;
                    }
            }

            if (request.WithExercises)
            {
                exercises = _statisticsService.GetExercisesOfTheDay(new GetExercisesOfTheDayRequest()).Exercises.ToList();
            }

            if (request.WithStatistics)
            {
                var activeUserRequest = new GetActiveUsersStatisticsRequest
                {
                    ActiveUsers = pagedTrainees,
                    ExercisesOfTheDay = exercises
                };
                var activeUserResponse = _statisticsService.GetActiveUsersStatistics(activeUserRequest);
                activeUsersStatistics = activeUserResponse.TraineeStatistics;
            }

            var recordsTotal = GetTraineesCount();
            var recordsFiltered = pagedTrainees.Count;

            var response = new GetPagedTraineesResponse
            {
                PagedTrainees = pagedTrainees,
                Exercises = exercises,
                TraineeStatistics = activeUsersStatistics,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered
            };

            return response;
        }

        private int GetTraineesCount()
        {
            return _unitOfWork.TraineeRepository.Get().Count();
        }

    }
}