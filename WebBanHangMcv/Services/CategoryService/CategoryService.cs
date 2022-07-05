using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.CategoryService
{
    public class CategoryService : GenericService<Category>, ICategoryServices
    {
        public CategoryService(IRepository repository) : base(repository)
        {
        }
    }
}