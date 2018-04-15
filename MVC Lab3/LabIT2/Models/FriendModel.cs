using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabIT2.Models
{
    public class FriendModel
    {
        public int Id { get; set; }

        [Required] [Range(0, 200, ErrorMessage = "ID must be between 0 and 200")]
        [Display(Name = "Friend ID")]
        public int FriendId { get; set; }

        [Required] [Display(Name = "Ime")] public string Name { get; set; }

        [Required] [Display(Name = "Mesto na ziveenje")] public string City { get; set; }
    }
}