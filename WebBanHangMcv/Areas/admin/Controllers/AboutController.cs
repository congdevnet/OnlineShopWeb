using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.AboutService;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class AboutController : BaseController
    {
        private IAboutService _iaboutService;

        public AboutController(IAboutService _iaboutService)
        {
            this._iaboutService = _iaboutService;
        }

        // GET: admin/About
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _iaboutService.All<AboutDto>().ToList();
            foreach (var item in Data)
            {
                item.Stt += Index+1;
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
            var data = _iaboutService.Find<AboutDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("dd/MM/yyyy");
            return Json(new JsonData<AboutDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(AboutDto AboutDtos)
        {
            // Phần thêm mới
            try
            {
                if (AboutDtos.ID < 0)
                {
                    await _iaboutService.CreateAsync<AboutDto>(AboutDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _iaboutService.UpdateAsync<AboutDto>(AboutDtos, AboutDtos.ID);
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
                var DeleData = _iaboutService.Delete(id);
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
            var Data = _iaboutService.Find<AboutDto>(id);
            Data.Status = !Data.Status;
            int Res = _iaboutService.Update<AboutDto>(Data, id);
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