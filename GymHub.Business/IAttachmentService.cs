using System.Web;

namespace GymHub.Business
{
    public interface IAttachmentService
    {
        void UploadFile(int traineeId, HttpPostedFileBase attachmentFile);
    }
}