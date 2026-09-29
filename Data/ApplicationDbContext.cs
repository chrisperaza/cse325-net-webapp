using Microsoft.EntityFrameworkCore;
using AppointmentBook.Models;

namespace AppointmentBook.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Appointment> Appointments => Set<Appointment>();
}