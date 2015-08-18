using GymHub.DataAccess.Infrastructure;
using GymHub.Service.DataTransferObjects;

namespace GymHub.Service
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttachmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public UploadFileResponse UploadFile(UploadFileRequest request)
        {
            var bytesStream = new byte[request.AttachmentFile.Length];
            request.AttachmentFile.Position = 0;
            request.AttachmentFile.Read(bytesStream, 0, (int)request.AttachmentFile.Length);

            //TODO: Insert image to db.
            //_unitOfWork.AttachmentRepository.Insert();

            return new UploadFileResponse();
        }
    }
}