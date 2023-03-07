namespace Main.Domain.ViewModel.AboutUs
{
    public class EditAboutUsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string? ImagAbouts { get; set; }
    }
    public enum EditAboutUsResualt
    {
        Suscess,
        DataNotFound,
        DataViewNotFound
    }
}
