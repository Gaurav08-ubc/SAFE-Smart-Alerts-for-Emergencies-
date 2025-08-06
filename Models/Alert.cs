using System;
using System.Collections.Generic;

namespace SAFE.Models;

public partial class Alert
{
    public int Id { get; set; }

    public string? Message { get; set; }

    public string? SeverityLevel { get; set; }

    public byte[] AlertTime { get; set; } = null!;

    public int IssuedBy { get; set; }

    public int? RelatedReportId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Admin IssuedByNavigation { get; set; } = null!;

    public virtual EmergencyReport? RelatedReport { get; set; }
}
