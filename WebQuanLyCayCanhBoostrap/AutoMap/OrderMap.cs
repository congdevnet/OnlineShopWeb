using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class OrderMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Order, OrderDto>();
            AutoMapper.Mapper.CreateMap<OrderDto, Order>();
        }
    }
}