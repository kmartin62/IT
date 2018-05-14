using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class FriendModel
    {
        public int Id { get; set; }

        [Required][Range(0,200)]
        public int FriendID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Place { get; set; }
    }
}