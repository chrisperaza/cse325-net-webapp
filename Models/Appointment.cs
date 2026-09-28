using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentBook.Models;

public class Appointment
{
  public int Id { get; set; }

  public string Title { get; set; } = string.Empty;

  public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

  public TimeOnly StartTime { get; set; } = new TimeOnly(9, 0);

  public TimeOnly EndTime { get; set; } = new TimeOnly(10, 0);

  public string? Location { get; set; }

  public string? Notes { get; set; }

  public bool IsCompleted { get; set; } = false;
}