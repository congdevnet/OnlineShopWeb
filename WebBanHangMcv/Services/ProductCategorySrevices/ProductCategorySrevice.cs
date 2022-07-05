using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.ProductCategorySrevices
{
    public class ProductCategorySrevice : GenericService<ProductCategory>, IProductCategorySrevices
    {
        public ProductCategorySrevice(IRepository repository) : base(repository) { }
    }
}