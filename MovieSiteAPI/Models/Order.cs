using System;
using System.Collections.Generic;

namespace MovieSiteAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; } // --> PK
        public int ProfileId { get; set; } // --> FK profile
        public int PaymentId { get; set; } // --> FK PaymentDetails
        public int SubscriptionId { get; set; }  // --> FK subscription

        public DateTime OrderDate { get; set; }
        public bool isPaid { get; set; }  // paid or not

        public ICollection<PaymentDetails> Payments { get; set; }

    }
}
