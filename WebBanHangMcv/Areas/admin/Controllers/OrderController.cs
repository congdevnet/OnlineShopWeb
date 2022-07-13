using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.OrderSrevices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: admin/Order
        private IOrderSrevices _IOrderServices;

        public OrderController(IOrderSrevices _IOrderServices)
        {
            this._IOrderServices = _IOrderServices;
        }

        // GET: admin/Order
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _IOrderServices.All<OrderDto>().ToList();
            foreach (var item in Data)
            {
                item.Stt += Index + 1;
            }

            return View(Data);
        }

        [HttpGet]
        public ActionResult DanhSach()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetObjById(int id)
        {
            var data = _IOrderServices.Find<OrderDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("MM/dd/yyyy");
            return Json(new JsonData<OrderDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(OrderDto OrderDtos)
        {
            // Phần thêm mới
            try
            {
                if (OrderDtos.ID < 0)
                {
                    await _IOrderServices.CreateAsync<OrderDto>(OrderDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _IOrderServices.UpdateAsync<OrderDto>(OrderDtos, OrderDtos.ID);
                    return Json(new JsonRespon(Mes: "Chỉnh sửa thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new JsonRespon(Mes: ex.Message, Status: 500), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                var DeleData = _IOrderServices.Delete(id);
                return Json(new JsonRespon(Mes: "Xóa thành công", Status: 200), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new JsonRespon(Mes: ex.Message, Status: 500), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ChangCheck(int id)
        {
            var Data = _IOrderServices.Find<OrderDto>(id);
            Data.Status = (int)Data.Status > 0 ? 1 : 0;
            int Res = _IOrderServices.Update<OrderDto>(Data, id);
            if (Res > 0)
            {
                return Json(new JsonRespon(Mes: "Cập nhật thành công", Status: 200), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JsonRespon(Mes: "Đã có lỗi sảy ra!", Status: 500), JsonRequestBehavior.AllowGet);
            }
        }
    }
}