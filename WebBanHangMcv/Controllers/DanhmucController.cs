using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.ProductCategorySrevices;
using WebBanHangMcv.Services.ProductServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Controllers
{
    public class DanhmucController : Controller
    {
        private IProducSrevices _IProducSrevices;
        private IProductCategorySrevices _IProductCategorySrevices;
        public DanhmucController(IProducSrevices _IProducSrevices, IProductCategorySrevices _IProductCategorySrevices)
        {
            this._IProducSrevices = _IProducSrevices;
            this._IProductCategorySrevices = _IProductCategorySrevices;
        }
        // GET: Danhmuc
        public ActionResult GetDanhmuc(int id, int pageIndex = 1)
        {
            ViewBag.ProductCategory = _IProductCategorySrevices.All<ProductCategoryDto>().Where(x => x.ID == id).FirstOrDefault().Name;
            int pageSize = SetupPage.PageSize;
            ViewBag.Metatile = _IProductCategorySrevices.All<ProductCategoryDto>().Where(x => x.ID == id).FirstOrDefault().MetaTitle;
            var Data = _IProducSrevices.All<ProductDto>().Where(x => x.CategoryID == id).OrderByDescending(x=>x.ID).AsQueryable();
            ViewBag.TotalRow = Data.Count();
            int toatalpage = (int)Math.Ceiling((double)(Data.Count() / pageSize));
            Data = Data.Skip((pageSize * (pageIndex - 1))).Take(pageSize);
            ViewBag.pageIndex = pageIndex;
            ViewBag.pageSize = pageSize;
            int maxpage = 5;
            ViewBag.Maxpage = maxpage;
            ViewBag.Totalpage = toatalpage;
            ViewBag.Fist = 1;
            ViewBag.Last = toatalpage;
            ViewBag.Next = pageIndex + 1;
            ViewBag.Prev = pageIndex - 1;
            ViewBag.Id = id;
            return View(Data);
        }
    }
}