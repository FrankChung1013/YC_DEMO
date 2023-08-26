using Microsoft.AspNetCore.Mvc.Rendering;

namespace YCDemoMVC.Models;

public class MemberModifyViewModel
{
    public List<SelectListItem> SexSelectList { get; set; }
    public MemberModel MemberModel { get; set; } = new MemberModel();
}