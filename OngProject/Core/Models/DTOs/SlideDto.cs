using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class SlideDto
    {
        public string ImageURL { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
    }
}
