using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Schools.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schools.Domain.Models.Blogs;
using Schools.Domain.Models.Schools;
using Schools.Domain.Models.Schools.Locations;
using Schools.Domain.Models.Schools.Teachers;
using Schools.Domain.Models.Schools.TrainingTypes;
using Schools.Domain.Models.Users;
using Schools.Domain.Models.Users.Messages;
using Schools.Domain.Models.Users.Tickets;

namespace Schools.Infra.Data.Context
{
    public class SchoolsDbContext : DbContext
    {
        public SchoolsDbContext(DbContextOptions<SchoolsDbContext> options)
        : base(options)
        {

        }

        #region Locations

        public DbSet<Shire> Shires { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Area> Areas { get; set; }
        #endregion
        #region Schools

        public DbSet<School> Schools { get; set; }
        public DbSet<SchoolComment> SchoolComments { get; set; }
        public DbSet<SchoolCourse> SchoolCourses { get; set; }
        public DbSet<SchoolGroup> SchoolGroups { get; set; }
        public DbSet<SchoolLike> SchoolLikes { get; set; }
        public DbSet<SchoolVisit> SchoolVisits { get; set; }
        public DbSet<SchoolRate> SchoolRates { get; set; }
        public DbSet<SchoolGallery> SchoolGalleries { get; set; }
        public DbSet<SchoolTrainingType> SchoolTrainingTypes { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }

        #region Teachers
        public DbSet<TeacherRate> TeacherRates { get; set; }
        public DbSet<SchoolTeacher> SchoolTeachers { get; set; }



        #endregion

        #endregion

        #region Blogs

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogGroup> BlogGroups { get; set; }
        public DbSet<BlogType> BlogTypes { get; set; }

        #endregion

        #region Users

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<MessageContent> MessageContents { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<UserTicket> UserTickets { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            //Query Filters
            #region Locations

            modelBuilder.Entity<Shire>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<City>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Area>()
                .HasQueryFilter(u => !u.IsDelete);
            #endregion

            #region Schools

            modelBuilder.Entity<School>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<SchoolLike>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<SchoolGroup>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<SchoolRate>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<SchoolComment>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<SchoolVisit>()
                .HasQueryFilter(u => !u.IsDelete); 
            modelBuilder.Entity<SchoolGallery>()
                .HasQueryFilter(u => !u.IsDelete); 
            modelBuilder.Entity<SchoolCourse>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<TrainingType>()
                .HasQueryFilter(u => !u.IsDelete); 
            modelBuilder.Entity<SchoolTrainingType>()
                .HasQueryFilter(u => !u.IsDelete);
            #region Teachers

            modelBuilder.Entity<SchoolTeacher>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<TeacherRate>()
                .HasQueryFilter(u => !u.IsDelete);

            #endregion

            #endregion

            #region Blog

            modelBuilder.Entity<Blog>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<BlogType>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<BlogComment>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<BlogGroup>()
                .HasQueryFilter(u => !u.IsDelete);

            #endregion

            #region User

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<UserRole>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Role>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<UserTicket>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<TicketPriority>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<TicketCategory>()
                .HasQueryFilter(u => !u.IsDelete); 
            modelBuilder.Entity<TicketMessage>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<UserMessage>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<MessageContent>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<UserNotification>()
                .HasQueryFilter(u => !u.IsDelete);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
