using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.SlideServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class SlideController : BaseController
    {
        private ISlideServices _iSlideService;

        public SlideController(ISlideServices _iSlideService)
        {
            this._iSlideService = _iSlideService;
        }

        // GET: admin/Slide
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _iSlideService.All<SlideDto>().ToList();
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
            var data = _iSlideService.Find<SlideDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("dd/MM/yyyy");
            return Json(new JsonData<SlideDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(SlideDto SlideDtos)
        {
            // Phần thêm mới
            try
            {
                if (SlideDtos.ID < 0)
                {
                    await _iSlideService.CreateAsync<SlideDto>(SlideDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _iSlideService.UpdateAsync<SlideDto>(SlideDtos, SlideDtos.ID);
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
                var DeleData = _iSlideService.Delete(id);
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
            var Data = _iSlideService.Find<SlideDto>(id);
            Data.Status = !Data.Status;
            int Res = _iSlideService.Update<SlideDto>(Data, id);
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