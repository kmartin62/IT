using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication7.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Display(Name = "Artist Name")]
        [Required]
        public string Name { get; set; }
    }
}