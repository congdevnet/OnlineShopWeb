using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class ProductMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Product, ProductDto>()
           .ForMember(des => des.CreatedBy, mos => mos.MapFrom(mo => mo.CreatedBy))
           .ForMember(des => des.CreatedDate, mos => mos.MapFrom(mo => mo.CreatedDate))
           .ForMember(des => des.PromotionPrice, mos => mos.MapFrom(mo => mo.PromotionPrice))
           .ForMember(des => des.CategoryID, mos => mos.MapFrom(mo => mo.CategoryID))
           .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
           .ForMember(des => des.Code, mos => mos.MapFrom(mo => mo.Code))
           .ForMember(des => des.MetaDescriptions, mos => mos.MapFrom(mo => mo.MetaDescriptions))
           .ForMember(des => des.MetaKeywords, mos => mos.MapFrom(mo => mo.MetaKeywords))
           .ForMember(des => des.MetaTitle, mos => mos.MapFrom(mo => mo.MetaTitle))
           .ForMember(des => des.ModifiedBy, mos => mos.MapFrom(mo => mo.ModifiedBy))
           .ForMember(des => des.ModifiedDate, mos => mos.MapFrom(mo => mo.ModifiedDate))
           .ForMember(des => des.Name, mos => mos.MapFrom(mo => mo.Name))
            .ForMember(des => des.IncludedVAT, mos => mos.MapFrom(mo => mo.IncludedVAT))
            .ForMember(des => des.MoreImages, mos => mos.MapFrom(mo => mo.MoreImages))
            .ForMember(des => des.Price, mos => mos.MapFrom(mo => mo.Price))
            .ForMember(des => des.Quantity, mos => mos.MapFrom(mo => mo.Quantity))
            .ForMember(des => des.Warranty, mos => mos.MapFrom(mo => mo.Warranty))
            .ForMember(des => des.TopHot, mos => mos.MapFrom(mo => mo.TopHot))
            .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status));

            AutoMapper.Mapper.CreateMap<ProductDto, Product>()
            .ForMember(des => des.CreatedBy, mos => mos.MapFrom(mo => mo.CreatedBy))
            .ForMember(des => des.CreatedDate, mos => mos.MapFrom(mo => mo.CreatedDate))
            .ForMember(des => des.PromotionPrice, mos => mos.MapFrom(mo => mo.PromotionPrice))
            .ForMember(des => des.CategoryID, mos => mos.MapFrom(mo => mo.CategoryID))
            .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
            .ForMember(des => des.Code, mos => mos.MapFrom(mo => mo.Code))
            .ForMember(des => des.MetaDescriptions, mos => mos.MapFrom(mo => mo.MetaDescriptions))
            .ForMember(des => des.MetaKeywords, mos => mos.MapFrom(mo => mo.MetaKeywords))
            .ForMember(des => des.MetaTitle, mos => mos.MapFrom(mo => mo.MetaTitle))
            .ForMember(des => des.ModifiedBy, mos => mos.MapFrom(mo => mo.ModifiedBy))
            .ForMember(des => des.ModifiedDate, mos => mos.MapFrom(mo => mo.ModifiedDate))
            .ForMember(des => des.Name, mos => mos.MapFrom(mo => mo.Name))
            .ForMember(des => des.IncludedVAT, mos => mos.MapFrom(mo => mo.IncludedVAT))
            .ForMember(des => des.MoreImages, mos => mos.MapFrom(mo => mo.MoreImages))
            .ForMember(des => des.Price, mos => mos.MapFrom(mo => mo.Price))
            .ForMember(des => des.Quantity, mos => mos.MapFrom(mo => mo.Quantity))
            .ForMember(des => des.Warranty, mos => mos.MapFrom(mo => mo.Warranty))
            .ForMember(des => des.TopHot, mos => mos.MapFrom(mo => mo.TopHot))
            .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status));
        }
    }
}