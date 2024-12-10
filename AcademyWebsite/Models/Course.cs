﻿using System.ComponentModel.DataAnnotations;

namespace AcademyWebsite.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public List<Children> Childrens { get; set; } = new List<Children>();


    }
}
