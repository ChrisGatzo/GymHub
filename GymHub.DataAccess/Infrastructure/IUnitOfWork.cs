using GymHub.DataAccess.Repositories;

namespace GymHub.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        IAthleteRepository AthleteRepository { get; }
        IExerciseRepository ExerciseRepository { get; }
        IProgramRepository ProgramRepository { get; }
        IAthleteStatisticsRepository AthleteStatisticsRepository { get; }
        IAthleteCheckInRepository AthleteCheckInRepository { get; }
        void Save();
        void Dispose();
    }
}