using YCDemoMVC.Models;

namespace YCDemoMVC.Interfaces;

public interface IMemberService
{
      MemberIndexViewModel QueryMembers(MemberIndexViewModel memberIndexViewModel);
      MemberModel QueryMemberById(string id);
}