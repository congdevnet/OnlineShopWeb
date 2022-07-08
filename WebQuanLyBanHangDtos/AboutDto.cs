using System;
using System.Web.Mvc;

namespace WebQuanLyBanHangDtos
{
    public class AboutDto
    {
        public int Stt { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [AllowHtml] public string Detail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string  Ngaytao { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}