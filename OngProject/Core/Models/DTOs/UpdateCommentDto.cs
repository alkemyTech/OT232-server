using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models.DTOs
{
    public class UpdateCommentDto
    {
        public int UserId { get; set; }
        public string Body { get; set; }
    }
}
