using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart2.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderKey { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Total { get; set; }
        private System.DateTime TimeNow = DateTime.Now;
        public System.DateTime OrderDate { get {
                return TimeNow;
            } set {
                TimeNow = value;
            } }
        
    }
}