using System;
using System.Collections.Generic;

namespace SAFE.Models;

public partial class EmergencyReport
{
    public int Id { get; set; }

    public int ReportedBy { get; set; }

    public string? Location { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string? Address { get; set; }

    public string? Description { get; set; }

    public byte[] Date { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual User ReportedByNavigation { get; set; } = null!;

    public virtual ICollection<ResponseTeam> ResponseTeams { get; set; } = new List<ResponseTeam>();
}
