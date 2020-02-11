using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using jk468115MIS4200.Models;

namespace jk468115MIS4200.DAL
{
    public class MIS4200Context : DbContext 
    {

        public MIS4200Context() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Context, jk468115MIS4200.Migrations.MISContext.Configuration>("DefaultConnection"));
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Registration> Registration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}