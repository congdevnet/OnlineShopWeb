using System;

namespace WebQuanLyBanHangDtos
{
    public class SlideDto
    {
        public int? Stt { get; set; }
        public int ID { get; set; }
        public string Image { get; set; }
        public int? DisplayOrder { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }
        public string Ngaytao { get; set; }
    }
}