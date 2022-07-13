using System.Linq;
using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Services.OrderDetailServices
{
    public interface IOrderDetailServices : IGenericService<OrderDetail>
    {
        IQueryable<OrderDetailDto> GetAll();
    }
}