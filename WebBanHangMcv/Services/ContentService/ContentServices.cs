using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.ContentService
{
    public class ContentServices : GenericService<Content>, IContentService
    {
        public ContentServices(IRepository repository) : base(repository)
        {
        }
    }
}