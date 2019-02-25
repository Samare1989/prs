using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prs.Modles
{
    public class PrsDbContext : DbContext{
        public DbSet<User> Users { get; set; }
        public PrsDbContext(DbContextOptions<PrsDbContext> context) : base(context) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

        }
        
           

        }
    }

//public DbSet<User> Users { get; set; }// use it for vendors too...
//protected override void OnModelCreating(ModelBuilder builder)
//{
//    builder.Entity<User>()
//        .HasIndex(u => u.UserName)
//        .IsUnique();
//we can use this for vendors ..

    //first create vendors class.. then add vendors to dbcontext.. put in modles folder. add migration.. update database.