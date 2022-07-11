using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebBanHang_Common;
using WebBanHangMcv.Services.ContactService;
using WebQuanLyBanHangDtos;

namespace WebBanHangMcv.Areas.admin.Controllers
{
    public class ContactController : Controller
    {
        private IContactService _iContactService;

        public ContactController(IContactService _iContactService)
        {
            this._iContactService = _iContactService;
        }

        // GET: admin/Contact
        [HttpGet]
        public ActionResult Index()
        {
            int Index = 0;
            var Data = _iContactService.All<ContactDto>().ToList();
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
            var data = _iContactService.Find<ContactDto>(id);
            return Json(new JsonData<ContactDto>(200, data), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> AddandEdit(ContactDto ContactDtos)
        {
            // Phần thêm mới
            try
            {
                if (ContactDtos.ID < 0)
                {
                    await _iContactService.CreateAsync<ContactDto>(ContactDtos);
                    return Json(new JsonRespon(Mes: "Thêm mới thành công", Status: 200), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    await _iContactService.UpdateAsync<ContactDto>(ContactDtos, ContactDtos.ID);
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
                var DeleData = _iContactService.Delete(id);
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
            var Data = _iContactService.Find<ContactDto>(id);
            Data.Status = !Data.Status;
            int Res = _iContactService.Update<ContactDto>(Data, id);
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