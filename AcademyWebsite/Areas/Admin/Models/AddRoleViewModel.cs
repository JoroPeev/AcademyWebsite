using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class AddRoleViewModel
{
    [Required]
    public string RoleName { get; set; }

    [Required]
    public string SelectedUserId { get; set; }

    public IEnumerable<SelectListItem> Users { get; set; }
}