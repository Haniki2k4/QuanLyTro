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
            return View();
        }

        public ActionResult DKiThue()
        {
            return View();
        }
    }
}