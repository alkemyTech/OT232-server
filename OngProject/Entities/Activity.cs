using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    public class Activity : BaseEntity
    {
        
        [Required,StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Content { get; set; }

        [Required,StringLength(255)]
        public string Image { get; set; }

    }
}
