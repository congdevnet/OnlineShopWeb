using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.MenuTypeServices
{
    public class MenuTypeServices : GenericService<MenuType>, IMenuTypeServices
    {
        public MenuTypeServices(IRepository repository) : base(repository)
        {
        }
    }
}