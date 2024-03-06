using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTro.Models;

namespace QuanLyTro.Controllers
{
    public class NguoiThueController : Controller
    {
        // GET: NguoiThue
        public ActionResult DsachNguoiThue()
        {
            QLTTPTEntities db = new QLTTPTEntities();
            List<TTinNguoiThue> DsNThue = db.TTinNguoiThues.ToList();
            return View(DsNThue);
        }

        public ActionResult DKiThue()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DKiThue(TTinNguoiThue model)
        {
            if (ModelState.IsValid == true)
            {
                QLTTPTEntities db = new QLTTPTEntities();
                if (db.TTinNguoiThues.Any(m => m.TT == model.TT))
                {
                    ModelState.AddModelError("", "Thông tin đã tồn tại.");
                    return View(model);
                }
                db.TTinNguoiThues.Add(model);
                db.SaveChanges();
                return RedirectToAction("DsachNguoiThue");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi nhập dữ liệu.");
                return View(model);
            }
        }
    }
}