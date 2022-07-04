using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models.DTOs
{
    public class InsertMemberDto
    {
        [Required(ErrorMessage = "El atributo debe ser string.")]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        public string FacebookUrl { get; set; }

        [StringLength(255)]
        public string InstagramUrl { get; set; }

        [StringLength(255)]
        public string LinkedinUrl { get; set; }
    }
}
