using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class CategoryRequestDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
