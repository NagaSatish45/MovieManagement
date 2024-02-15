using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly MovieContext _movieContext;
        public ActorController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        [HttpPost]
        public async Task<ActionResult<Actor>> AddActor(Actor actor)
        {
            if (_movieContext == null)
            {
                return NotFound();
            }

            _movieContext.ActorList.Add(actor);

            await _movieContext.SaveChangesAsync();

            return actor;
        }

        //GET : api/actor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
        {
            if (_movieContext == null)
            {
                return NotFound();
            }
            return await _movieContext.ActorList.ToListAsync();
        }
    }
}
