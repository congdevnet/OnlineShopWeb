using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.TemporaryShoppingCartServices
{
    public class TemporaryShoppingCartServices : GenericService<TemporaryShoppingCart>, ITemporaryShoppingCartServices
    {
        public TemporaryShoppingCartServices(IRepository repository) : base(repository)
        {
        }
    }
}