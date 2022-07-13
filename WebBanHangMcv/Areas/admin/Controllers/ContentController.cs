using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.CategoryService;
using WebBanHangMcv.Services.ContentService;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class ContentController : Controller
    {
        // GET: admin/Content
        private IContentService _IContentServiceS;
        private ICategoryServices _ICategoryServices;

        public ContentController(IContentService _IContentServiceS, ICategoryServices _ICategoryServices)
        {
            this._IContentServiceS = _IContentServiceS;
            this._ICategoryServices = _ICategoryServices;
        }

        // GET: admin/Content
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _IContentServiceS.All<ContentDto>().ToList();
            foreach (var item in Data)
            {
                item.Stt += Index + 1;
                item.CategoryName = _ICategoryServices.Find<CategoryDto>(item.CategoryID).Name;
            }

            return View(Data);
        }

        [HttpGet]
        public ActionResult DanhSach()
        {
            SetViewBang();
            return View();
        }

        [HttpPost]
        public JsonResult GetObjById(int id)
        {
            var data = _IContentServiceS.Find<ContentDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("MM/dd/yyyy");
            data.Ngayhot = data.TopHot.Value.ToString("MM/dd/yyyy");
            return Json(new JsonData<ContentDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(ContentDto ContentDtos)
        {
            // Phần thêm mới
            try
            {
                if (ContentDtos.ID < 0)
                {
                    await _IContentServiceS.CreateAsync<ContentDto>(ContentDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _IContentServiceS.UpdateAsync<ContentDto>(ContentDtos, ContentDtos.ID);
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
                var DeleData = _IContentServiceS.Delete(id);
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
            var Data = _IContentServiceS.Find<ContentDto>(id);
            Data.Status = !Data.Status;
            int Res = _IContentServiceS.Update<ContentDto>(Data, id);
            if (Res > 0)
            {
                return Json(new JsonRespon(Mes: "Cập nhật thành công", Status: 200), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new JsonRespon(Mes: "Đã có lỗi sảy ra!", Status: 500), JsonRequestBehavior.AllowGet);
            }
        }

        private void SetViewBang()
        {
            // Lấy data
            // Lấy toàn bộ thể loại:
            List<CategoryDto> cate = _ICategoryServices.All<CategoryDto>().ToList();
            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "ID", "Name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
        }
    }
}