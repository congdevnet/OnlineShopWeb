using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class FooterMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Footer, FooterDto>();
            AutoMapper.Mapper.CreateMap<FooterDto, Footer>();
        }
    }
}