using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Interfaces;
using Main.Domain.Models.Faq;
using Main.Data.Context;

namespace Main.Domain.Repositories
{
    public class FaqRepository : IFaqRepository
    {
        private readonly EshopContext db;
        public FaqRepository(EshopContext context)
        {
            db = context;
        }

        public List<Faq> GetAllQuestions()
        {
            return null;
        }
        public bool Create(int Id)
        {
            try
            {



                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Update(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
