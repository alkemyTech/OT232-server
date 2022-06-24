using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    public class Slide : BaseEntity
    {
        [StringLength(250)]
        public string ImageURL { get; set; }
        
        [StringLength(250)]
        public string Text { get; set; }
        public int Order { get; set; }
        
        [ForeignKey("Organization")]
        public int OrganizationID { get; set; }

        public Organization Organization { get; set; }
    }
}
