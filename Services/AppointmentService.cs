using AppointmentBook.Data;
using AppointmentBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBook.Services;

public class AppointmentService
{
  private readonly ApplicationDbContext _context;

  public AppointmentService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Appointment> CreateAsync(
    AppointmentInputModel input,
    int userId)
  {
    if (input.Time is null)
    {
      throw new ArgumentException("Appointment time is required.");
    }

    var appointmentDateTime = input.Date.ToDateTime(input.Time.Value);

    var appointment = new Appointment
    {
      Title = input.Title.Trim(),
      Date = appointmentDateTime,
      Time = input.Time.Value.ToTimeSpan(),
      Location = input.Location.Trim(),
      Notes = input.Notes.Trim(),
      IsCompleted = false,
      UserId = userId
    };

    _context.Appointments.Add(appointment);

    await _context.SaveChangesAsync();

    return appointment;
  }
}