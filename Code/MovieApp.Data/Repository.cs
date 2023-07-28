using MovieApp.Core.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq.Expressions;

namespace MovieApp.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private IMovieDbContext _context;

    private IDbSet<T> table;

    public Repository()
    {
        this._context = new MovieDbContext();
        table = _context.Set<T>();
    }
    public Repository(IMovieDbContext _context)
    {
        this._context = _context;
        table = _context.Set<T>();
    }

    public IQueryable<T> FindAll()
        => _context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        =>
        _context.Set<T>().Where(expression);

    public void Create(T entity)
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.table.Add(entity);
            this._context.SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            var msg = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                }
            }

            var fail = new Exception(msg, dbEx);
            throw fail;
        }
    }

    public void Update(T entity)
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this._context.SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            var msg = string.Empty;
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
            var fail = new Exception(msg, dbEx);
            throw fail;
        }
    }

    public void Delete(T entity)
    {
        try
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            this.table.Remove(entity);
            this._context.SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            var msg = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
            var fail = new Exception(msg, dbEx);
            throw fail;
        }
    }
}
