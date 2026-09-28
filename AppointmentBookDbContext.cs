using Microsoft.EntityFrameworkCore;

public class AppointmentBookDbContext(DbContextOptions<AppointmentBookDbContext> options) : DbContext(options)
{
    public DbSet<AppointmentBook.Models.Appointment> Appointment { get; set; } = default!;
}
