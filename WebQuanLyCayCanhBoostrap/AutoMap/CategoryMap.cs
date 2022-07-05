using AutoMapper;
using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class CategoryMap
    {
        public static void MapConfig()
        {
            Mapper.CreateMap<Category, CategoryDto>()
            .ForMember(des => des.CreatedBy, mos => mos.MapFrom(mo => mo.CreatedBy))
            .ForMember(des => des.CreatedDate, mos => mos.MapFrom(mo => mo.CreatedDate))
            .ForMember(des => des.DisplayOrder, mos => mos.MapFrom(mo => mo.DisplayOrder))
            .ForMember(des => des.Language, mos => mos.MapFrom(mo => mo.Language))
            .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
            .ForMember(des => des.ParentID, mos => mos.MapFrom(mo => mo.ParentID))
            .ForMember(des => des.MetaDescriptions, mos => mos.MapFrom(mo => mo.MetaDescriptions))
            .ForMember(des => des.MetaKeywords, mos => mos.MapFrom(mo => mo.MetaKeywords))
            .ForMember(des => des.MetaTitle, mos => mos.MapFrom(mo => mo.MetaTitle))
            .ForMember(des => des.ModifiedBy, mos => mos.MapFrom(mo => mo.ModifiedBy))
            .ForMember(des => des.ModifiedDate, mos => mos.MapFrom(mo => mo.ModifiedDate))
            .ForMember(des => des.Name, mos => mos.MapFrom(mo => mo.Name))
            .ForMember(des => des.SeoTitle, mos => mos.MapFrom(mo => mo.SeoTitle))
            .ForMember(des => des.ShowOnHome, mos => mos.MapFrom(mo => mo.ShowOnHome))
            .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status));

            Mapper.CreateMap<CategoryDto, Category>()
           .ForMember(des => des.CreatedBy, mos => mos.MapFrom(mo => mo.CreatedBy))
           .ForMember(des => des.CreatedDate, mos => mos.MapFrom(mo => mo.CreatedDate))
           .ForMember(des => des.DisplayOrder, mos => mos.MapFrom(mo => mo.DisplayOrder))
           .ForMember(des => des.Language, mos => mos.MapFrom(mo => mo.Language))
           .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
           .ForMember(des => des.ParentID, mos => mos.MapFrom(mo => mo.ParentID))
           .ForMember(des => des.MetaDescriptions, mos => mos.MapFrom(mo => mo.MetaDescriptions))
           .ForMember(des => des.MetaKeywords, mos => mos.MapFrom(mo => mo.MetaKeywords))
           .ForMember(des => des.MetaTitle, mos => mos.MapFrom(mo => mo.MetaTitle))
           .ForMember(des => des.ModifiedBy, mos => mos.MapFrom(mo => mo.ModifiedBy))
           .ForMember(des => des.ModifiedDate, mos => mos.MapFrom(mo => mo.ModifiedDate))
           .ForMember(des => des.Name, mos => mos.MapFrom(mo => mo.Name))
           .ForMember(des => des.SeoTitle, mos => mos.MapFrom(mo => mo.SeoTitle))
           .ForMember(des => des.ShowOnHome, mos => mos.MapFrom(mo => mo.ShowOnHome))
           .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status));
        }
    }
}