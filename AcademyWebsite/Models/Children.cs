using System.ComponentModel.DataAnnotations;

namespace AcademyWebsite.Models
{
    public class Children
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ParentName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int ChildAge { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
