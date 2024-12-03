using System.ComponentModel.DataAnnotations;

namespace AcademyWebsite.Models
{
    public class JoinChildViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseAge { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ParentName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int ChildAge { get; set; }
    }

}
