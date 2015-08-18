using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public interface IAttachmentService
    {
        UploadFileResponse UploadFile(UploadFileRequest request);
    }

}