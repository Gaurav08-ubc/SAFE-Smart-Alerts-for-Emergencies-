using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAFE.Models;

public partial class User
{
    
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    [EmailAddress]
    [Required]
    public string? Email { get; set; }

    [Required]
    [StringLength(100)]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Phone]
    public string? Role { get; set; }

    [StringLength(150)]
    public string? Location { get; set; }

    [Timestamp]
    public byte[] CreatedAt { get; set; } = null!;

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<EmergencyReport> EmergencyReports { get; set; } = new List<EmergencyReport>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
