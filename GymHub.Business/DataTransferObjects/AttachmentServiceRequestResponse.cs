using System.IO;

namespace GymHub.Service.DataTransferObjects
{
    public class UploadFileResponse
    {

    }

    public class UploadFileRequest
    {
        public int TraineeId { get; set; }
        public Stream AttachmentFile { get; set; }
    }
}
