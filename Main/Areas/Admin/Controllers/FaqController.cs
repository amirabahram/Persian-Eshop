using Microsoft.AspNetCore.Mvc;
using Main.Application.Services.Interfaces;
using Main.Application.Services;
using Main.Domain.ViewModel;

namespace Main.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FaqController : Controller
    {
        private readonly IFaqService _IFaqService;

        public FaqController(IFaqService FaqServ)
        {
            _IFaqService = FaqServ;
        }
        public IActionResult FaqAdmin()
        {
            var AllQuests = _IFaqService.GetAllQuestions();
            return View(AllQuests);

        }

        [HttpGet]
        public IActionResult CreatFaq()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatFaq(CreateFaqViewModel crt)
        {
            var Cr = _IFaqService.CreateFaq(crt);
            if (Cr)
            {
                return RedirectToAction("FaqAdmin");
            }
            else
            {
                return View(crt);
            }
        }
        [HttpGet]
        public IActionResult EditFaq(int id)
        {
            var showForEdit = _IFaqService.ShowFaqForEditById(id);

            return View(showForEdit);
        }
        [HttpPost]
        public IActionResult EditFaq(UpdateFaqViewModel Upd)
        {
            if (!ModelState.IsValid) return View(Upd);
            var result = _IFaqService.UpdateFaq(Upd);
            //var Edt = _IFaqService.GetQuestionForEdit(Upd.Id);
            switch (result)
            {
                case UpdateFaqResult.FaqNotFound:
                    {
                        return NotFound();
                    }
                    break;

                case UpdateFaqResult.Success:
                    {
                        return RedirectToAction("FaqAdmin");
                    }
                    break;

                
            }
            return View(Upd);
        }

        public IActionResult DeleteFaq(int id)
        {
            var result = _IFaqService.DeleteFaq(id);
            return RedirectToAction("FaqAdmin");
        }


    }
}
