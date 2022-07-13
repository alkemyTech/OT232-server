using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class InsertSlideDto
    {
        public string ImageURL { get; set; }
        public string Text { get; set; }
        public string Order { get; set; }
        public int OrganizationID { get; set; }
    }
}
