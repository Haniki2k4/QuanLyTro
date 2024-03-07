using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTro.Models;
using static System.Data.Entity.Infrastructure.Design.Executor;

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
        public ActionResult DKiThue(TTinNguoiThue model, TTinPhongTro modelPT)
        {
            QLTTPTEntities db = new QLTTPTEntities();
            var updPT = db.TTinPhongTroes.SingleOrDefault(m => m.MaPhong == modelPT.MaPhong);
            if (model.MaHD <= 0)
            {
                ModelState.AddModelError("", "Bạn cần nhập chính xác.");
                return View(model);
            }
            if (updPT == null)
            {
                ModelState.AddModelError("MaPhong", "Mã phòng không tồn tại.");
                return View(model);
            }
            if (ModelState.IsValid == true)
            {
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
        public ActionResult DetailNgThue(int id)
        {
            QLTTPTEntities db = new QLTTPTEntities();
            TTinNguoiThue model = db.TTinNguoiThues.SingleOrDefault(m => m.TT == id);
            return View(model);
        }

        public ActionResult UpdTTNgThue(int id)
        {
            QLTTPTEntities db = new QLTTPTEntities();
            TTinNguoiThue model = db.TTinNguoiThues.SingleOrDefault(m => m.TT == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdTTNgThue(TTinNguoiThue model, TTinPhongTro modelPT)
        {
            QLTTPTEntities db = new QLTTPTEntities();
            var updPT = db.TTinPhongTroes.SingleOrDefault(m => m.MaPhong == modelPT.MaPhong);
            if (model.MaHD <= 0)
            {
                ModelState.AddModelError("", "Bạn cần nhập chính xác.");
                return View(model);
            }
            if (updPT == null)
            {
                ModelState.AddModelError("MaPhong", "Mã phòng không tồn tại.");
                return View(model);
            }
            if (ModelState.IsValid == true)
            {
                var updNgT = db.TTinNguoiThues.Find(model.TT);
                updNgT.NgayVaoO = model.NgayVaoO;
                updNgT.NgayHetHD = model.NgayHetHD;
                updNgT.NgaySinh = model.NgaySinh;
                updNgT.MaPhong = model.MaPhong;
                updNgT.MaHD = model.MaHD;
                updNgT.TienDatCoc = model.TienDatCoc;
                updNgT.GioiTinh = model.GioiTinh;
                updNgT.SoDienThoai = model.SoDienThoai;
                db.SaveChanges();
                return RedirectToAction("DsachNguoiThue");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi nhập dữ liệu.");
                return View(model);
            }
        }

        public ActionResult XoaTTinNgThue(int id)
        {
            QLTTPTEntities db = new QLTTPTEntities();
            var xoaNgT = db.TTinNguoiThues.Find(id);
            db.TTinNguoiThues.Remove(xoaNgT);
            db.SaveChanges();

            return RedirectToAction("DsachNguoiThue");
        }
    }
}