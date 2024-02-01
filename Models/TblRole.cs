using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIVS.Models
{
    public partial class TblRole
    {
        [Key]
        public string Roleid { get; set; } = null!;
        public string? Name { get; set; }
    }
}