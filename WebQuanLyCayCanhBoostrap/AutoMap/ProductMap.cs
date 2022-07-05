using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class ProductMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Product, ProductDto>();
            AutoMapper.Mapper.CreateMap<ProductDto, Product>();
        }
    }
}