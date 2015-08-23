using AutoMapper;
using GymHub.Models.Domain;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<AthleteStatistic, AthleteStatisticViewModel>();
            Mapper.CreateMap<Athlete, AthleteViewModel>();
            Mapper.CreateMap<Exercise, ExerciseViewModel>();
            Mapper.CreateMap<AthleteStatisticViewModel, AthleteStatistic>();
        }
    }
}