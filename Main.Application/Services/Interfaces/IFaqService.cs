using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.Faq;
using Main.Domain.ViewModel;

namespace Main.Application.Services.Interfaces
{
    public interface IFaqService
    {
        List<Faq> GetAllQuestions();
        UpdateFaqViewModel ShowFaqForEditById(int id);

        UpdateFaqViewModel GetQuestionForEdit(int id);
        bool CreateFaq(CreateFaqViewModel aq);
        bool DeleteFaq(int id);
       
        UpdateFaqResult UpdateFaq(UpdateFaqViewModel aq);
    }
}
