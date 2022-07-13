using System;

namespace WebQuanLyBanHangDtos
{
    public class OrderDetailDto
    {
        public int Stt { get; set; }
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
        public Nullable<bool> IncludedVAT { get; set; }
        public long OrderID { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Pricesum { get; set; }
        public DateTime? NgayMua { get; set; }
    }
}