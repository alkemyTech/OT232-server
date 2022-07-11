using OngProject.Entities;

namespace OngProject.Core.Models.DTOs
{
    public class SlideOrganizationDto
    {
        public string ImageURL { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public OrganizationDto Organization { get; set; }
    }
}
