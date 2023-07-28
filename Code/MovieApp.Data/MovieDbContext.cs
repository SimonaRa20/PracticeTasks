using MovieApp.Core.Data;
using MovieApp.Core.Interfaces;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;

namespace MovieApp.Data
{
    public class MovieDbContext : DbContext, IMovieDbContext
    {
        public MovieDbContext()
            : base("MovieDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieDbContext, MovieApp.Data.Migrations.Configuration>());
        }
        public MovieDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieDbContext, MovieApp.Data.Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        IDbSet<TEntity> IMovieDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
