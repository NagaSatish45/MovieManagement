using System;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class MovieRating
    {
        public MovieRating()
        {
            this.Movie = new Movie();
            this.Rating = new Random().Next(0, 9);
        }

        public int Id { get; set; } // Primary key
        public int MovieId { get; set; } // Foreign key to Movie table
        public int Rating { get; set; } // Rating value
        public string Review { get; set; } // Optional review text
        public DateTime Timestamp { get; set; } // Optional timestamp

        [JsonIgnore]
        public Movie Movie { get; set; } // Navigation property
    }
}
