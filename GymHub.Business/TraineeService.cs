using System.Collections.Generic;
using System.Linq;
using GymHub.DataAccess;
using GymHub.DataAccess.Infrastructure;
using GymHub.Models;
using GymHub.Models.Domain;
using GymHub.Models.Helpers;

namespace GymHub.Service
{
    public class TraineeService : ITraineeService
    {        
        private readonly IUnitOfWork _unitOfWork;

        public TraineeService(IUnitOfWork unitOfWork)
        {            
            _unitOfWork = unitOfWork;
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

        public IEnumerable<Trainee> GetPagedTrainees(IOrderedEnumerable<Column> order, int start, int length, Search search)
        {
            var orderByColumn = int.Parse(order.First().Data);
            var orderDirection = order.First().SortDirection;
            var searchValue = search.Value;

            switch (orderByColumn)
            {
                case 1:
                    {
                        if (orderDirection == Column.OrderDirection.Ascendant)
                        {
                            return _unitOfWork.TraineeRepository
                                .Get(q => q.FirstName.Contains(searchValue) || q.LastName.Contains(searchValue),
                                     q => q.OrderBy(p => p.LastName))
                                .Skip(start).Take(length)
                                .ToList();
                        }
                        if (orderDirection == Column.OrderDirection.Descendant)
                        {
                            return _unitOfWork.TraineeRepository
                             .Get(q => q.FirstName.Contains(searchValue) || q.LastName.Contains(searchValue),
                                  q => q.OrderByDescending(p => p.LastName))
                             .Skip(start).Take(length)
                             .ToList();
                        }
                    }
                    break;
            }

            return _unitOfWork.TraineeRepository.Get().ToList();
        }

        public int GetTraineesCount()
        {
            return _unitOfWork.TraineeRepository.Get().Count();
        }

        public int GetFilteredTraineesCount(Search search)
        {
            var searchValue = search.Value;
            return _unitOfWork.TraineeRepository.Get(q => q.FirstName.Contains(searchValue) || q.LastName.Contains(searchValue)).Count();
        }

    }
}