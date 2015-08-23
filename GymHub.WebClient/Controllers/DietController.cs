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
        private readonly IAthleteService _athleteService;
        private readonly IAttachmentService _attachmentService;
        private readonly IDietService _dietService;

        public DietController(IAthleteService athleteService, IAttachmentService attachmentService, IDietService dietService)
        {
            _athleteService = athleteService;
            _attachmentService = attachmentService;
            _dietService = dietService;
        }

        public ActionResult Athletes()
        {
            var response = _athleteService.GetAllAthletes(new GetAllAthletesRequest());

            var athleteViewModels = Mapper.Map<List<Athlete>, List<AthleteViewModel>>(response.Athletes.ToList());

            ViewBag.DietActive = "active";
            return View(athleteViewModels);
        }

        public ActionResult AthleteDiet(int athleteId)
        {
            // var athleteDiets =_dietService.GetAthleteDiets(athleteId);            

            var athleteDietViewModel = new AthleteDietViewModel();
            athleteDietViewModel.DietViewModels = new List<DietViewModel>(); //Mapper.Map<List<AthleteDiet>, List<AthleteDietViewModel>>(athleteDiets);


            return PartialView(athleteDietViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AthleteDiet(AthleteDietViewModel athleteDietViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { IsValid = false, Message = Strings.ModelNotValid });
            }

            var request = new UploadFileRequest
            {
                AthleteId = athleteDietViewModel.AthleteId,
                AttachmentFile = athleteDietViewModel.AttachmentFile.InputStream
            };

            _attachmentService.UploadFile(request);

            return Json(new { IsValid = true, Message = Strings.SuccessfulFileUpload });
        }


    }
}