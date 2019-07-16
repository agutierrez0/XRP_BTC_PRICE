using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildIDs.Data.Models
{
    [Table("BuildIDVersionHistory")]
    public partial class BuildIdversionHistory
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("BuildID")]
        public int? BuildId { get; set; }
        [StringLength(100)]
        public string Environment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdate { get; set; }
    }
}