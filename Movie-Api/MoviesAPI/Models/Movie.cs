using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Movie
    {

        public Movie()
        {
            this.Actors = new List<MovieActor>();
            this.Ratings = new List<MovieRating>();
        }

        public int Id { get; set; } // Single-column primary key

        public string Title { get; set; } = string.Empty;

        public string MovieLanguage { get; set; } = string.Empty;

        public string ReleaseYear { get; set; } = string.Empty;
        public string OTT { get; set; } = string.Empty;

        // Navigation property for relationship with actors
        public ICollection<MovieActor> Actors { get; set; }

        public ICollection<MovieRating> Ratings { get; set; }

    }
}
