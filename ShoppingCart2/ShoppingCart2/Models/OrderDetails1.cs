using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart2.Models
{
    public class OrderDetails1
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }
        public virtual Book Book { get; set; }
        public virtual Order1 order { get; set; }
    }
}