using Main.Domain.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Main.Domain.Models.AboutUs
{
    //CREATE CLASS ABOUTUS
    public class AboutUsModel : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string TitleAboutUs { get; set; }

        [Required]
        [MaxLength(150)]
        public string DiscriptionAboutUs { get; set; }

        [Required]
        [MaxLength(150)]
        public string ImagAboutUs { get; set; }
    }
}
