using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIVS.Models
{
    public partial class TblMenu
    {
        [Key]
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public string? LinkName { get; set; }
    }
}