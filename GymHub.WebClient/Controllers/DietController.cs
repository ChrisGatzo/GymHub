using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using GymHub.Models.Domain;
using GymHub.Service;
using GymHub.Service.DataTransferObjects;
using GymHub.WebClient.Resources;
using GymHub.WebClient.ViewModels;

namespace GymHub.WebClient.Controllers
{
    public class DietController : Controller
    {
        private readonly ITraineeService _traineeService;
        private readonly IAttachmentService _attachmentService;
        private readonly IDietService _dietService;

        public DietController(ITraineeService traineeService, IAttachmentService attachmentService, IDietService dietService)
        {
            _traineeService = traineeService;
            _attachmentService = attachmentService;
            _dietService = dietService;
        }

        public ActionResult Trainees()
        {
            var response = _traineeService.GetAllTrainees(new GetAllTraineesRequest());

            var traineeViewModels = Mapper.Map<List<Trainee>, List<TraineeViewModel>>(response.Trainees.ToList());

            ViewBag.DietActive = "active";
            return View(traineeViewModels);
        }

        public ActionResult TraineeDiet(int traineeId)
        {
            // var traineeDiets =_dietService.GetTraineeDiets(traineeId);            

            var traineeDietViewModel = new TraineeDietViewModel();
            traineeDietViewModel.DietViewModels = new List<DietViewModel>(); //Mapper.Map<List<TraineeDiet>, List<TraineeDietViewModel>>(traineeDiets);


            return PartialView(traineeDietViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TraineeDiet(TraineeDietViewModel traineeDietViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsValid = false, Message = Strings.ModelNotValid });
            }

            var request = new UploadFileRequest
            {
                TraineeId = traineeDietViewModel.TraineeId,
                AttachmentFile = traineeDietViewModel.AttachmentFile.InputStream
            };

            _attachmentService.UploadFile(request);

            return Json(new { IsValid = true, Message = Strings.SuccessfulFileUpload });
        }


    }
}