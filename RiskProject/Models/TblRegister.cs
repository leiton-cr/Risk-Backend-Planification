using System;
using System.Collections.Generic;

namespace RiskProject.Models;

public partial class TblRegister
{
    public string Id { get; set; } = null!;

    public string? ProjectId { get; set; }

    public string? TaskId { get; set; }

    public string? TaskDescription { get; set; }

    public bool? Active { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual TblProject? Project { get; set; }

    public virtual ICollection<TblDetail> TblDetails { get; set; } = new List<TblDetail>();
}
