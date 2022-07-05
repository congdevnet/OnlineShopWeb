using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class MenuTypeMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<MenuType, MenuTypeDto>();
            AutoMapper.Mapper.CreateMap<MenuTypeDto, MenuType>();
        }
    }
}