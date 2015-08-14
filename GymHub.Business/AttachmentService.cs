using System.Web;
using GymHub.DataAccess;

namespace GymHub.Service
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttachmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void UploadFile(int traineeId, HttpPostedFileBase attachmentFile)
        {          
            var bytesStream = new byte[attachmentFile.InputStream.Length];
            attachmentFile.InputStream.Position = 0;
            attachmentFile.InputStream.Read(bytesStream, 0, (int)attachmentFile.InputStream.Length);

            //   _unitOfWork.AttachmentRepository.Insert();
        }
    }
}