using System;

namespace WebQuanLyBanHangDtos
{
    public class ContactDto
    {
        public int Stt { get; set; }
        public int ID { get; set; }
        public string Content { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}