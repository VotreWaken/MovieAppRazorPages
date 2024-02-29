using Microsoft.EntityFrameworkCore;

namespace MovieAppRazorPages.Models
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public MovieContext(DbContextOptions<MovieContext> options)
           : base(options)
        {

        }

        // Configures the MovieGenre Entity in a Database Context.
        /* 
           Tells Entity Framework Core how to Properly set up a Table to Store a 
           many-to-many Relationship Between the Movie and Genre Entities via the 
           MovieGenre Staging Table.
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Defines a Composite Key for the Table Corresponding to the MovieGenre Entity
            // the Table will have a Composite Key Consisting of Two Columns 
            // MovieId and GenreId ( Many to Many )
            modelBuilder.Entity<MovieGenre>()
                .HasKey(e => new { e.MovieId, e.GenreId });

            // Passes Control to the Underlying Implementation of the 
            // OnModelCreating Method to the Parent Class
            base.OnModelCreating(modelBuilder);
        }

    }
}
