using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YCDemoMVC.DBModel;
using YCDemoMVC.Interfaces;
using YCDemoMVC.Models;

namespace YCDemoMVC.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly YCDemoContext _context;
    private readonly IMapper _mapper;

    public MemberRepository(YCDemoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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
        var member = _context.Members.AsQueryable().AsNoTracking().First(d => d.Id == int.Parse(id));

        return member;
    }

    public async Task<bool> InsertAsync(MemberModel member)
    {
        try
        {
            var createMember = _mapper.Map<Member>(member);
            await _context.Members.AddAsync(createMember);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }

    public async Task<bool> UpdateAsync(MemberModel member)
    {
        try
        {
            var updateMember = _mapper.Map<Member>(member);
            _context.Members.Update(updateMember);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }

    public IQueryable<Member> RepeatMember(MemberModel member)
    {
        var repeatMember = _context.Members.AsQueryable().AsNoTracking().Where(d =>
            d.IdentityNumber == member.IdentityNumber || d.Email == member.Email ||
            d.PhoneNumber == member.PhoneNumber);

        if (member.Id > 0) repeatMember = repeatMember.Where(d => d.Id != member.Id);
        
        return repeatMember;
    }

    public bool Delete(string id)
    {
        try
        {
            _context.Members.Remove(this.QueryMemberById(id));
            _context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }
}