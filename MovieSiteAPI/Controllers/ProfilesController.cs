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
    public class ProfilesController : ControllerBase
    {
        private readonly MovieSiteAPIContext _context;

        public ProfilesController(MovieSiteAPIContext context)
        {
            _context = context;
        }

        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            return await _context.Profile.ToListAsync();
        }


        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            var profile = await _context.Profile.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.ProfileId)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<bool>> Login(string Email, string Password)
        {
            try
            {
                var user = await _context.Profile.Where(user => user.Email == Email && user.Password == Password).FirstOrDefaultAsync();
                if (user != null)
                {
                    return true;
                    //fill the response object with values ->
                    //var response = new Profile();
                    //{
                    //    response.ProfileId = user.ProfileId;
                    //    response.Firstname = user.Firstname;
                    //    response.Lastname = user.Lastname;
                    //    response.Address = user.Address;
                    //    response.Email = user.Email;
                    //    response.Phone = user.Phone;
                    //    response.Image = user.Image;
                    //    response.Role = user.Role;
                    //}
                    // //then return the object ->
                    // return Ok(response);
                    


                }
                return false;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            _context.Profile.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.ProfileId }, profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.ProfileId == id);
        }

    }
}
