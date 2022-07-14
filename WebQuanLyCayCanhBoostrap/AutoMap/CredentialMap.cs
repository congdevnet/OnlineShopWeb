using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class CredentialMap
    {
        public static void Mapconfig()
        {
            AutoMapper.Mapper.CreateMap<Credential, CredentialDto>();
            AutoMapper.Mapper.CreateMap<CredentialDto, Credential>();
        }
    }
}