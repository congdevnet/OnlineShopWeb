using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.FeedbackServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class FeedbackController : BaseController
    {
        private IFeedbackServices _iFeedbackService;

        public FeedbackController(IFeedbackServices _iFeedbackService)
        {
            this._iFeedbackService = _iFeedbackService;
        }

        // GET: admin/Feedback
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _iFeedbackService.All<FeedbackDto>().ToList();
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
            var data = _iFeedbackService.Find<FeedbackDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("dd/MM/yyyy");
            return Json(new JsonData<FeedbackDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(FeedbackDto FeedbackDtos)
        {
            // Phần thêm mới
            try
            {
                if (FeedbackDtos.ID < 0)
                {
                    await _iFeedbackService.CreateAsync<FeedbackDto>(FeedbackDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _iFeedbackService.UpdateAsync<FeedbackDto>(FeedbackDtos, FeedbackDtos.ID);
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
                var DeleData = _iFeedbackService.Delete(id);
                return Json(new JsonRespon(Mes: "Xóa thành công", Status: 200), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new JsonRespon(Mes: ex.Message, Status: 500), JsonRequestBehavior.AllowGet);
            }
        }
    }
}