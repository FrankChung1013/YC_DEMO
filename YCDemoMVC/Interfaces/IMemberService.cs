using YCDemoMVC.Models;

namespace YCDemoMVC.Interfaces;

public interface IMemberService
{
      MemberIndexViewModel QueryMembers(MemberIndexViewModel memberIndexViewModel);
      MemberModel QueryMemberById(string id);
      Task<bool> InsertAsync(MemberModel member);
      Task<bool> UpdateAsync(MemberModel member);
      bool Delete(string id);
}