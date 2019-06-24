﻿using System;
using System.Collections.Generic;

namespace MvcMovie.Data.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int? Quantity { get; set; }
        public int? YearProduced { get; set; }
        public int? Price { get; set; }
        public string Luxury { get; set; }
    }
}