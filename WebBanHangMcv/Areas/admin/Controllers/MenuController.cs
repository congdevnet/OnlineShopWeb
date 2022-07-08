using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.MenuServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class MenuController : Controller
    {
        // GET: admin/Menu
        private IMenuServices _IMenuSrevices;

        public MenuController(IMenuServices _IMenuSrevices)
        {
            this._IMenuSrevices = _IMenuSrevices;
        }

        // GET: admin/Menu
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _IMenuSrevices.All<MenuDto>().ToList();
            foreach (var item in Data)
            {
                item.Stt = Index + 1;
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
            var data = _IMenuSrevices.Find<MenuDto>(id);
            return Json(new JsonData<MenuDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(MenuDto MenuDtos)
        {
            // Phần thêm mới
            try
            {
                if (MenuDtos.ID < 0)
                {
                    await _IMenuSrevices.CreateAsync<MenuDto>(MenuDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _IMenuSrevices.UpdateAsync<MenuDto>(MenuDtos, MenuDtos.ID);
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
                var DeleData = _IMenuSrevices.Delete(id);
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
            var Data = _IMenuSrevices.Find<MenuDto>(id);
            Data.Status = !Data.Status;
            int Res = _IMenuSrevices.Update<MenuDto>(Data, id);
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