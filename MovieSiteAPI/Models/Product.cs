﻿using System;
using System.Collections.Generic;

namespace MovieSiteAPI.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int AddDays { get; set; }

    }
}
