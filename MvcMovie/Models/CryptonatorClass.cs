using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class CryptonatorClass
    {
        public Ticker ticker { get; set; }
        public long timestamp { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
    }
}
