using MovieApp.Core.Data;
using System.Data.Entity;

namespace MovieApp.Core.Interfaces;

public interface IMovieDbContext
{
    IDbSet<TEntity> Set<TEntity>() where TEntity : class;

    int SaveChanges();
}
