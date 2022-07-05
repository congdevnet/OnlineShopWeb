using System;

namespace WebQuanLyBanHangDtos
{
    public class MenuDto
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string Target { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> TypeID { get; set; }
    }
}