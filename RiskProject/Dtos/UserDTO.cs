using System.ComponentModel.DataAnnotations;

namespace RiskBackend.Dto
{
    public class UserDTO
    {
        [Required]
        [StringLength(35)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(35)]
        public string Pass { get; set; } = null!;
    }
}