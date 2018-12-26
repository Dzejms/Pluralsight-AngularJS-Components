using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Melvicorp.Data;
using CourseViewer.Data.Entities;

namespace CourseViewer.Data
{
    public class CourseViewerDbContext : DbContext
    {
        public CourseViewerDbContext() : base("name=CourseViewer")
        {
            //Database.SetInitializer<CourseViewerDbContext>(null);
        }

        public DbSet<Author> AuthorSet { get; set; }
        public DbSet<Course> CourseSet { get; set; }
        public DbSet<CourseModule> CourseModuleSet { get; set; }
        public DbSet<User> UserSet { get; set; }
        public DbSet<RecentlyViewed> RecentlyViewedSet { get; set; }
        public DbSet<DiscussionEntry> DiscussionEntrySet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Entity<Author>().HasKey(e => e.AuthorId).Ignore(e => e.EntityId);
            modelBuilder.Entity<Course>().HasKey(e => e.CourseId).Ignore(e => e.EntityId);
            modelBuilder.Entity<CourseModule>().HasKey(e => e.CourseModuleId).Ignore(e => e.EntityId);
            modelBuilder.Entity<User>().HasKey(e => e.UserId).Ignore(e => e.EntityId);
            modelBuilder.Entity<RecentlyViewed>().HasKey(e => e.RecentlyViewedId).Ignore(e => e.EntityId);
            modelBuilder.Entity<DiscussionEntry>().HasKey(e => e.DiscussionEntryId).Ignore(e => e.EntityId);

            modelBuilder.Entity<Course>().HasRequired<Author>(e => e.Author).WithMany().HasForeignKey(e => e.AuthorId);
            modelBuilder.Entity<Course>().HasMany<CourseModule>(e => e.Modules).WithRequired(e => e.Course).HasForeignKey(e => e.CourseId);
            modelBuilder.Entity<RecentlyViewed>().HasRequired<Course>(e => e.Course).WithMany().HasForeignKey(e => e.CourseId);
            modelBuilder.Entity<DiscussionEntry>().HasRequired<User>(e => e.User).WithMany().HasForeignKey(e => e.UserId);
        }
    }
}