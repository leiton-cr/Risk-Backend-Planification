﻿using System;
using System.Collections.Generic;

namespace RiskProject.Models;

public partial class TblProject
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool? Active { get; set; }
}
