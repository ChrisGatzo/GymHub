﻿using System;
using GymHub.DataAccess.Repositories;
using GymHub.Models;

namespace GymHub.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly GymHubDBContext _context;
        private ITraineeRepository _traineeRepository;
        private IExerciseRepository _exerciseRepository;
        private IProgramRepository _programRepository;
        private ITraineeStatisticsRepository _traineeStatisticsRepository;

        public UnitOfWork()
        {
            _context = new GymHubDBContext();
        }

        public ITraineeRepository TraineeRepository
        {
            get
            {
                if (_traineeRepository == null)
                {
                    _traineeRepository = new TraineeRepository(_context);
                }
                return _traineeRepository;
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

        public ITraineeStatisticsRepository TraineeStatisticsRepository
        {
            get
            {
                if (_traineeStatisticsRepository == null)
                {
                    _traineeStatisticsRepository = new TraineeStatisticsRepository(_context);
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