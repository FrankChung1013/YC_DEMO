using YCDemoMVC.DBModel;
using YCDemoMVC.Models;

namespace YCDemoMVC.Interfaces;

public interface IMemberRepository
{
    IQueryable<Member> QueryMembers(MemberIndexViewModel memberIndexViewModel);
    Member QueryMemberById(string id);
}