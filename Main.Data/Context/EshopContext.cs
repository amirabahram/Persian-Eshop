using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Main.Domain.Models.Faq;
using Main.Domain.Models.AboutUs;
using Main.Domain.Models.User;

namespace Main.Data.Context
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {

        }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<AboutUsModel> AboutUs { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<Faq>().HasData(new Faq()
            {
                Id =1,
                Question = "سوال اول",
                Answer = "پاسخ سوال اول"
            }
            );
            base.OnModelCreating(modelBuilder);
        }

      
    }
}
