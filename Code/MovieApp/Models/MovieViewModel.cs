using MovieApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name ="Genre of the movie")]
        public Genre Genre { get; set; }

        [Display(Name = "Release year")]
        public string ReleaseYear { get; set; }

        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }
    }
}
