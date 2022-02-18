using System;
using System.Collections.Generic;

namespace MovieSiteAPI.Models
{
    public class Movie
    {
        public int MovieId { get; set; }  // --> PK
        public int DirectorId { get; set; } // --> FK Director

        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
        public string Duration { get; set; }  //can be displayed like 60 Min or 95 Min
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string videoUrl { get; set; }


        /* EF Relations */
        public ICollection<Order> Orders { get; set; }
    }
}
