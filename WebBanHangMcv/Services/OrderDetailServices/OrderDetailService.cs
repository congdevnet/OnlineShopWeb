using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.OrderDetailServices
{
    public class OrderDetailService : GenericService<OrderDetail>, IOrderDetailServices
    {
        public OrderDetailService(IRepository repository) : base(repository) { }
    }
}