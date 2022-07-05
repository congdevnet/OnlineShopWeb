using System;

namespace WebQuanLyBanHangDtos
{
    public class OrderDto
    {
        public long ID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> CustomerID { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public Nullable<int> Status { get; set; }
    }
}