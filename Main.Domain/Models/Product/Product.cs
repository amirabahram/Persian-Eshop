﻿
using Main.Domain.Models.Category;
using Main.Domain.Models.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.Product
{
    public class Product: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string MainImage { get; set; }
        public int Count { get; set; }

        public List<Product_Image_Gallery.ProductImageGallery>? productImageGalleries { get; set; }
        [ForeignKey("Id")]
        public Category.Category? category { get; set; }
      
      
        
    }
}
