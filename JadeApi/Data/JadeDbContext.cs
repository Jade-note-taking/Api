using JadeApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace JadeApi.Data;

public class JadeDbContext(DbContextOptions<JadeDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<UpcomingShow>()
        //     .HasOne(s => s.Room)
        //     .WithMany(r => r.Shows)
        //     .HasForeignKey(s => s.RoomId)
        //     .IsRequired();
        //
        // modelBuilder.Entity<UpcomingShow>()
        //     .HasOne(s => s.Showing)
        //     .WithMany(sh => sh.Shows)
        //     .HasForeignKey(s => s.ShowingId)
        //     .IsRequired();
        //
        // modelBuilder.Entity<Ticket>()
        //     .HasOne(t => t.UpcomingShow)
        //     .WithMany(s => s.Tickets)
        //     .HasForeignKey(t => t.UpcomingShowId)
        //     .IsRequired();
        
        // EF Data seeding, see: https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
        // modelBuilder.Entity<User>().HasData(DefaultDbData.Users);
        // modelBuilder.Entity<Showing>().HasData(DefaultDbData.Showings);
        // modelBuilder.Entity<Room>().HasData(DefaultDbData.Rooms);
        // modelBuilder.Entity<UpcomingShow>().HasData(DefaultDbData.Shows);
        // modelBuilder.Entity<Arrangement>().HasData(DefaultDbData.Arrangements);
        // modelBuilder.Entity<FoundItem>().HasData(DefaultDbData.FoundItems);
    }

    public DbSet<Note> Notes { get; set; }
}
