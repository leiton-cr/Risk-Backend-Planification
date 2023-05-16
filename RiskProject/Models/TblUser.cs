using System;
using System.Collections.Generic;

namespace RiskProject.Models;

public partial class TblUser
{
    public string Id { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Pepper { get; set; } = null!;

    public int Salt { get; set; }

    public string Pass { get; set; } = null!;

    public bool? Active { get; set; }
}
