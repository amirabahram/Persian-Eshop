using Microsoft.AspNetCore.Http;

namespace Main.Domain.ViewModel.AboutUs
{
    public class CreateAboutUsViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public IFormFile ImagAbouts { get; set; }


    }
}
