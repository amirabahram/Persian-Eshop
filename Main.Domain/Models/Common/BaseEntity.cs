using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.Common
{
    public  class BaseEntity
    {

        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
