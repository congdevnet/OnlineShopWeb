
using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class ContentMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Content, ContentDto>()
                .ForMember(des => des.CategoryID, mo => mo.MapFrom(mos => mos.CategoryID))
                .ForMember(des => des.CreatedBy, mo => mo.MapFrom(mos => mos.CreatedBy))
                .ForMember(des => des.CreatedDate, mo => mo.MapFrom(mos => mos.CreatedDate))
                .ForMember(des => des.Description, mo => mo.MapFrom(mos => mos.Description))
                .ForMember(des => des.Detail, mo => mo.MapFrom(mos => mos.Detail))
                .ForMember(des => des.ID, mo => mo.MapFrom(mos => mos.ID))
                .ForMember(des => des.Image, mo => mo.MapFrom(mos => mos.Image))
                .ForMember(des => des.Language, mo => mo.MapFrom(mos => mos.Language))
                .ForMember(des => des.MetaDescriptions, mo => mo.MapFrom(mos => mos.MetaDescriptions))
                .ForMember(des => des.MetaKeywords, mo => mo.MapFrom(mos => mos.MetaKeywords))
                .ForMember(des => des.MetaTitle, mo => mo.MapFrom(mos => mos.MetaTitle))
                .ForMember(des => des.ModifiedBy, mo => mo.MapFrom(mos => mos.ModifiedBy))
                .ForMember(des => des.ModifiedDate, mo => mo.MapFrom(mos => mos.ModifiedDate))
                .ForMember(des => des.Name, mo => mo.MapFrom(mos => mos.Name))
                .ForMember(des => des.Status, mo => mo.MapFrom(mos => mos.Status))
                .ForMember(des => des.Tags, mo => mo.MapFrom(mos => mos.Tags))
                .ForMember(des => des.TopHot, mo => mo.MapFrom(mos => mos.TopHot))
                .ForMember(des => des.ViewCount, mo => mo.MapFrom(mos => mos.ViewCount))
                .ForMember(des => des.Warranty, mo => mo.MapFrom(mos => mos.Warranty));

            AutoMapper.Mapper.CreateMap<ContentDto, Content>()
               .ForMember(des => des.CategoryID, mo => mo.MapFrom(mos => mos.CategoryID))
               .ForMember(des => des.CreatedBy, mo => mo.MapFrom(mos => mos.CreatedBy))
               .ForMember(des => des.CreatedDate, mo => mo.MapFrom(mos => mos.CreatedDate))
               .ForMember(des => des.Description, mo => mo.MapFrom(mos => mos.Description))
               .ForMember(des => des.Detail, mo => mo.MapFrom(mos => mos.Detail))
               .ForMember(des => des.ID, mo => mo.MapFrom(mos => mos.ID))
               .ForMember(des => des.Image, mo => mo.MapFrom(mos => mos.Image))
               .ForMember(des => des.Language, mo => mo.MapFrom(mos => mos.Language))
               .ForMember(des => des.MetaDescriptions, mo => mo.MapFrom(mos => mos.MetaDescriptions))
               .ForMember(des => des.MetaKeywords, mo => mo.MapFrom(mos => mos.MetaKeywords))
               .ForMember(des => des.MetaTitle, mo => mo.MapFrom(mos => mos.MetaTitle))
               .ForMember(des => des.ModifiedBy, mo => mo.MapFrom(mos => mos.ModifiedBy))
               .ForMember(des => des.ModifiedDate, mo => mo.MapFrom(mos => mos.ModifiedDate))
               .ForMember(des => des.Name, mo => mo.MapFrom(mos => mos.Name))
               .ForMember(des => des.Status, mo => mo.MapFrom(mos => mos.Status))
               .ForMember(des => des.Tags, mo => mo.MapFrom(mos => mos.Tags))
               .ForMember(des => des.TopHot, mo => mo.MapFrom(mos => mos.TopHot))
               .ForMember(des => des.ViewCount, mo => mo.MapFrom(mos => mos.ViewCount))
               .ForMember(des => des.Warranty, mo => mo.MapFrom(mos => mos.Warranty));
        }
    }

}
