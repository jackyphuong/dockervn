using helloVnext.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helloVnext
{
    public class HelloVnextContext:DbContext
    {
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>().Key(a => a.AlbumId);

            base.OnModelCreating(builder);
        }
    }
}
