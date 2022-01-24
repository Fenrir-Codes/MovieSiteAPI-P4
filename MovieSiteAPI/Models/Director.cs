using System.Collections.Generic;

namespace MovieSiteAPI.Models
{
    public class Director
    {
        public int DirectorId { get; set; }  // --> PK
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        /* EF Relations */
        public List<Movie> Movie { get; set; }
    }
}
