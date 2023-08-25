using AutoMapper;
using YCDemoMVC.DBModel;
using YCDemoMVC.Models;

namespace YCDemoMVC.Extentions;

public class AutoMapperExtension : Profile
{
    public AutoMapperExtension()
    {
        CreateMap<Member, MemberModel>().ReverseMap()
            .ForMember(x => x.Birthday, y => y.Ignore());

        CreateMap<MemberModel, Member>().ReverseMap()
            .ForMember(x => x.Birthday, y => y.Ignore());
    }
}