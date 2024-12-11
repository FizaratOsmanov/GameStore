using GameStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL
{
    public class AppDbContext : DbContext
    {

        public DbSet<Game> Games { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }


    }  
}