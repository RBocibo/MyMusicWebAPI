using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.DataContext
{
    public class MyMusicDbContext : DbContext
    {
        public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Music> Music { get; set; }
        public DbSet<Artist> Artist { get; set; }
    }
}
