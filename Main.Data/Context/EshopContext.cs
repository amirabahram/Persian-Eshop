using Main.Domain.Models.AboutUs;
using Main.Domain.Models.Cart;
using Main.Domain.Models.CartProduct;
using Main.Domain.Models.Category;
using Main.Domain.Models.CategoryProperties;
using Main.Domain.Models.Faq;
using Main.Domain.Models.Product;
using Main.Domain.Models.Product_Image_Gallery;
using Main.Domain.Models.ProductProperties;
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
        
        public DbSet<CategoryProperties> categoryProperties { get; set; }

        public DbSet<Cart>  Carts { get; set; }
        public DbSet<CartDetails> CartDetailsEntity { get; set; }
        public DbSet<ProductProperties> ProductProperties { get; set; }

    }

}
