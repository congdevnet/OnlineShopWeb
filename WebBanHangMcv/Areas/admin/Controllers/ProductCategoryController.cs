using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.ProductCategorySrevices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class ProductCategoryController : BaseController
    {
        // GET: admin/ProductProductCategory
        private IProductCategorySrevices _IProductCategorySrevices;

        public ProductCategoryController(IProductCategorySrevices _IProductCategorySrevices)
        {
            this._IProductCategorySrevices = _IProductCategorySrevices;
        }

        // GET: admin/ProductCategory
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _IProductCategorySrevices.All<ProductCategoryDto>().ToList();
            foreach (var item in Data)
            {
                item.Stt = Index + 1;
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
            var data = _IProductCategorySrevices.Find<ProductCategoryDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("dd/MM/yyyy");
            return Json(new JsonData<ProductCategoryDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(ProductCategoryDto ProductCategoryDtos)
        {
            // Phần thêm mới
            try
            {
                if (ProductCategoryDtos.ID < 0)
                {
                    await _IProductCategorySrevices.CreateAsync<ProductCategoryDto>(ProductCategoryDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _IProductCategorySrevices.UpdateAsync<ProductCategoryDto>(ProductCategoryDtos, ProductCategoryDtos.ID);
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
                var DeleData = _IProductCategorySrevices.Delete(id);
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
            var Data = _IProductCategorySrevices.Find<ProductCategoryDto>(id);
            Data.Status = !Data.Status;
            int Res = _IProductCategorySrevices.Update<ProductCategoryDto>(Data, id);
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
            List<ProductCategoryDto> cate = _IProductCategorySrevices.All<ProductCategoryDto>().ToList();
            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "ID", "Name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
        }
    }
}