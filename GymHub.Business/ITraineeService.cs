using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public interface ITraineeService
    {       
        GetAllTraineesResponse GetAllTrainees(GetAllTraineesRequest request);
        GetFilteredTraineesResponse GetFilteredTrainees(GetFilteredTraineesRequest request);
        CheckInTraineeResponse CheckInTrainee(CheckInTraineeRequest request);
        GetInactiveTraineesResponse GetInactiveTrainees(GetInactiveTraineesRequest request);
    }

}