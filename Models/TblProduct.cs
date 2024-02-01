using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIVS.Models
{
    public partial class TblProduct
    {
        [Key]
        public int Code { get; set; }
        public string? Name { get; set; }
        public decimal? Amount { get; set; }
    }
}