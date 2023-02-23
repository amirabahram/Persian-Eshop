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
        Faq GetQuestionById(int id);
        bool CreateFaq(CreateFaqViewModel aq);
        bool DeleteFaq(Faq aq);
        void UpdateFaq(UpdateFaqViewModel aq);
    }
}
