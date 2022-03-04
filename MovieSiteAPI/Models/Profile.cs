using System.Collections.Generic;

namespace MovieSiteAPI.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }  // --> PK
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string selfIntro { get; set; }
        public string Image { get; set; }
        public int Role { get; set; }


        public ICollection<Order> Orders { get; set; }
        public ICollection<Subscription> Subscription { get; set; }

    }
}
