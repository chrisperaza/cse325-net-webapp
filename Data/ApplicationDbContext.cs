using AppointmentBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBook.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(user => user.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasMany(user => user.Appointments)
            .WithOne(appointment => appointment.User)
            .HasForeignKey(appointment => appointment.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}