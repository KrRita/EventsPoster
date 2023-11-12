﻿// <auto-generated />
using System;
using EventsPoster.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventsPoster.DataAccess.Migrations
{
    [DbContext(typeof(EventsPosterDbContext))]
    partial class EventsPosterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.AdminEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("admins");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.BuyingTicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePurchase")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdTicket")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("IdTicket");

                    b.HasIndex("IdUser");

                    b.ToTable("buying tickets");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.DiscountEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("discounts");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.EventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgeViewer")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desctiption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdTypeEvent")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("IdTypeEvent");

                    b.ToTable("events");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.FavoriteEventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdHoldingEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("IdUser");

                    b.ToTable("favorite events");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.FeedbackEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("IdEvent");

                    b.HasIndex("IdUser");

                    b.ToTable("feedbacks");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.HoldingEventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEvent")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("IdEvent");

                    b.ToTable("holding events");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.TicketEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IdDiscount")
                        .HasColumnType("int");

                    b.Property<int>("IdHoldingEvent")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.HasIndex("IdDiscount");

                    b.HasIndex("IdHoldingEvent");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.TypeEventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("types events");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExternalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalId")
                        .IsUnique();

                    b.ToTable("users");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.BuyingTicketEntity", b =>
                {
                    b.HasOne("EventsPoster.DataAccess.Entities.TicketEntity", "Ticket")
                        .WithMany()
                        .HasForeignKey("IdTicket")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventsPoster.DataAccess.Entities.UserEntity", "User")
                        .WithMany("BuyingTickets")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.EventEntity", b =>
                {
                    b.HasOne("EventsPoster.DataAccess.Entities.TypeEventEntity", "TypeEvent")
                        .WithMany("Events")
                        .HasForeignKey("IdTypeEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeEvent");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.FavoriteEventEntity", b =>
                {
                    b.HasOne("EventsPoster.DataAccess.Entities.HoldingEventEntity", "HoldingEvent")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventsPoster.DataAccess.Entities.UserEntity", "User")
                        .WithMany("FavoriteEvents")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoldingEvent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.FeedbackEntity", b =>
                {
                    b.HasOne("EventsPoster.DataAccess.Entities.EventEntity", "Event")
                        .WithMany("Feedbacks")
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventsPoster.DataAccess.Entities.UserEntity", "User")
                        .WithMany("Feedbacks")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.HoldingEventEntity", b =>
                {
                    b.HasOne("EventsPoster.DataAccess.Entities.EventEntity", "Event")
                        .WithMany("Holdings")
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.TicketEntity", b =>
                {
                    b.HasOne("EventsPoster.DataAccess.Entities.DiscountEntity", "Discount")
                        .WithMany("Tickets")
                        .HasForeignKey("IdDiscount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EventsPoster.DataAccess.Entities.HoldingEventEntity", "HoldingEvent")
                        .WithMany("Tickets")
                        .HasForeignKey("IdHoldingEvent")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("HoldingEvent");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.DiscountEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.EventEntity", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Holdings");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.HoldingEventEntity", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.TypeEventEntity", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("EventsPoster.DataAccess.Entities.UserEntity", b =>
                {
                    b.Navigation("BuyingTickets");

                    b.Navigation("FavoriteEvents");

                    b.Navigation("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}
