using System;
using System.Collections.Generic;

namespace SAFE.Models;

public partial class Notification
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Message { get; set; }

    public string? Type { get; set; }

    public byte[] SentTime { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
