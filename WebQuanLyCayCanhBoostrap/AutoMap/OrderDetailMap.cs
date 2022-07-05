using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class OrderDetailMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<OrderDetail, OrderDetailDto>();
            AutoMapper.Mapper.CreateMap<OrderDetailDto, OrderDetail>();
        }
    }
}