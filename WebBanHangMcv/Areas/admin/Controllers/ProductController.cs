using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.ProductCategorySrevices;
using WebBanHangMcv.Services.ProductServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: admin/Product
        private IProducSrevices _IProducSrevices;
        private IProductCategorySrevices _IProductCategorySrevices;

        public ProductController(IProducSrevices _IProducSrevices, IProductCategorySrevices _IProductCategorySrevices)
        {
            this._IProducSrevices = _IProducSrevices;
            this._IProductCategorySrevices = _IProductCategorySrevices;
        }

        // GET: admin/Product
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _IProducSrevices.All<ProductDto>().ToList();
            foreach (var item in Data)
            {
                item.Stt += Index + 1;
                item.CategoryName = _IProductCategorySrevices.Find<ProductCategoryDto>(item.CategoryID).Name;
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
            var data = _IProducSrevices.Find<ProductDto>(id);
            data.Ngaytao = data.CreatedDate.Value.ToString("MM/dd/yyyy");
            data.NgaySale = data.TopHot.Value.ToString("MM/dd/yyyy");
            return Json(new JsonData<ProductDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(ProductDto ProductDtos)
        {
            // Phần thêm mới
            try
            {
                if (ProductDtos.ID < 0)
                {
                    ProductDtos.Code = CodeRes.CodeAuto();
                    await _IProducSrevices.CreateAsync<ProductDto>(ProductDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _IProducSrevices.UpdateAsync<ProductDto>(ProductDtos, ProductDtos.ID);
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
                var DeleData = _IProducSrevices.Delete(id);
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
            var Data = _IProducSrevices.Find<ProductDto>(id);
            Data.Status = !Data.Status;
            int Res = _IProducSrevices.Update<ProductDto>(Data, id);
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