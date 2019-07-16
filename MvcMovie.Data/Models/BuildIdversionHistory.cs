using System;
using System.Collections.Generic;

namespace TestLibrary.Data.Models
{
    public partial class BuildIdversionHistory
    {
        public int Id { get; set; }
        public int? BuildId { get; set; }
        public string Environment { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}