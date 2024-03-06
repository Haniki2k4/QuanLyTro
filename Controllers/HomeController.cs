using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTro.Models;

namespace QuanLyTro.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            QLTTPTEntities db = new QLTTPTEntities();
            List<TTinPhongTro> DsPTro = db.TTinPhongTroes.ToList();
            return View(DsPTro);
        }

        public ActionResult ThemPhongTro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemPhongTro(TTinPhongTro model)
        {
            if (model.GiaThue <= 0)
            {
                ModelState.AddModelError("", "Bạn cần nhập giá thuê lớn hơn 0.");
                return View(model);
            }
            if (ModelState.IsValid == true)
            {
                QLTTPTEntities db = new QLTTPTEntities();
                if (db.TTinPhongTroes.Any(m => m.MaPhong == model.MaPhong))
                {
                    ModelState.AddModelError("", "Mã phòng đã tồn tại.");
                    return View(model);
                }
                db.TTinPhongTroes.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi nhập dữ liệu.");
                return View(model);
            }
        }
    }
}