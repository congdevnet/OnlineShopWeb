using System;

namespace WebQuanLyBanHangDtos
{
    public class ContentDto
    {
        public int  Stt { get; set; }

        public long ID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Detail { get; set; }
        public Nullable<int> Warranty { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> TopHot { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string Tags { get; set; }
        public string Language { get; set; }
        public string Ngaytao { get; set; }
    }
}