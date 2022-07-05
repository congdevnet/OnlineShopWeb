using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebQuanLyCayCanhBoostrap.AutoMap
{
    public class FeedbackMap
    {
        public static void MapConfig()
        {
            AutoMapper.Mapper.CreateMap<Feedback, FeedbackDto>();
            AutoMapper.Mapper.CreateMap<FeedbackDto, Feedback>();
        }
    }
}