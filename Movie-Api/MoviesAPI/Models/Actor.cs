using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Actor
    {
        public Actor()
        {
            this.Movies = new List<MovieActor>();
            this.Name = "Actor" + new Random().Next(0, 9);
        }

        public int Id { get; set; } // Single-column primary key

        public string Name { get; set; }

        // Navigation property for relationship with movies

        public ICollection<MovieActor> Movies { get; set; }

    }
}
