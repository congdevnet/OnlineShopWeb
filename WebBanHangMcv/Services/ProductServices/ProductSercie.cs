using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.ProductServices
{
    public class ProductSercie : GenericService<Product>, IProducSrevices
    {
        public ProductSercie(IRepository repository) : base(repository)
        {
        }
    }
}