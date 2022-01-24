using System;
using System.Collections.Generic;

namespace MovieSiteAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; } // --> PK
        public int ProfileId { get; set; } // --> FK profile
        public int PaymentId { get; set; } // --> FK PaymentDetails

        public int MovieId { get; set; }  // --> FK Movie
       // public string Title { get; set; }  // (Movie title)
       // public string Image { get; set; }  // (Movie cover)

        // Buyer Info (can be different from Profile logged in to account)
        public string Firstname { get; set; }   // (Buyer name)
        public string Lastname { get; set; }
        public string Address { get; set; }

        public DateTime OrderDate { get; set; }
        public bool isPaid { get; set; }  // paid or not

        public ICollection<PaymentDetails> PaymentDetails { get; set; }
    }
}
