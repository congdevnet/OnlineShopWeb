using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class MenuMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Menu, MenuDto>()
            .ForMember(des => des.DisplayOrder, mos => mos.MapFrom(mo => mo.DisplayOrder))
            .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
            .ForMember(des => des.Link, mos => mos.MapFrom(mo => mo.Link))
            .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status))
            .ForMember(des => des.Target, mos => mos.MapFrom(mo => mo.Target))
            .ForMember(des => des.Text, mos => mos.MapFrom(mo => mo.Text))
            .ForMember(des => des.TypeID, mos => mos.MapFrom(mo => mo.TypeID));

            AutoMapper.Mapper.CreateMap<MenuDto, Menu>()
            .ForMember(des => des.DisplayOrder, mos => mos.MapFrom(mo => mo.DisplayOrder))
            .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
            .ForMember(des => des.Link, mos => mos.MapFrom(mo => mo.Link))
            .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status))
            .ForMember(des => des.Target, mos => mos.MapFrom(mo => mo.Target))
            .ForMember(des => des.Text, mos => mos.MapFrom(mo => mo.Text))
            .ForMember(des => des.TypeID, mos => mos.MapFrom(mo => mo.TypeID));

            AutoMapper.Mapper.CreateMap<Menu, Menuview>()
            .ForMember(des => des.DisplayOrder, mos => mos.MapFrom(mo => mo.DisplayOrder))
            .ForMember(des => des.ID, mos => mos.MapFrom(mo => mo.ID))
            .ForMember(des => des.Link, mos => mos.MapFrom(mo => mo.Link))
            .ForMember(des => des.Status, mos => mos.MapFrom(mo => mo.Status))
            .ForMember(des => des.Target, mos => mos.MapFrom(mo => mo.Target))
            .ForMember(des => des.Text, mos => mos.MapFrom(mo => mo.Text))
            .ForMember(des => des.TypeID, mos => mos.MapFrom(mo => mo.TypeID));
        }
    }
}