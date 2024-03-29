﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _movieContext;
        public MoviesController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpPost]
        [Route("AddMovie")]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            if (_movieContext == null)
            {
                return NotFound();
            }

            _movieContext.MoviesList.Add(movie);
            await _movieContext.SaveChangesAsync();

            return movie;
        }

        //GET : api/movies
        [HttpGet]
        [Route("GetAllMovie")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_movieContext == null)
            {
                return NotFound();
            }
            //return await _movieContext.MoviesList.Include(m => m.Actors).ToListAsync();
            return await _movieContext.MoviesList.ToListAsync();
        }

        //GET : api/movies/id
        [HttpGet]
        [Route("GetMovie/{id}")]
        public async Task<ActionResult<Movie>> GetMovies(int id)
        {
            if (_movieContext == null)
            {
                return NotFound();
            }

            var movie = await _movieContext.MoviesList.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpPut]
        [Route("UpdateMovie/{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(int id, Movie movie)
        {
            if (movie.Id != id)
            {
                return BadRequest();
            }

            _movieContext.Entry(movie).State = EntityState.Modified;

            await _movieContext.SaveChangesAsync();

            var updatedMovie = _movieContext.MoviesList.FirstOrDefaultAsync(x => x.Id == id);

            return movie;
        }

        [HttpDelete]
        [Route("DeleteMovie/{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieContext.MoviesList.FindAsync(id);

            if (movie == null) return NotFound();

            _movieContext.MoviesList.Remove(movie);

            await _movieContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
