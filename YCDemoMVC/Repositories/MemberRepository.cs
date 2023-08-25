using Microsoft.EntityFrameworkCore;
using YCDemoMVC.DBModel;
using YCDemoMVC.Interfaces;
using YCDemoMVC.Models;

namespace YCDemoMVC.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly YCDemoContext _context;

    public MemberRepository(YCDemoContext context)
    {
        _context = context;
    }

    public IQueryable<Member> QueryMembers(MemberIndexViewModel memberIndexViewModel)
    {
        var memberQueryable = _context.Members.AsQueryable().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(memberIndexViewModel.NameCondition))
            memberQueryable = memberQueryable.Where(d => d.Name == memberIndexViewModel.NameCondition);
        if (!string.IsNullOrWhiteSpace(memberIndexViewModel.EmailCondition))
            memberQueryable = memberQueryable.Where(d => d.Email == memberIndexViewModel.EmailCondition);
        if (!string.IsNullOrWhiteSpace(memberIndexViewModel.IdentityNumberCondition))
            memberQueryable = memberQueryable.Where(d => d.IdentityNumber == memberIndexViewModel.IdentityNumberCondition);

        return memberQueryable;
    }

    public Member QueryMemberById(string id)
    {
        var member = _context.Members.AsQueryable().AsNoTracking().First(d =>d.Id == int.Parse(id));

        return member;
    }
}