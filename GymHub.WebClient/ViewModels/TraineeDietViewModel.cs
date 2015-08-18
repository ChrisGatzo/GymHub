using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using GymHub.WebClient.Resources;

namespace GymHub.WebClient.ViewModels
{
    public class TraineeDietViewModel
    {
        public int TraineeId { get; set; }

        public HttpPostedFileBase AttachmentFile { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comment", ResourceType = typeof(Strings))]
        public string Comment { get; set; }


        public IEnumerable<DietViewModel> DietViewModels { get; set; }
    }
}