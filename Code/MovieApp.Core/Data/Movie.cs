namespace MovieApp.Core.Data
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string ReleaseYear { get; set; }

        public Genre Genre { get; set; }
    }
}
