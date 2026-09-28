using Microsoft.EntityFrameworkCore;
using AppointmentBook.Models;

namespace AppointmentBook.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppointmentBookDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<AppointmentBookDbContext>>());

        if (context == null || context.Appointment == null)
        {
            throw new NullReferenceException(
                "Null AppointmentBookDbContext or Appointment DbSet");
        }

        if (context.Appointment.Any())
        {
            return;
        }

        context.Appointment.AddRange(
            new Appointment
            {
                Title = "Medical Consultation",
                Date = new DateOnly(2026, 10, 5),
                StartTime = new TimeOnly(9, 0),
                EndTime = new TimeOnly(9, 45),
                Location = "St. Jude Medical Center - Suite 302",
                Notes = "Ask for annual blood test results.",
                IsCompleted = false
            },
            new Appointment
            {
                Title = "Haircut and Styling",
                Date = new DateOnly(2026, 10, 6),
                StartTime = new TimeOnly(14, 30),
                EndTime = new TimeOnly(15, 30),
                Location = "Urban Barber & Style Studio, 450 Main St",
                Notes = "-",
                IsCompleted = false
            },
            new Appointment
            {
                Title = "Legal Advisory Meeting",
                Date = new DateOnly(2026, 10, 8),
                StartTime = new TimeOnly(11, 0),
                EndTime = new TimeOnly(12, 0),
                Location = "Microsoft Teams (Virtual Meeting)",
                Notes = "Final review of clauses for the commercial lease agreement.",
                IsCompleted = false
            });

        context.SaveChanges();
    }
}