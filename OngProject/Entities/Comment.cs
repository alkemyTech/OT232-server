using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Entities
{
    public class Comment : BaseEntity
    {

        public int UserId { get; set; }
        public string Body { get; set; }

        [ForeignKey("News")]
        public int NewsID { get; set; }
        public News News { get; set; }
    }
}
