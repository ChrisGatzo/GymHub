using AutoMapper;
using GymHub.Models;
using GymHub.Models.Domain;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<TraineeStatistic, TraineeStatisticViewModel>();
            Mapper.CreateMap<Trainee, TraineeViewModel>();
            Mapper.CreateMap<Exercise, ExerciseViewModel>();
            Mapper.CreateMap<TraineeStatisticViewModel, TraineeStatistic>();
        }
    }
}