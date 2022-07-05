using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.AboutService
{
    public class AboutServices: GenericService<About>, IAboutService
    {
        public AboutServices(IRepository repository): base(repository) { }
    }
}