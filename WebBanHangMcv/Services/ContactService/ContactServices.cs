using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.ContactService
{
    public class ContactServices : GenericService<Contact>, IContactService
    {
        public ContactServices(IRepository repository) : base(repository)
        {
        }
    }
}