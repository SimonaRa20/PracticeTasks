using MovieApp.Core.Data;
using MovieApp.Core.Interfaces;
using MovieApp.Interfaces;
using MovieApp.Models;

namespace MovieApp.Services
{
    public class MovieViewModelService : IMovieViewModelService
    {

        private readonly IRepository<Movie> _db;

        public MovieViewModelService(IRepository<Movie> db)
        {
            _db = db;
        }

        public IEnumerable<MovieViewModel> GetAllMovies()
        {
            var movies = _db.FindAll().ToArray();
            if (movies.Any())
            {
                return movies.Select(x => Map(x));
            }

            return null;
        }

        public MovieViewModel GetMovieById(int id)
        {
            var movie = _db.FindByCondition(x => x.Id == id);
            if (movie.Any())
            {
                Map(movie.First());
            }

            return null;
        }

        public void AddMovie(MovieViewModel movie)
        {
            _db.Create(Map(movie));
        }

        private static MovieViewModel Map(Movie movie)
        {
            if (movie != null)
            {
                return new MovieViewModel()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Genre = (Enums.Genre)movie.Genre,
                    ShortDescription = movie.ShortDescription,
                    ReleaseYear = movie.ReleaseYear
                };
            }
            return null;
        }

        private static Movie Map(MovieViewModel model)
        {
            return new Movie
            {
                Id = model.Id,
                Title = model.Title,
                Genre = (Genre)model.Genre,
                ShortDescription = model.ShortDescription,
                ReleaseYear = model.ReleaseYear
            };
        }
    }
}
