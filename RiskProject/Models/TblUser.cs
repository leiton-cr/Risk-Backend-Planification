using System;
using System.Collections.Generic;

namespace RiskProject.Models;

public partial class TblUser
{
    public string Id { get; set; } = null!;

    public string? Email { get; set; }

    public string? Pepper { get; set; }

    public int Salt { get; set; }

    public string? Pass { get; set; }

    public bool? Active { get; set; }
}
