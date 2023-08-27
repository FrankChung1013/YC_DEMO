using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace YCDemoMVC.Models;

public class MemberIndexViewModel
{
    public string NameCondition { get; set; }
    public string IdentityNumberCondition { get; set; }
    public string EmailCondition { get; set; }
    public string PhoneNumberCondition { get; set; }
    public List<SelectListItem> ConditionList { get; set; }
    public List<MemberModel> Members { get; set; } = new List<MemberModel>();

    public MemberIndexViewModel()
    {
        this.ConditionList = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = "Name",
                Value = "NameCondition"
            },
            new SelectListItem
            {
                Text = "IdentityNumber",
                Value = "IdentityNumberCondition"
            },
            new SelectListItem
            {
                Text = "Email",
                Value = "EmailCondition"
            },
            new SelectListItem
            {
                Text = "PhoneNumber",
                Value = "PhoneNumberCondition"
            },
        };
    }
}

public class MemberModel
{
    public int Id { get; set; } = 0;
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Sex is required")]
    public string Sex { get; set; }
    [Required(ErrorMessage = "Birthday is required")]
    public string Birthday { get; set; }
    [Required(ErrorMessage = "IdentityNumber is required")]
    public string IdentityNumber { get; set; }
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    [Required(ErrorMessage = "PhoneNumber is required")]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }
}