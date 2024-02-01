using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIVS.Models
{
    public partial class TblEmployee
    {
        [Key]
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Designation { get; set; }
    }

}