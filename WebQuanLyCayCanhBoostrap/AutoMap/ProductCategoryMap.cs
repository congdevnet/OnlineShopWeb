using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class ProductCategoryMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<ProductCategory, ProductCategoryDto>();
            AutoMapper.Mapper.CreateMap<ProductCategoryDto, ProductCategory>();
        }
    }
}