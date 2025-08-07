using System;
using System.Collections.Generic;

namespace SAFE.Models;

public partial class Donation
{
    public int Id { get; set; }

    public int DonorId { get; set; }

    public string? ItemOrAmount { get; set; }

    public byte[] Date { get; set; } = null!;

    public string? UsedFor { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Donor { get; set; } = null!;
}
