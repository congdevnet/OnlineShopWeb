using AutoMapper;
using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class AboutMap
    {
        public static void MapConfig()
        {
            Mapper.CreateMap<About, AboutDto>()
            .ForMember(des => des.CreatedBy, mos => mos.MapFrom(mo => mo.CreatedBy))
            .ForMember(des => des.CreatedDate, mos => mos.MapFrom(mo => mo.CreatedDate))
            .ForMember(des => des.Description, mos => mos.MapFrom(mo => mo.Description))
            .ForMember(des => des.Detail, mos => mos.MapFrom(mo => mo.Detail))
            .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
            .ForMember(des => des.Image, mos => mos.MapFrom(mo => mo.Image))
            .ForMember(des => des.MetaDescriptions, mos => mos.MapFrom(mo => mo.MetaDescriptions))
            .ForMember(des => des.MetaKeywords, mos => mos.MapFrom(mo => mo.MetaKeywords))
            .ForMember(des => des.MetaTitle, mos => mos.MapFrom(mo => mo.MetaTitle))
            .ForMember(des => des.ModifiedBy, mos => mos.MapFrom(mo => mo.ModifiedBy))
            .ForMember(des => des.ModifiedDate, mos => mos.MapFrom(mo => mo.ModifiedDate))
            .ForMember(des => des.Name, mos => mos.MapFrom(mo => mo.Name))
            .ForMember(des => des.Ngaytao, mos => mos.MapFrom(mo => mo.CreatedDate.Value.ToString("dd/MM/yyyy")))
            .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status));

            Mapper.CreateMap<AboutDto, About>()
           .ForMember(des => des.CreatedBy, mos => mos.MapFrom(mo => mo.CreatedBy))
           .ForMember(des => des.CreatedDate, mos => mos.MapFrom(mo => mo.CreatedDate))
           .ForMember(des => des.Description, mos => mos.MapFrom(mo => mo.Description))
           .ForMember(des => des.Detail, mos => mos.MapFrom(mo => mo.Detail))
           .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
           .ForMember(des => des.Image, mos => mos.MapFrom(mo => mo.Image))
           .ForMember(des => des.MetaDescriptions, mos => mos.MapFrom(mo => mo.MetaDescriptions))
           .ForMember(des => des.MetaKeywords, mos => mos.MapFrom(mo => mo.MetaKeywords))
           .ForMember(des => des.MetaTitle, mos => mos.MapFrom(mo => mo.MetaTitle))
           .ForMember(des => des.ModifiedBy, mos => mos.MapFrom(mo => mo.ModifiedBy))
           .ForMember(des => des.ModifiedDate, mos => mos.MapFrom(mo => mo.ModifiedDate))
           .ForMember(des => des.Name, mos => mos.MapFrom(mo => mo.Name))
           .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status));

        }
    }
}