using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.FooterServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class FooterController : Controller
    {
        private IFooterSrevices _iFooterService;

        public FooterController(IFooterSrevices _iFooterService)
        {
            this._iFooterService = _iFooterService;
        }

        // GET: admin/Footer
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _iFooterService.All<FooterDto>().ToList();
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
            var data = _iFooterService.Find<FooterDto>(id);
            return Json(new JsonData<FooterDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(FooterDto FooterDtos)
        {
            // Phần thêm mới
            try
            {
                if (int.Parse(FooterDtos.ID) < 0)
                {
                    await _iFooterService.CreateAsync<FooterDto>(FooterDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _iFooterService.UpdateAsync<FooterDto>(FooterDtos, FooterDtos.ID);
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
                var DeleData = _iFooterService.Delete(id);
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
            var Data = _iFooterService.Find<FooterDto>(id);
            Data.Status = !Data.Status;
            int Res = _iFooterService.Update<FooterDto>(Data, id);
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