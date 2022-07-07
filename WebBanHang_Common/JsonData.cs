namespace WebBanHang_Common
{
    public class JsonData<T>
    {
        public int Status { get; set; }
        public T Data { get; set; }
        public JsonData(int Status, T Data)
        {
            this.Status = Status;
            this.Data = Data;
        }
    }
}