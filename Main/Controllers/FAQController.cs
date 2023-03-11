using Main.Application.Services.Interfaces;
using Main.Domain.Models.Faq;
using Microsoft.AspNetCore.Mvc;

namespace Main.web.Controllers
{
    public class FAQController : Controller
    {
        private readonly IFaqService _faqService;
        public FAQController(IFaqService faqService)
        {
            this._faqService = faqService;
        }
        public IActionResult FAQView()
        {
            var faq = _faqService.GetAllQuestions();
            return View(faq);
        }


    }
}
