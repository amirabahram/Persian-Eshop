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
        public bool Create(int Id);
        public bool Update(int Id);
    }
}
