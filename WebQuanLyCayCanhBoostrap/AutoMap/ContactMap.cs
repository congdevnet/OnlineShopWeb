using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class ContactMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Contact, ContactDto>()
            .ForMember(des => des.Content, mo => mo.MapFrom(mos => mos.Content))
            .ForMember(des => des.ID, mo => mo.MapFrom(mos => mos.ID))
            .ForMember(des => des.Status, mo => mo.MapFrom(mos => mos.Status));

            AutoMapper.Mapper.CreateMap<ContactDto, Contact>()
           .ForMember(des => des.Content, mo => mo.MapFrom(mos => mos.Content))
           .ForMember(des => des.ID, mo => mo.MapFrom(mos => mos.ID))
           .ForMember(des => des.Status, mo => mo.MapFrom(mos => mos.Status));
        }
    }
}