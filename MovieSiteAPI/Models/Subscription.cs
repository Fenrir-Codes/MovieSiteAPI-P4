using System;

namespace MovieSiteAPI.Models
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public int ProfileId { get; set; } // --> FK profile
        public string Name { get; set; }
        public DateTime Activated { get; set; }
        public DateTime ExpDate { get; set; }
        public bool isActive { get; set; }
    }
}
