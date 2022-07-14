using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class SlideMap
    {
        public static void MapCofig()
        {
            AutoMapper.Mapper.CreateMap<Slide, SlideDto>();
            AutoMapper.Mapper.CreateMap<SlideDto, Slide>();
        }
    }
}