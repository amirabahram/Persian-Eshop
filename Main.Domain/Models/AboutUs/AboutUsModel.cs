using Main.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Domain.Models.AboutUs
{
    //CREATE CLASS ABOUTUS
    public  class AboutUsModel: BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string TitleAboutUs{ get; set; }

        [Required]
        [MaxLength(150)]
        public string DiscriptionAboutUs { get; set; }

        [Required]
        [MaxLength(150)]
        public string ImagAboutUs { get; set; }    
    }
}
