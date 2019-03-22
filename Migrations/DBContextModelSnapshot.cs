﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace narilearsi.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("narilearsi.ModelDB.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventoEventTypeIdEventTypeId");

                    b.Property<DateTime>("eventDate");

                    b.Property<string>("eventDescription");

                    b.Property<string>("eventName");

                    b.Property<string>("eventStatus");

                    b.HasKey("EventId");

                    b.HasIndex("EventoEventTypeIdEventTypeId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("narilearsi.ModelDB.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("etDescription");

                    b.Property<string>("etName");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventType");
                });

            modelBuilder.Entity("narilearsi.ModelDB.Persons", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("narilearsi.ModelDB.Event", b =>
                {
                    b.HasOne("narilearsi.ModelDB.EventType", "EventoEventTypeId")
                        .WithMany("Event")
                        .HasForeignKey("EventoEventTypeIdEventTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
