using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class ContentTagMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<ContentTag, ContentTagDto>();

            AutoMapper.Mapper.CreateMap<ContentTagDto, ContentTag>();
        }
    }
}