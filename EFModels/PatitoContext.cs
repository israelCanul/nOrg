using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace narilearsi.EFModels
{
    public partial class PatitoContext : DbContext
    {

        public PatitoContext(DbContextOptions<PatitoContext> options)
            : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server= rdsdev.cyizhh2mbeac.us-east-1.rds.amazonaws.com\\SQLEXPRESS,4389;Database=another;User ID=israelcanul;Password=12345678");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

        //    modelBuilder.Entity<Event>(entity =>
        //    {
        //        entity.Property(e => e.EventId)
        //            .HasColumnName("EventID")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.EventDate)
        //            .HasColumnName("eventDate")
        //            .HasColumnType("datetime");

        //        entity.Property(e => e.EventDescription)
        //            .HasColumnName("eventDescription")
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.EventName)
        //            .IsRequired()
        //            .HasColumnName("eventName")
        //            .HasMaxLength(50)
        //            .IsUnicode(false);

        //        entity.Property(e => e.EventStatus)
        //            .IsRequired()
        //            .HasColumnName("eventStatus")
        //            .HasMaxLength(10)
        //            .IsUnicode(false);

        //        entity.Property(e => e.EventType).HasColumnName("eventType");

        //        entity.HasOne(d => d.EventTypeNavigation)
        //            .WithMany(p => p.Events)
        //            .HasForeignKey(d => d.EventType)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("FK_Event_EventType");
        //    });

        //    modelBuilder.Entity<EventType>(entity =>
        //    {
        //        entity.Property(e => e.EventTypeId)
        //            .HasColumnName("EventTypeID")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.EtDescription)
        //            .IsRequired()
        //            .HasColumnName("etDescription")
        //            .HasMaxLength(50);

        //        entity.Property(e => e.EtName)
        //            .IsRequired()
        //            .HasColumnName("etName")
        //            .HasMaxLength(50)
        //            .IsUnicode(false);


        //    });

        //    modelBuilder.Entity<Persons>(entity =>
        //    {
        //        entity.HasKey(e => e.PersonId);

        //        entity.Property(e => e.PersonId)
        //            .HasColumnName("PersonID")
        //            .ValueGeneratedNever();

        //        entity.Property(e => e.Address1)
        //            .IsRequired()
        //            .HasMaxLength(255)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Adress2)
        //            .HasMaxLength(255)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Email)
        //            .IsRequired()
        //            .HasMaxLength(255)
        //            .IsUnicode(false);

        //        entity.Property(e => e.LastName)
        //            .IsRequired()
        //            .HasMaxLength(255)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Name)
        //            .IsRequired()
        //            .HasMaxLength(255)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Password)
        //            .IsRequired()
        //            .HasMaxLength(255)
        //            .IsUnicode(false);

        //        entity.Property(e => e.Type).HasColumnName("type");
        //    });
        //}
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
