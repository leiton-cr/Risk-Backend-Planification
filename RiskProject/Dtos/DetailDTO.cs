namespace RiskProject.Dtos
{
    public class DetailDTO
    {
        public string Id { get; set; } = null!;
        public string RiskDescription { get; set; } = string.Empty;
        public string ImpactDescription { get; set; } = string.Empty;
        public string ProbabilityId { get; set; } = null!;
        public string ImpactId { get; set; } = null!;
        public string Owner { get; set; } = string.Empty;
        public string ResponsePlan { get; set; } = string.Empty;
        public string PriorityId { get; set; } = null!;
        public int Points { get; set; }
    }
}