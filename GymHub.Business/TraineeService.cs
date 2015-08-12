using System.Collections.Generic;
using System.Linq;
using GymHub.DataAccess;
using GymHub.DataAccess.DomainModels;
using GymHub.Models.Helpers;

namespace GymHub.Business
{
    public class TraineeService : ITraineeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TraineeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Trainee> GetActiveTrainees()
        {
            var activeUsers = new List<Trainee>
            {
                new Trainee {Id = 1, FirstName = "Christos", LastName = "Gatzo"},
                new Trainee {Id = 2, FirstName = "Seb", LastName = "Kap"},
                new Trainee {Id = 3, FirstName = "Petros", LastName = "Papas"}
            };

            return activeUsers;
        }

        public List<Trainee> GetAllTrainees()
        {
            //TODO: Insert user to db and uncomment below line.
             //return _unitOfWork.TraineeRepository.Get().ToList();

            var allUsers = new List<Trainee>
            {
                new Trainee {Id = 1, FirstName = "Christos", LastName = "Gatzo"},
                new Trainee {Id = 2, FirstName = "Seb", LastName = "Kap"},
                new Trainee {Id = 3, FirstName = "Petros", LastName = "Papas"},
                new Trainee {Id = 4, FirstName = "Kostas", LastName = "Tipotas"},
                new Trainee {Id = 5, FirstName = "Giannis", LastName = "Maniatis"},
                new Trainee {Id = 6, FirstName = "Kostas", LastName = "Mitroglou"},
                new Trainee {Id = 7, FirstName = "Alexander", LastName = "D' Agol"},
                new Trainee {Id = 8, FirstName = "Demis", LastName = "Nikolaidis"},
                new Trainee {Id = 9, FirstName = "Ivan", LastName = "Bresevic"},
                new Trainee {Id = 10, FirstName = "Dimitris", LastName = "Melissanidis"},
                new Trainee {Id = 11, FirstName = "Peter", LastName = "Sanders"},
                new Trainee {Id = 12, FirstName = "Nikos", LastName = "Lumperopoulos"},
                new Trainee {Id = 13, FirstName = "Panagiotis", LastName = "Kone"}
            };

            return allUsers;
        }

        public List<Trainee> GetPagedTrainees(IOrderedEnumerable<Column> order, int start, int length, Search search)
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