using System;
using System.Collections.Generic;

namespace RiskProject.Models;

public partial class TblDetail
{
    public string Id { get; set; } = null!;

    public string? IdRegister { get; set; }

    public string? RiskDescription { get; set; }

    public string? ImpactDescription { get; set; }

    public string? ProbabilityId { get; set; }

    public string? ImpactId { get; set; }

    public string? Owner { get; set; }

    public string? ResponsePlan { get; set; }

    public string? PriorityId { get; set; }

    public int? Points { get; set; }

    public virtual TblRegister? IdRegisterNavigation { get; set; }

    public virtual TblImpact? Impact { get; set; }

    public virtual TblPriority? Priority { get; set; }

    public virtual TblProbability? Probability { get; set; }
}
