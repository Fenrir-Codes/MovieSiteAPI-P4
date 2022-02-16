using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieSiteAPI.Data;
using MovieSiteAPI.Models;

namespace MovieSiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieSiteAPIContext _context;

        public MoviesController(MovieSiteAPIContext context)
        {
            _context = context;
        }

        #region Get All the movies listed

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovie()
        {
            return await _context.Movie.ToListAsync();
        }

        #endregion


        #region Get movie with ID

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<List<Movie>> GetMovie(int id) //changed to return a List , now it is returning a readable array and angular can read it.
        {
            var movie = await _context.Movie.Where(m => m.MovieId == id).ToListAsync();


            if (movie == null)
            {
                return null;
            }

            return movie;
        }

        #endregion


        #region Get movie with Date

        // GET: api/Movies/mostRecentMovies
        // getting the most recent movies added to database today is 
        [HttpGet("mostRecentMovies")]
        public async Task<List<Movie>> GetMostRecentMovies()
        {
            DateTime today = DateTime.Now; // today's datetime

            //look for movies where added date is less than today's date and added date is bigger than today -14 days
            var movieAfterDate = await _context.Movie.Where(m => m.AddedDate.Date <= today.Date 
            && m.AddedDate.Date >= today.AddDays(-15)).ToListAsync();

            if (movieAfterDate == null)
            {
                return null;
            }

            return movieAfterDate;
        }

        #endregion


        #region update movie with ID

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest("Invalid id: {id} sent from the client.");
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound("Movie with id: {id}, not found in database.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        #endregion


        #region Create movie

        // POST: api/Movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            var isCreated = CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);

            if (isCreated != null)
            {
                return movie;
            }
            return null;
        }

        #endregion


        #region Delete movie With ID

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound("Movie with id: {id} ,not found in database.");
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        #region Bool is movie exist?
        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieId == id);
        }

        #endregion

    }
}
