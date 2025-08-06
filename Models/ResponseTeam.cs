using System;
using System.Collections.Generic;

namespace SAFE.Models;

public partial class ResponseTeam
{
    public int Id { get; set; }

    public string? TeamName { get; set; }

    public string? Members { get; set; }

    public int AssignedReportId { get; set; }

    public int AssignedBy { get; set; }

    public string? Status { get; set; }

    public byte[] CreatedAt { get; set; } = null!;

    public virtual Admin AssignedByNavigation { get; set; } = null!;

    public virtual EmergencyReport AssignedReport { get; set; } = null!;
}
