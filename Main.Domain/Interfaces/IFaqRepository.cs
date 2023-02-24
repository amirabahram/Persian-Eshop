using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.Faq;

namespace Main.Domain.Interfaces
{
    public interface IFaqRepository
    {
        List<Faq> GetAllQuestions();
        Faq GetQuestionById(int id);
        bool Create(Faq aq);
        void Update(Faq aq);
        bool DuplicatedQuestion(string question);
        void SaveChanges();

    }
}
