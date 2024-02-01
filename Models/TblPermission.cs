using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductAPIVS.Models
{
    public partial class TblPermission
    {
        [Key]
        public string RoleId { get; set; } = null!;
        public string MenuId { get; set; } = null!;
    }
}