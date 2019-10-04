using AutoMapper;
using Post_Surfer.Contract.Response;
using Post_Surfer.Contract.V1.Response;
using Post_Surfer.Domain;
using System.Linq;

namespace Post_Surfer.MappingProfiles
{
    public class DomainToResponseProfile: Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostsResponse>().ForMember(dest=>dest.Tags,opt=>opt.MapFrom(src=>src.Tags.Select(x=>new TagResponse { Name=x.TagName})));
            CreateMap<Tag, TagResponse>();

        }
    }
}
