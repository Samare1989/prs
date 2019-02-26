using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prs.Modles;

namespace Prs.Modles
{
    public class PrsDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Requestline> Requestlines { get; set; }


        public PrsDbContext(DbContextOptions<PrsDbContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            builder.Entity<Vendor>()
                .HasIndex(v => v.Code)
                .IsUnique();

            builder.Entity<Product>()
                .HasIndex(p => p.PartNumber)
                .IsUnique();

            //builder.Entity<Product>()
            //    .HasIndex(p => p.Id)
            //    .IsUnique();


            //builder.Entity<Request>()
            //   .HasIndex(p => p.Id)
            //   .IsUnique();

        }

        //public DbSet<Prs.Modles.Request> Request { get; set; }

       

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