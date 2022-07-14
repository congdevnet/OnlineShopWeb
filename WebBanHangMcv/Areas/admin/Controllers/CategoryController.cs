using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.CategoryService;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: admin/Category
        private ICategoryServices _ICategoryServices;

        public CategoryController(ICategoryServices _ICategoryServices)
        {
            this._ICategoryServices = _ICategoryServices;
        }

        // GET: admin/Category
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _ICategoryServices.All<CategoryDto>().ToList();
            foreach (var item in Data)
            {
                item.Stt += Index + 1;
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
            var data = _ICategoryServices.Find<CategoryDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("dd/MM/yyyy");
            return Json(new JsonData<CategoryDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(CategoryDto CategoryDtos)
        {
            // Phần thêm mới
            try
            {
                if (CategoryDtos.ID < 0)
                {
                    await _ICategoryServices.CreateAsync<CategoryDto>(CategoryDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _ICategoryServices.UpdateAsync<CategoryDto>(CategoryDtos, CategoryDtos.ID);
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
                var DeleData = _ICategoryServices.Delete(id);
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
            var Data = _ICategoryServices.Find<CategoryDto>(id);
            Data.Status = !Data.Status;
            int Res = _ICategoryServices.Update<CategoryDto>(Data, id);
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