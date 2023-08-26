using YCDemoMVC.DBModel;
using YCDemoMVC.Models;

namespace YCDemoMVC.Interfaces;

public interface IMemberRepository
{
    IQueryable<Member> QueryMembers(MemberIndexViewModel memberIndexViewModel);
    Member QueryMemberById(string id);
    Task<bool> InsertAsync(MemberModel member);
    Task<bool> UpdateAsync(MemberModel member);
    IQueryable<Member> RepeatMember(MemberModel memberIndexViewModel);
    bool Delete(string id);
}