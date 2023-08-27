using System.Reflection;
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
    private readonly ILogger<MemberService> _logger;

    public MemberService(IMemberRepository memberRepository, IMapper mapper, ILogger<MemberService> logger)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public MemberIndexViewModel QueryMembers(MemberIndexViewModel memberIndexViewModel)
    {
        try
        {
            var members = _memberRepository.QueryMembers(memberIndexViewModel);
            if(members.Any())
                memberIndexViewModel.Members = _mapper.Map<List<MemberModel>>(members);

            SetMemberIndexViewModelConditionList(memberIndexViewModel);

        }
        catch (Exception e)
        {
            _logger.LogWarning($"{MethodBase.GetCurrentMethod()?.Name} Exception, Message:{e}");
            throw;
        }
        
        return memberIndexViewModel;
    }

    private static void SetMemberIndexViewModelConditionList(MemberIndexViewModel memberIndexViewModel)
    {
        var searchCondition = memberIndexViewModel.GetType().GetProperties()
            .FirstOrDefault(p => p.PropertyType == typeof(string) && p.GetValue(memberIndexViewModel) is not null);
        if (searchCondition is null) return;
        foreach (var item in memberIndexViewModel.ConditionList.Where(item => item.Value == searchCondition.Name))
        {
            item.Selected = true;
        }
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
            _logger.LogWarning($"{MethodBase.GetCurrentMethod()?.Name} Exception, Message:{e}");
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
            _logger.LogWarning($"{MethodBase.GetCurrentMethod()?.Name} Exception, Message:{e}");
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