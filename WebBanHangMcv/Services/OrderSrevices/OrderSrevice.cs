using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;

namespace WebBanHangMcv.Services.OrderSrevices
{
    public class OrderSrevice : GenericService<Order>, IOrderSrevices
    {
        public OrderSrevice(IRepository repository) : base(repository) { }
    }
}