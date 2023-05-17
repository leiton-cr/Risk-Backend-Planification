namespace RiskProject.Dtos
{
    public class DetailDTO
    {
        public Guid Id { get; set; }
        public string RiskDescription { get; set; } = string.Empty;
        public string ImpactDescription { get; set; } = string.Empty;
        public Guid ProbabilityId { get; set; }
        public Guid ImpactId { get; set; }
        public string Owner { get; set; } = string.Empty;
        public string ResponsePlan { get; set; } = string.Empty;
        public Guid PriorityId { get; set; }
        public int Points { get; set; }
    }
}