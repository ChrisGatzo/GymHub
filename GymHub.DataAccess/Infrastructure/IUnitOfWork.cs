using GymHub.DataAccess.Repositories;

namespace GymHub.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        ITraineeRepository TraineeRepository { get; }
        IExerciseRepository ExerciseRepository { get; }
        IProgramRepository ProgramRepository { get; }
        ITraineeStatisticsRepository TraineeStatisticsRepository { get; }
        ITraineeCheckInRepository TraineeCheckInRepository { get; }
        void Save();
        void Dispose();
    }
}