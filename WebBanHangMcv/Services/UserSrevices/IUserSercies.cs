using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Services.UserSrevices
{
    public interface IUserSercies : IGenericService<User>
    {
        UserDto Login(UserLogin userLogin);
    }
}