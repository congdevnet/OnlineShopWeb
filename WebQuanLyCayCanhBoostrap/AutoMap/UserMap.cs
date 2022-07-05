using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class UserMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<User, UserDto>();
            AutoMapper.Mapper.CreateMap<UserDto, User>();

            AutoMapper.Mapper.CreateMap<User, UserLogin>()
            .ForMember(des => des.Name, mo => mo.MapFrom(mos => mos.Name))
            .ForMember(des => des.Password, mo => mo.MapFrom(mos => mos.Password))
            .ForMember(des => des.UserName, mo => mo.MapFrom(mos => mos.UserName));
        }
    }
}