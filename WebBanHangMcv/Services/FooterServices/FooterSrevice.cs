using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.FooterServices
{
    public class FooterSrevice : GenericService<Footer>, IFooterSrevices
    {
        public FooterSrevice(IRepository repository) : base(repository) { }
    }
}