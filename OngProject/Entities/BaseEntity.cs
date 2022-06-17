﻿using System;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; }
    }
}
