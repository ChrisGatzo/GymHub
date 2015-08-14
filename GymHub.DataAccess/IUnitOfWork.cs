using GymHub.DataAccess.Repositories;

namespace GymHub.DataAccess
{
    public interface IUnitOfWork
    {
        ITraineeRepository TraineeRepository { get; }
        IExerciseRepository ExerciseRepository { get; }
        IProgramRepository ProgramRepository { get; }
        ITraineeStatisticsRepository TraineeStatisticsRepository { get; }
        void Save();
        void Dispose();
    }
}