namespace AppointmentBook.Models;

public class Appointment
{
  public int Id { get; set; }

  public string Title { get; set; } = string.Empty;

  public DateTime Date { get; set; }

  public TimeSpan Time { get; set; }

  public string Location { get; set; } = string.Empty;

  public string Notes { get; set; } = string.Empty;

  public bool IsCompleted { get; set; }
}