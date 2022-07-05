using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class LanguageMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Language, LanguageDto>();
            AutoMapper.Mapper.CreateMap<LanguageDto, Language>();
        }
    }
}