using System;
using System.Collections.Generic;

namespace RiskProject.Models;

public partial class TblImpact
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? Value { get; set; }

    public bool? Active { get; set; }
}
