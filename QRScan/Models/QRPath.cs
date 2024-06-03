using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QRScan.Models
{
    public class QRPath
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}