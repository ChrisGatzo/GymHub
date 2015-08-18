using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public interface ITraineeService
    {
        GetAllTraineesResponse GetAllTrainees(GetAllTraineesRequest request);
        GetPagedTraineesResponse GetPagedTrainees(GetPagedTraineesRequest request);        
    }   
  
}