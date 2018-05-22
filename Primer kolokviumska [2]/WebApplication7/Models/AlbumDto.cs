using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
        [Display(Name = "Your ni99as name")] //[Range(0,200)]
        public string Name { get; set; }
    }
}