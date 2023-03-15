using Main.Domain.Models.AboutUs;
using Main.Domain.Models.Category;
using Main.Domain.Models.Faq;
using Main.Domain.Models.Product;
using Main.Domain.Models.Product_Image_Gallery;
using Main.Domain.Models.User;

using Microsoft.EntityFrameworkCore;

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
        public DbSet<Product>   Products { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<ProductImageGallery> ProductImageGalleries { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        //    {
        //        relationship.DeleteBehavior = DeleteBehavior.Restrict;
        //    }


        //    modelBuilder.Entity<Faq>().HasData(new Faq()
        //    {
        //        Id = 1,
        //        Question = "سوال اول",
        //        Answer = "پاسخ سوال اول"
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
