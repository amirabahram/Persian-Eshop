using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Main.Domain.Models.Faq;

namespace Main.Data.Context
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {

        }
        public DbSet<Faq> Faqs { get; set; }

    }
}
