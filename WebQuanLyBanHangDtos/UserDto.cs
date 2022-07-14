﻿using System;

namespace WebQuanLyBanHangDtos
{
    public class UserDto
    {
        public int Stt { get; set; }
        public long ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GroupID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> ProvinceID { get; set; }
        public Nullable<int> DistrictID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Status { get; set; }
        public string Ngaytao { get; set; }
    }
}