using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public interface IAthleteService
    {       
        GetAllAthletesResponse GetAllAthletes(GetAllAthletesRequest request);
        GetFilteredAthletesResponse GetFilteredAthletes(GetFilteredAthletesRequest request);
        CheckInAthleteResponse CheckInAthlete(CheckInAthleteRequest request);
        GetInactiveAthletesResponse GetInactiveAthletes(GetInactiveAthletesRequest request);
    }

}