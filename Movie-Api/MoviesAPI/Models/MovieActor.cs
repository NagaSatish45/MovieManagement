using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class MovieActor
    {
        public MovieActor()
        {
            this.Movie = new Movie();
            this.Actor = new Actor();
        }

        // Composite primary key
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        // Navigation properties
        [JsonIgnore]
        public Movie Movie { get; set; }
        [JsonIgnore]
        public Actor Actor { get; set; }

    }
}
