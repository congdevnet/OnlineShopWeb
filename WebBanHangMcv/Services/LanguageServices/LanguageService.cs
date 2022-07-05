using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.LanguageServices
{
    public class LanguageService : GenericService<Language>, ILanguageServices
    {
        public LanguageService(IRepository repository) : base(repository)
        {
        }
    }
}