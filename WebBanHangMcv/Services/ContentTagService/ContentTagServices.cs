using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.ContentTagService
{
    public class ContentTagServices : GenericService<ContentTag>, IContentTagServices
    {
        public ContentTagServices(IRepository repository) : base(repository)
        {
        }
    }
}