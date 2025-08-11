using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SAFE.Models;

public partial class Admin
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? Username { get; set; }

    [Required]
    [StringLength(100)]
    public string? Password { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Phone { get; set; }

    [Timestamp]
    public byte[] CreatedAt { get; set; } = null!;

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual ICollection<ResponseTeam> ResponseTeams { get; set; } = new List<ResponseTeam>();
}
