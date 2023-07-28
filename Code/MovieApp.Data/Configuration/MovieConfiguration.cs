using MovieApp.Core.Data;
using System.Data.Entity.ModelConfiguration;

namespace MovieApp.Data.Configuration
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {

            this.HasKey(x => x.Id);

            this.Property(x => x.ShortDescription).IsOptional();

            this.Property(x => x.ReleaseYear).IsRequired();

            this.Property(x => x.Genre).IsRequired();

            this.ToTable("Movie");
        }
    }
}