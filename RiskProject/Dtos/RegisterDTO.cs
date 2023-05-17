using System.ComponentModel.DataAnnotations;

namespace RiskProject.Dtos
{
    public class RegisterDTO
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TaskId { get; set; }
        public string TaskDescription { get; set; } = string.Empty;
        [Required]
        public virtual ICollection<DetailDTO> Details { get; set; } = new List<DetailDTO>();
        public DateTime UpdatedAt { get; set; }
    }
}