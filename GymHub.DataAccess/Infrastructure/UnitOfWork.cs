using System;
using GymHub.DataAccess.Repositories;

namespace GymHub.DataAccess.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GymHubEntities _context;
        private IAthleteRepository _athleteRepository;
        private IExerciseRepository _exerciseRepository;
        private IProgramRepository _programRepository;
        private IAthleteStatisticsRepository _athleteStatisticsRepository;
        private IAthleteCheckInRepository _athleteCheckInRepository;

        public UnitOfWork()
        {
            _context = new GymHubEntities();
        }

        public IAthleteRepository AthleteRepository
        {
            get
            {
                if (_athleteRepository == null)
                {
                    _athleteRepository = new AthleteRepository(_context);
                }
                return _athleteRepository;
            }
        }

        public IExerciseRepository ExerciseRepository
        {
            get
            {

                if (_exerciseRepository == null)
                {
                    _exerciseRepository = new ExerciseRepository(_context);
                }
                return _exerciseRepository;
            }
        }

        public IProgramRepository ProgramRepository
        {
            get
            {
                if (_programRepository == null)
                {
                    _programRepository = new ProgramRepository(_context);
                }
                return _programRepository;
            }
        }

        public IAthleteStatisticsRepository AthleteStatisticsRepository
        {
            get
            {
                if (_athleteStatisticsRepository == null)
                {
                    _athleteStatisticsRepository = new AthleteStatisticsRepository(_context);
                }

                return _athleteStatisticsRepository;
            }
        }

        public IAthleteCheckInRepository AthleteCheckInRepository
        {
            get
            {
                if (_athleteCheckInRepository == null)
                {
                    _athleteCheckInRepository = new AthleteCheckInRepository(_context);
                }

                return _athleteCheckInRepository;
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