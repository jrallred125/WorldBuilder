using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorldBuilder.Domain.Models;

namespace WorldBuilder.EntityFramework
{
    public class WorldBuilderDbContex : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Place> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
