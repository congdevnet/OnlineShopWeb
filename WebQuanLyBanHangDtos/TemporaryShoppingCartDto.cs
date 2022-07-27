namespace WebQuanLyBanHangDtos
{
    public class TemporaryShoppingCartDto
    {
        public int Id { get; set; }
        public int? Pro_id { get; set; }
        public string Pro_Name { get; set; }
        public string Pro_img { get; set; }
        public int? Amount { get; set; }
        public decimal? Price { get; set; }
    }
}