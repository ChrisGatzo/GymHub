using GymHub.DataAccess.DomainModels;

namespace GymHub.DataAccess
{
    public interface IUnitOfWork
    {
        IGenericRepository<Trainee> TraineeRepository { get; }
        IGenericRepository<Program> ExerciseRepository { get; }
        IGenericRepository<TraineeStatistic> TraineeStatisticsRepository { get; }
        void Save();
        void Dispose();
    }
}