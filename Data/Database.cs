using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Common;

namespace Data
{
    public class Database : DbContext
    {
        public DbSet<File> Files { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;user id=root;password=root;database=ortisyimages",
        //            new MariaDbServerVersion(new Version(10, 5, 8))
        //        );
        //}

        public Database(DbContextOptions<Data.Database> options)
        : base(options)
                { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
