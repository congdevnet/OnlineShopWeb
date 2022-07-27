using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.ProductServices;
using WebBanHangMcv.Services.TemporaryShoppingCartServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Controllers
{
    public class CartController : Controller
    {
        private IProducSrevices _IProducSrevices;
        private ITemporaryShoppingCartServices _temporaryShoppingCartServices;
        public CartController(IProducSrevices _IProducSrevices, ITemporaryShoppingCartServices _temporaryShoppingCartServices)
        {
            this._IProducSrevices = _IProducSrevices;
            this._temporaryShoppingCartServices = _temporaryShoppingCartServices;
        }
        // GET: Cart
        public ActionResult Index(int id)
        {
            List<TemporaryShoppingCartDto> temporaryShoppingCarts = new List<TemporaryShoppingCartDto>();

            bool Check = _temporaryShoppingCartServices.All<TemporaryShoppingCartDto>().Any(x => x.Pro_id == id);
            if (!Check)
            {

                TemporaryShoppingCartDto temporaryShoppingCartDto = new TemporaryShoppingCartDto()
                {
                    Amount = 1,
                    Price = _IProducSrevices.All<ProductDto>().Where(x => x.ID == id).FirstOrDefault().Price * 1,
                    Pro_id = id
                };
                _temporaryShoppingCartServices.Create<TemporaryShoppingCartDto>(temporaryShoppingCartDto);
            }
            return View();
        }
        [HttpGet]
        public ActionResult ListTable()
        {
            var Datalist = _temporaryShoppingCartServices.All<TemporaryShoppingCartDto>().ToList();
            foreach (var item in Datalist)
            {

                item.Pro_img = _IProducSrevices.All<ProductDto>().Where(x => x.ID == item.Pro_id).FirstOrDefault().Image;
                item.Pro_Name = _IProducSrevices.All<ProductDto>().Where(x => x.ID == item.Pro_id).FirstOrDefault().Name;
            }
            ViewBag.soluong = Datalist.Count();
            ViewBag.tonggia = Datalist.Select(x => x.Price).Sum();
            return View(Datalist);
        }
        [HttpPost]
        public JsonResult Changgia(int id, int Soluong)
        {
            var Datalist = _temporaryShoppingCartServices.All<TemporaryShoppingCartDto>().Where(x => x.Id == id).FirstOrDefault();
            ProductDto productDto = _IProducSrevices.All<ProductDto>().Where(x => x.ID == Datalist.Pro_id).FirstOrDefault();

            Datalist.Amount = Soluong;
            Datalist.Price = Soluong * productDto.Price;

            _temporaryShoppingCartServices.Update<TemporaryShoppingCartDto>(Datalist, id);
            return Json(new JsonRespon(Mes: "Chỉnh sửa thành công", Status: 200), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            _temporaryShoppingCartServices.Delete(id);
            return Json(new JsonRespon(Mes: "Chỉnh sửa thành công", Status: 200), JsonRequestBehavior.AllowGet);
        }
    }
}