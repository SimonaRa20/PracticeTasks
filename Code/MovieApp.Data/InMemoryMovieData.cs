using MovieApp.Core.Data;
using MovieApp.Core.Interfaces;
using System.Linq.Expressions;

namespace MovieApp.Data
{
    public class InMemoryMovieData : IRepository<Movie>
    {
        List<Movie> movies;

        public InMemoryMovieData()
        {
            movies = new List<Movie>()
            {
                new Movie { Id = 1, ReleaseYear = "2006", Title = "Very Real Movie", Genre = Genre.Comedy, ShortDescription = "Description" },
                new Movie { Id = 2, ReleaseYear = "2020", Title = "Very Real Movie 2", Genre = Genre.Tragedy },
                new Movie { Id = 3, ShortDescription = "Just your typical romance.", Title = "Something, something Love", Genre = Genre.Romance },
                new Movie { Id = 4, Title = ".gitignore: The Movie", Genre = Genre.Horror }
            };
        }

        public void Create(Movie movie)
        {
            movie.Id = movies.Max(x => x.Id) + 1;
            movies.Add(movie);
        }

        public Movie GetMovieById(int id)
        {
            return movies.FirstOrDefault(m => m.Id == id);
        }

        public void Update(Movie movie)
        {
            var existing = GetMovieById(movie.Id);
            if (existing != null)
            {
                existing.ReleaseYear = movie.ReleaseYear;
                existing.Title = movie.Title;
                existing.Genre = movie.Genre;
                existing.ShortDescription = movie.ShortDescription;
            }
        }
        public IQueryable<Movie> FindAll()
        {
            return movies.AsQueryable().OrderBy(m => m.Title);
        }

        public IQueryable<Movie> FindByCondition(Expression<Func<Movie, bool>> expression)
        {
            return movies.AsQueryable().Where(expression);
        }

        public void Delete(Movie movie)
        {
            movies.Remove(movie);
        }
    }
}
