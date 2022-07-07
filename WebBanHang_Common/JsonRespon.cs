namespace WebBanHang_Common
{
    public class JsonRespon
    {
        public string Mes { get; set; }
        public int Status { get; set; }

        public JsonRespon(string Mes, int Status)
        {
            this.Mes = Mes;
            this.Status = Status;
        }
    }
}