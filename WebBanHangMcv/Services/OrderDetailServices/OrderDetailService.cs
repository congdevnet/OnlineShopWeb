using System;
using System.Linq;
using WebBanHangMcv.Models;
using WebQuanLayBanHangEntityFramework;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Services.OrderDetailServices
{
    public class OrderDetailService : GenericService<OrderDetail>, IOrderDetailServices
    {
        public OrderDetailService(IRepository repository) : base(repository) { }

        public IQueryable<OrderDetailDto> GetAll()
        {
            OnlineShopEntities onlineShopEntities = new OnlineShopEntities();

            var Data = from Ordde in onlineShopEntities.Set<OrderDetail>()
                       join Ord in onlineShopEntities.Set<Order>()
                       on Ordde.OrderID equals Ord.ID
                       join Pro in onlineShopEntities.Set<Product>()
                       on Ordde.ProductID equals Pro.ID
                       select new OrderDetailDto()
                       {
                           Image = Pro.Image,
                           IncludedVAT = Pro.IncludedVAT,
                           OrderID = Ord.ID,
                           Price = Pro.Price,
                           ProductID = Pro.ID,
                           Pricesum = Ordde.Price,
                           ProductName = Pro.Name,
                           PromotionPrice = Pro.PromotionPrice,
                           Quantity = Ordde.Quantity,
                           ShipAddress = Ord.ShipAddress,
                           ShipEmail = Ord.ShipEmail,
                           ShipMobile = Ord.ShipMobile,
                           ShipName = Ord.ShipName,
                           NgayMua = Ord.CreatedDate
                       };
            return Data;

        }
    }
}