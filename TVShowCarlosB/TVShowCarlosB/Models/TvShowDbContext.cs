using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TVShowCarlosB.Models
{
    public class TvShowDbContext : DbContext
    {
        public TvShowDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TVShow");
        }

        public TvShowDbContext(DbContextOptions<TvShowDbContext> options)
            : base(options)
        {
            this.EnsureSeedData();
        }        

        public DbSet<TvShow> TvShows { get; set; }
    }
}
