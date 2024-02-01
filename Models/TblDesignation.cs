using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIVS.Models
{
    public partial class TblDesignation
    {
        [Key]
        public string Code { get; set; } = null!;
        public string? Name { get; set; }
    }
}