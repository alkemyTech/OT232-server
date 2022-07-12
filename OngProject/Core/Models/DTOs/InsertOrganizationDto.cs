using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertOrganizationDto
    {
        [Required(ErrorMessage = "El Name es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La Image es obligatorio.")]
        public string Image { get; set; }
        [Required(ErrorMessage = "El Address es obligatorio.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El Phone es obligatorio.")]
        public int Phone { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio.")]
        public string Email { get; set; }

        [Required]
        public string WelcomeText { get; set; }
        public string AboutUsText { get; set; }

        [Required]
        public string FacebookUrl { get; set; }

        [Required]
        public string InstagramUrl { get; set; }

        [Required] 
        public string LinkedinUrl { get; set; }
    }
}
