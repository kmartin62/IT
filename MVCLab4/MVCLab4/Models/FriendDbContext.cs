using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCLab4.Models
{
    public class FriendDbContext : DbContext
    {
        public DbSet<FriendModel> friends { get; set; }
    }
}