using System.Reflection;
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
    private readonly ILogger<MemberRepository> _logger;

    public MemberRepository(YCDemoContext context, IMapper mapper, ILogger<MemberRepository> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
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
        if (!string.IsNullOrWhiteSpace(memberIndexViewModel.PhoneNumberCondition))
            memberQueryable = memberQueryable.Where(d => d.PhoneNumber == memberIndexViewModel.PhoneNumberCondition);
        
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
            createMember.CreateDate = DateTime.Now;
            await _context.Members.AddAsync(createMember);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogWarning($"{MethodBase.GetCurrentMethod()?.Name} Exception, Message:{e}");
            throw;
        }

        return true;
    }

    public async Task<bool> UpdateAsync(MemberModel member)
    {
        try
        {
            var updateMember = _mapper.Map<Member>(member);
            updateMember.UpdateDate = DateTime.Now;
            _context.Members.Update(updateMember);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogWarning($"{MethodBase.GetCurrentMethod()?.Name} Exception, Message:{e}");
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
            _logger.LogWarning($"{MethodBase.GetCurrentMethod()?.Name} Exception, Message:{e}");
            throw;
        }

        return true;
    }
}