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
        //[HttpGet]
        //public IActionResult EditFaq()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult EditFaq(UpdateFaqViewModel Upd)
        //{
        //    var Edt = _IFaqService.UpdateFaq(Upd);
        //    return RedirectToAction("FaqAdmin");

        //}


    }
}
