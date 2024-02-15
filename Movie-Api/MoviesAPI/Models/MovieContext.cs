using Microsoft.EntityFrameworkCore;

namespace MoviesAPI.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options):base(options)
        {

        }

        public DbSet<Movie> MoviesList { get; set; } = null!;
        public DbSet<Actor> ActorList { get; set; } = null!;
        public DbSet<MovieActor> ActorMovie { get; set; } = null!;
        public DbSet<MovieRating> MovieRating { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure composite primary key in MovieActor
            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });

            // Configure relationships
            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(m => m.Actors)
                .HasForeignKey(ma => ma.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(a => a.Movies)
                .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<MovieRating>()
            .HasKey(mr => mr.Id);

            modelBuilder.Entity<MovieRating>()
                .HasOne(mr => mr.Movie)
                .WithMany(m => m.Ratings)
                .HasForeignKey(mr => mr.MovieId);
        }
    }
}
