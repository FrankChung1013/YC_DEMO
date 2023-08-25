namespace YCDemoMVC.Models;

public class MemberIndexViewModel
{
    public string NameCondition { get; set; }
    public string IdentityNumberCondition { get; set; }
    public string EmailCondition { get; set; }
    public List<MemberModel> Members { get; set; } = new List<MemberModel>();
}

public class MemberModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Sex { get; set; }
    public string Birthday { get; set; }
    public string IdentityNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}