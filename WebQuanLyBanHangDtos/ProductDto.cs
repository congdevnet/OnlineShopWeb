﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHangDtos
{
    public class ProductDto
    {
        public int Stt { get; set; }
        public long ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string MoreImages { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
        public Nullable<bool> IncludedVAT { get; set; }
        public int Quantity { get; set; }
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
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> TopHot { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string Ngaytao { get; set; }
        public string NgaySale { get; set; }
    }
}
