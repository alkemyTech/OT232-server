﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OngProject.Entities
{
    public class Activities :BaseEntity
    {
        
        [Required,StringLength(255)]
        public string name { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string content { get; set; }

        [Required,StringLength(255)]
        public string image { get; set; }

        public DateTime deletedAt { get; set; }



    }
}
