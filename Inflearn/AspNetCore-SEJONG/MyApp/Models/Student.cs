using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Range(15, 70)]
        public int Age { get; set; }

        [MinLength(3)]
        [Required]
        public string Country { get; set; }
    }
}
