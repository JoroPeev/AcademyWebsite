using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyWebsite.Areas.Admin.Models
{
    public class AssignRoleViewModel
    {
        public string UserId { get; set; }
        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
    }
}