using System;
using System.Collections.Generic;

namespace SAFE.Models;

public partial class Feedback
{
    public int Id { get; set; }

    public int SubmittedBy { get; set; }

    public string? Message { get; set; }

    public int? Rating { get; set; }

    public byte[] SubmittedOn { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User SubmittedByNavigation { get; set; } = null!;
}
