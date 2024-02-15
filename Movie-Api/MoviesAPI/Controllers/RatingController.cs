using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly MovieContext _movieContext;
        public RatingController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpPost]
        public async Task<ActionResult<MovieRating>> AddRating(MovieRating MovieRating)
        {
            _movieContext.MovieRating.Add(MovieRating);
            await _movieContext.SaveChangesAsync();

            return MovieRating;
        }
        [HttpGet("{id}/ratings")]
        public async Task<IActionResult> GetMovieRatings(int id)
        {
            var ratings = await _movieContext.MovieRating
                .Where(mr => mr.MovieId == id)
                .ToListAsync();

            return Ok(ratings);
        }
    }
}
