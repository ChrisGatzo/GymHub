using System.Web;

namespace GymHub.Service
{
    public interface IAttachmentService
    {
        void UploadFile(int traineeId, HttpPostedFileBase attachmentFile);
    }
}