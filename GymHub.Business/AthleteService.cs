using System;
using System.Collections.Generic;
using System.Linq;
using GymHub.DataAccess.Infrastructure;
using GymHub.Models.Domain;
using GymHub.Models.Helpers;
using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public class AthleteService : IAthleteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStatisticsService _statisticsService;

        public AthleteService(IUnitOfWork unitOfWork, IStatisticsService statisticsService)
        {
            _unitOfWork = unitOfWork;
            _statisticsService = statisticsService;
        }

        public GetAllAthletesResponse GetAllAthletes(GetAllAthletesRequest request)
        {
            IEnumerable<Athlete> athletes = _unitOfWork.AthleteRepository.Get().ToList();

            var response = new GetAllAthletesResponse
            {
                Athletes = athletes
            };

            return response;
        }

        public GetFilteredAthletesResponse GetFilteredAthletes(GetFilteredAthletesRequest request)
        {
            var response = new GetFilteredAthletesResponse();

            var includeProperties = "";
            if (request.WithStatistics)
            {
                includeProperties = "AthleteStatistics";
            }

            var activeAthletes = GetActiveAthletes(includeProperties).Athletes.ToList();

            var filteredAthletesResponse = FilterAthletes(request, activeAthletes);

            response.FilteredAthletes = filteredAthletesResponse.PagedAthletes;
            response.RecordsTotal = filteredAthletesResponse.ActiveAthletesCount;
            response.RecordsFiltered = filteredAthletesResponse.PagedAthletesCount;

            if (request.WithExercisesOfTheDay)
            {
                response.ExercisesOfTheDay = GetExercisesOfTheDay();
            }
           
            return response;
        }

        public CheckInAthleteResponse CheckInAthlete(CheckInAthleteRequest request)
        {
            var athleteCheckIn = new AthleteCheckIn
            {
                AthleteId = request.AthleteId,
                CheckInDateTime = DateTime.Now,
            };

            _unitOfWork.AthleteCheckInRepository.Insert(athleteCheckIn);
            _unitOfWork.Save();

            var response = new CheckInAthleteResponse();

            return response;
        }

        public GetInactiveAthletesResponse GetInactiveAthletes(GetInactiveAthletesRequest request)
        {
            var inactiveAthletes =
              _unitOfWork.AthleteRepository
              .Get(t => t.AthleteCheckIns
                  .All(c => c.CheckInDateTime.Day != DateTime.Today.Day
                      || c.CheckInDateTime.Month != DateTime.Today.Month
                      || c.CheckInDateTime.Year != DateTime.Today.Year));


            return new GetInactiveAthletesResponse
            {
                InactiveAthletes = inactiveAthletes
            };
        }


        private GetActiveAthletesResponse GetActiveAthletes(string includeProperties = null)
        {
            var activeAthletes =
                _unitOfWork.AthleteRepository
                .Get(t => t.AthleteCheckIns
                    .Any(c => c.CheckInDateTime.Day == DateTime.Today.Day
                        && c.CheckInDateTime.Month == DateTime.Today.Month
                        && c.CheckInDateTime.Year == DateTime.Today.Year), includeProperties: includeProperties);

            var response = new GetActiveAthletesResponse
            {
                Athletes = activeAthletes
            };

            return response;
        }

        private IEnumerable<Exercise> GetExercisesOfTheDay()
        {
            return _statisticsService.GetExercisesOfTheDay(new GetExercisesOfTheDayRequest()).Exercises;
        }
       
        private static FilterAthletesResponse FilterAthletes(GetFilteredAthletesRequest request, List<Athlete> activeAthletes)
        {
            var filterAthletes = new List<Athlete>();

            switch (request.OrderByColumn)
            {
                case 1:
                    {
                        if (request.OrderDirection == OrderDirection.Ascendant)
                        {
                            filterAthletes = activeAthletes
                                .Where(q => q.FirstName.Contains(request.SearchValue) || q.LastName.Contains(request.SearchValue))
                                .OrderBy(p => p.LastName)
                                .Skip(request.Start)
                                .Take(request.Length)
                                .ToList();
                        }
                        if (request.OrderDirection == OrderDirection.Descendant)
                        {
                            filterAthletes = activeAthletes
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
                        filterAthletes = activeAthletes;
                        break;
                    }
            }

            return new FilterAthletesResponse
            {
                PagedAthletes = filterAthletes,
                PagedAthletesCount = filterAthletes.Count,
                ActiveAthletesCount = activeAthletes.Count
            };
        }

    }
}