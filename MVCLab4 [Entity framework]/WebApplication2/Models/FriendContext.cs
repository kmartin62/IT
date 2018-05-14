using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class FriendContext:DbContext
    {
        public DbSet<FriendModel> friends { get; set; }
    }
}