using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.MenuServices
{
    public class MenuService : GenericService<Menu>, IMenuServices
    {
        public MenuService(IRepository repository) : base(repository) { }
    }
}