using System.Linq;
using WebBanHang_Common;
using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Services.UserSrevices
{
    public class UserSercie : GenericService<User>, IUserSercies
    {
        public UserSercie(IRepository repository) : base(repository)
        {
        }

        public UserDto Login(UserLogin userLogin)
        {
            OnlineShopEntities onlineShopEntities = new OnlineShopEntities();
            var Data = onlineShopEntities.Set<User>().Where(x => x.UserName == userLogin.UserName).FirstOrDefault();
            if (Data != null)
            {
                if (Data.Password == MD5Pasword.GetMD5(userLogin.Password))
                {
                    UserDto userDto = new UserDto()
                    {
                        Name = Data.Name,
                        UserName = Data.UserName
                    };
                    return userDto;
                }
                return new UserDto();
            }
            else
            {
                return new UserDto();
            }
        }
    }
}