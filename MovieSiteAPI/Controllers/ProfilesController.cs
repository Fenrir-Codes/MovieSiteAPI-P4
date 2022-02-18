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


        #region Get all profiles function
        // GET: api/Profiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            return await _context.Profile.ToListAsync();
        }

        #endregion


        #region Get a profile with (ID) function
        // GET: api/Profiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProfile(int id)
        {
            var profile = await _context.Profile.Include(o => o.Orders).Where(p => p.ProfileId == id).FirstOrDefaultAsync();
            
            if (profile == null)
            {
                return NotFound("Profile with id: {id}, not found in database.");
            }

            return Ok(profile);
        }

        #endregion


        #region Update Profile function

        // PUT: api/Profiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Profile profile)
        {
            if (id != profile.ProfileId)
            {
                return BadRequest("Profile with id: "+id+", not found in database.");
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
                    return NotFound("Profile with id: "+id+", not found in database.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        #endregion


        #region Create new Profile fuction

        // POST: api/Profiles
        [HttpPost]
        public async Task<ActionResult<Profile>> PostProfile(Profile profile)
        {
            _context.Profile.Add(profile);
            await _context.SaveChangesAsync();

            var isCreated = CreatedAtAction("GetProfile", new { id = profile.ProfileId }, profile);

            if (isCreated != null)
            {
                return profile;
            }
            return null;
     
        }

        #endregion


        #region Delete profile functon

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound("Profile with id: {id}, not found in database.");
            }

            _context.Profile.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion


        #region Profileexist boolean
        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.ProfileId == id);
        }
        #endregion


        #region Email exists boolean
        private bool EmailExists(string email)
        {
            return _context.Profile.Any(e => e.Email == email);
        }
        #endregion


        #region Login function

        // Login function
        [HttpPost("Login")]
        public async Task<ActionResult<Profile>> Login(string Email, string Password)
        {
            try
            {
                var response = new Profile(); // initalize a new profile as response.

                // user variable should look for a data from database where
                // user.Email and user.Password should match the Email and Password set in database
                var user = await _context.Profile.Where(user => user.Email == Email && user.Password == Password).FirstOrDefaultAsync();

                //if user find in database with the typed in credentials -->
                if (user != null)
                {
                    //response fill with user data from database ->
                    response.ProfileId = user.ProfileId; // like response.ProfileId filled with data from user.ProfileId match in the database ans so on...
                    response.Firstname = user.Firstname;
                    response.Lastname = user.Lastname;
                    response.Address = user.Address;
                    response.Email = user.Email;
                    response.Phone = user.Phone;
                    response.Image = user.Image;
                    response.Role = user.Role;

                    return Ok(response); // return response

                }
                return null; //else just return null

            }
            catch (Exception ex) //this is for just error handling
            {

                throw new Exception(ex.Message);
            }


        }

        #endregion


    }
}
