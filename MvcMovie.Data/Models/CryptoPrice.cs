using System;
using System.Collections.Generic;

namespace MvcMovie.Data.Models
{
    public partial class CryptoPrice
    {
        public int Id { get; set; }
        public string CryptoName { get; set; }
        public int? Price { get; set; }
        public DateTime? TimeTracked { get; set; }
    }
}