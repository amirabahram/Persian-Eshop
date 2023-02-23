using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.Domain.Models.Common;

namespace Main.Domain.Models.Faq
{
    public class Faq : BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
