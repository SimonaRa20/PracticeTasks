﻿using MovieApp.Models;

namespace MovieApp.Interfaces
{
    public interface IMovieViewModelService
    {
        IEnumerable<MovieViewModel> GetAllMovies();

        MovieViewModel GetMovieById(int id);

        void AddMovie(MovieViewModel movie);
    }
}
