using System.Web;

namespace GymHub.Services
{
    public interface IAttachmentService
    {
        void UploadFile(int traineeId, HttpPostedFileBase attachmentFile);
    }
}