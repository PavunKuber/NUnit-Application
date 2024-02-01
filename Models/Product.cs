using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIVS.Models
{
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}