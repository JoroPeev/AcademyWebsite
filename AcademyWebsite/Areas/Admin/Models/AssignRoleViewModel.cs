using Microsoft.AspNetCore.Mvc.Rendering;

namespace AcademyWebsite.Areas.Admin.Models
{
    public class AssignRoleViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
