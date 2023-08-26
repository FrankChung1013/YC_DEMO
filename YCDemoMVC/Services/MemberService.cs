using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YCDemoMVC.DBModel;
using YCDemoMVC.Interfaces;
using YCDemoMVC.Models;

namespace YCDemoMVC.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public MemberService(IMemberRepository memberRepository, IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public MemberIndexViewModel QueryMembers(MemberIndexViewModel memberIndexViewModel)
    {
        try
        {
            var members = _memberRepository.QueryMembers(memberIndexViewModel);
            if(members.Any())
                memberIndexViewModel.Members = _mapper.Map<List<MemberModel>>(members);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return memberIndexViewModel;
    }

    public MemberModel QueryMemberById(string id)
    {
        var member = _memberRepository.QueryMemberById(id);
        var memberModel = _mapper.Map<MemberModel>(member);
        memberModel.Birthday = member.Birthday.ToString("yyyy-MM-dd");

        return memberModel;
    }

    public async Task<bool> InsertAsync(MemberModel member)
    {
        try
        {
            var repeatMember = _memberRepository.RepeatMember(member);
            if (await repeatMember.AnyAsync())
                return false;
        
            await _memberRepository.InsertAsync(member);
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
            var repeatMember = _memberRepository.RepeatMember(member);
            if (await repeatMember.AnyAsync())
                return false;

            await _memberRepository.UpdateAsync(member);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }

    public bool Delete(string id)
    {
        var result = _memberRepository.Delete(id);

        return result;
    }
}