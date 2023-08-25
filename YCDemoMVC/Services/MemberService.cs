using AutoMapper;
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

        return _mapper.Map<MemberModel>(member);
    }
}