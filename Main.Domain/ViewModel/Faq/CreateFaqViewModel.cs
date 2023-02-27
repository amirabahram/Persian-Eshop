using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.Faq;

namespace Main.Domain.ViewModel
{
    public class CreateFaqViewModel
    {
        //public List<Faq> CreateFaqViewModels { get; set; }
        //public CreateFaqViewModel()
        //{
        //    CreateFaqViewModels = new List<Faq>();
        //}
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
