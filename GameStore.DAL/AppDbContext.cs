using GameStore.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }


    }
}