using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.MenuTypeServices;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class MenuTypeController : BaseController
    {
        // GET: admin/MenuTypeType
        private IMenuTypeServices _IMenuTypeSrevices;

        public MenuTypeController(IMenuTypeServices _IMenuTypeSrevices)
        {
            this._IMenuTypeSrevices = _IMenuTypeSrevices;
        }

        // GET: admin/MenuType
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _IMenuTypeSrevices.All<MenuTypeDto>().ToList();
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
            var data = _IMenuTypeSrevices.Find<MenuTypeDto>(id);
            return Json(new JsonData<MenuTypeDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(MenuTypeDto MenuTypeDtos)
        {
            // Phần thêm mới
            try
            {
                if (MenuTypeDtos.ID < 0)
                {
                    await _IMenuTypeSrevices.CreateAsync<MenuTypeDto>(MenuTypeDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _IMenuTypeSrevices.UpdateAsync<MenuTypeDto>(MenuTypeDtos, MenuTypeDtos.ID);
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
                var DeleData = _IMenuTypeSrevices.Delete(id);
                return Json(new JsonRespon(Mes: "Xóa thành công", Status: 200), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new JsonRespon(Mes: ex.Message, Status: 500), JsonRequestBehavior.AllowGet);
            }
        }
    }
}