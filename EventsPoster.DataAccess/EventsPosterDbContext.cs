using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsPoster.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsPoster.DataAccess
{
    public class EventsPosterDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<BuyingTicketEntity> BuyingsTickets { get; set; }
        public DbSet<DiscountEntity> Discounts { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<FavoriteEventEntity> FavoriteEvents { get; set;}
        public DbSet<FeedbackEntity> Feedbacks { get; set; }
        public DbSet<HoldingEventEntity> HoldingsEvents { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<EventType> TypesEvents { get; set; }
        

        public EventsPosterDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>().HasIndex(x => x.ExternalId).IsUnique();


            modelBuilder.Entity<AdminEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<AdminEntity>().HasIndex(x => x.ExternalId).IsUnique();


            modelBuilder.Entity<BuyingTicketEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<BuyingTicketEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<BuyingTicketEntity>().HasOne(x => x.User)
                                                     .WithMany(x => x.BuyingTickets)
                                                     .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<BuyingTicketEntity>().HasOne(x => x.Ticket)
                                                     .WithMany()
                                                     .HasForeignKey(x => x.TicketId);


            modelBuilder.Entity<DiscountEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<DiscountEntity>().HasIndex(x => x.ExternalId).IsUnique();


            modelBuilder.Entity<EventEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<EventEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<EventEntity>().HasOne(x => x.EventType)
                                              .WithMany(x => x.Events)
                                              .HasForeignKey(x => x.TypeEventId);


            modelBuilder.Entity<FavoriteEventEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<FavoriteEventEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<FavoriteEventEntity>().HasOne(x => x.User)
                                                      .WithMany(x => x.FavoriteEvents)
                                                      .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<FavoriteEventEntity>().HasOne(x => x.HoldingEvent)
                                                      .WithMany()
                                                      .HasForeignKey(x => x.HoldingEventId);


            modelBuilder.Entity<FeedbackEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<FeedbackEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<FeedbackEntity>().HasOne(x => x.User)
                                                 .WithMany(x=>x.Feedbacks)
                                                 .HasForeignKey(x=>x.UserId);
            modelBuilder.Entity<FeedbackEntity>().HasOne(x => x.Event)
                                                 .WithMany(x => x.Feedbacks)
                                                 .HasForeignKey(x => x.EventId);


            modelBuilder.Entity<HoldingEventEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<HoldingEventEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<HoldingEventEntity>().HasOne(x => x.Event)
                                                     .WithMany(x => x.Holdings)
                                                     .HasForeignKey(x => x.EventId);


            modelBuilder.Entity<TicketEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TicketEntity>().HasIndex(x => x.ExternalId).IsUnique();
            modelBuilder.Entity<TicketEntity>().HasOne(x => x.HoldingEvent)
                                               .WithMany(x => x.Tickets)
                                               .HasForeignKey(x => x.HoldingEventId);
            modelBuilder.Entity<TicketEntity>().HasOne(x => x.Discount)
                                               .WithMany(x => x.Tickets)
                                               .HasForeignKey(x => x.DiscountId);


            modelBuilder.Entity<EventType>().HasKey(x => x.Id);
            modelBuilder.Entity<EventType>().HasIndex(x => x.ExternalId).IsUnique();
        }
    }
}
