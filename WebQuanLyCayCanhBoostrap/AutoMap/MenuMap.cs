using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class MenuMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Menu, MenuDto>();
            AutoMapper.Mapper.CreateMap<MenuDto, Menu>();
        }
    }
}