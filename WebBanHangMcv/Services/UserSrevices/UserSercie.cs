using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.UserSrevices
{
    public class UserSercie : GenericService<User>, IUserSercies
    {
        public UserSercie(IRepository repository) : base(repository)
        {
        }
    }
}