using AutoMapper;
using YCDemoMVC.DBModel;
using YCDemoMVC.Models;

namespace YCDemoMVC.Extentions;

public class AutoMapperExtension : Profile
{
    public AutoMapperExtension()
    {
        CreateMap<Member, MemberModel>()
            .ForMember(x => x.Birthday, y => y.MapFrom(o => o.Birthday.ToString("yyyy-MM-dd")))
            .ReverseMap();

        // CreateMap<MemberModel, Member>().ReverseMap()
        //     .ForMember(x => x.Birthday, y => y.Ignore());
    }
}