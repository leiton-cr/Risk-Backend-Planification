using System.ComponentModel.DataAnnotations;

namespace RiskProject.Dtos
{
    public class RegisterDTO
    {
        public string Id { get; set; } = null!;
        public string ProjectId { get; set; } = null!;
        public string TaskId { get; set; } = null!;
        public string TaskDescription { get; set; } = string.Empty;
        [Required]
        public virtual ICollection<DetailDTO> Details { get; set; } = new List<DetailDTO>();
    }
}