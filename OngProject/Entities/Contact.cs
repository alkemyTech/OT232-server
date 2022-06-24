using OngProject.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class Contact : BaseEntity
    {
        [StringLength(255)]
        public string Name { get; set; }

        public string Email { get; set; }

        [StringLength(20)]
        public int Phone { get; set; }

        [MaxLengthAttribute]
        public string Message { get; set; }
    }
}
