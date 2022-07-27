using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class TemporaryShoppingCartMap
    {
        public static void Maponfig()
        {
            AutoMapper.Mapper.CreateMap<TemporaryShoppingCart, TemporaryShoppingCartDto>();
            AutoMapper.Mapper.CreateMap<TemporaryShoppingCartDto, TemporaryShoppingCart>();
        }
    }
}