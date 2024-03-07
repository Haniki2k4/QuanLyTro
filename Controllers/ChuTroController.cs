using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTro.Models;

namespace QuanLyTro.Controllers
{
    public class ChuTroController : Controller
    {
        public ActionResult DsachChuTro()
        {
            QLTTPTEntities db = new QLTTPTEntities();
            List<TTinChuTro> DsCTro = db.TTinChuTroes.ToList();
            return View(DsCTro);
        }
        

        public ActionResult ThemChuTro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemChuTro(TTinChuTro model)
        {
            if (model.SoLuongPhong <= 0)
            {
                ModelState.AddModelError("", "Bạn cần nhập số lương phòng chính xác.");
                return View(model);
            }
            if (ModelState.IsValid == true)
            {
                QLTTPTEntities db = new QLTTPTEntities(); 
                if (db.TTinChuTroes.Any(m => m.TT == model.TT))
                {
                    ModelState.AddModelError("", "Thông tin đã tồn tại.");
                    return View(model);
                }
                db.TTinChuTroes.Add(model);
                db.SaveChanges();
                return RedirectToAction("DsachChuTro");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi nhập dữ liệu.");
                return View(model);
            }
        }
        public ActionResult UpdTTCTro(string id)
        {
            QLTTPTEntities db = new QLTTPTEntities();
            TTinChuTro model = db.TTinChuTroes.SingleOrDefault(m => m.HoTenChuTro == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdTTCTro(TTinChuTro model)
        {
            if (model.SoLuongPhong <= 0)
            {
                ModelState.AddModelError("", "Bạn cần nhập số lương phòng chính xác.");
                return View(model);
            }
            if (ModelState.IsValid == true)
            {
                QLTTPTEntities db = new QLTTPTEntities();
                var updCT = db.TTinChuTroes.Find(model.HoTenChuTro);
                updCT.NgaySinh = model.NgaySinh;
                updCT.SoLuongPhong = model.SoLuongPhong;
                updCT.NoiDKHoKhau = model.NoiDKHoKhau;
                updCT.SoDienThoai = model.SoDienThoai;
                db.SaveChanges();
                return RedirectToAction("DsachChuTro");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi nhập dữ liệu.");
                return View(model);
            }
        }

        public ActionResult XoaTTinCTro(string id)
        {
            QLTTPTEntities db = new QLTTPTEntities();
            var xoaTT = db.TTinChuTroes.Find(id);
            db.TTinChuTroes.Remove(xoaTT);
            db.SaveChanges();

            return RedirectToAction("DsachChuTro");
        }
    }
}