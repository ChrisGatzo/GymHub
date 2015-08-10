using System;
using GymHub.App_Start;
using GymHub.DataAccess.DomainModels;

namespace GymHub.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GymHubDBContext _context = new GymHubDBContext();
        private GenericRepository<Trainee> _traineeRepository;
        private GenericRepository<Program> _exerciseRepository;
        private GenericRepository<TraineeStatistic> _traineeStatisticsRepository;

        public IGenericRepository<Trainee> TraineeRepository
        {
            get
            {
                if (_traineeRepository == null)
                {
                    _traineeRepository = new GenericRepository<Trainee>(_context);
                }
                return _traineeRepository;
            }
        }

        public IGenericRepository<Program> ExerciseRepository
        {
            get
            {
                if (_exerciseRepository == null)
                {
                    _exerciseRepository = new GenericRepository<Program>(_context);
                }
                return _exerciseRepository;
            }
        }

        public IGenericRepository<TraineeStatistic> TraineeStatisticsRepository
        {
            get
            {
                if (_traineeStatisticsRepository == null)
                {
                    _traineeStatisticsRepository = new GenericRepository<TraineeStatistic>(_context);
                }

                return _traineeStatisticsRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}