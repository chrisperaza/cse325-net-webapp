using System.ComponentModel.DataAnnotations;

namespace AppointmentBook.Models;

public class Appointment
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public TimeSpan Time { get; set; }

    [StringLength(200)]
    public string Location { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Notes { get; set; } = string.Empty;

    public bool IsCompleted { get; set; } = false;

    public int UserId { get; set; }

    public User? User { get; set; }
}