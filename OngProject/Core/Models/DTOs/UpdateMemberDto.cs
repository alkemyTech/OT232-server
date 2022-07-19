using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class UpdateMemberDto
    {
        [Required(ErrorMessage = "El name es obligatorio.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El FacebookUrl es obligatorio.")]
        [StringLength(255)]
        public string FacebookUrl { get; set; }

        [Required(ErrorMessage = "El InstagramUrl es obligatorio.")]
        [StringLength(255)]
        public string InstagramUrl { get; set; }

        [Required(ErrorMessage = "El linkedinUrl es obligatorio.")]
        [StringLength(255)]
        public string LinkedinUrl { get; set; }

        [Required(ErrorMessage = "La Image es obligatorio.")]
        [StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "La Description es obligatorio.")]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
