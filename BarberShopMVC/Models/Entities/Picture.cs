using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BarberShopMVC.Models.Entities
{
    public class Picture
    {
        [Key]
        public int PictureId { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}