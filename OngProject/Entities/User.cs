using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    public class User : BaseEntity
    {
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(255)]
        public string Photo { get; set; }
        [ForeignKey("Roles")]
        public int RoleID { get; set; }
        public Roles Roles { get; set; }

    }
}
