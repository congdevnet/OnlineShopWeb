using System;

namespace WebQuanLyBanHangDtos
{
    public class OrderDetailDto
    {
        public long ProductID { get; set; }
        public long OrderID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}