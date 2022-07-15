using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Organization : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        public string Address { get; set; }

        [Phone]
        public int Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string WelcomeText { get; set; }
        public string AboutUsText { get; set; }

        [Url]
        [Required]
        public string FacebookUrl { get; set; }

        [Url]
        [Required]
        public string InstagramUrl { get; set; }

        [Url]
        [Required]
        public string LinkedinUrl { get; set; }
    }
}
