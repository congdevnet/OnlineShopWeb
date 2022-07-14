using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.SlideServices
{
    public class SlideService : GenericService<Slide>, ISlideServices
    {
        public SlideService(IRepository repository) : base(repository)
        {
        }
    }
}