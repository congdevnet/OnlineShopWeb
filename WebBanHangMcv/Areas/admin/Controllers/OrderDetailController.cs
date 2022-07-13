using System.Linq;
using System.Web.Mvc;
using WebBanHangMcv.Services.OrderDetailServices;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class OrderDetailController : Controller
    {
        // GET: admin/OrderDetail
        private IOrderDetailServices _IOrderDetailServices;

        public OrderDetailController(IOrderDetailServices _IOrderDetailServices)
        {
            this._IOrderDetailServices = _IOrderDetailServices;
        }

        // GET: admin/OrderDetail
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _IOrderDetailServices.GetAll();
            //foreach (var item in Data)
            //{
            //    item.Stt += Index + 1;
            //}
            return View(Data);
        }

        [HttpGet]
        public ActionResult DanhSach()
        {
            return View();
        }
    }
}