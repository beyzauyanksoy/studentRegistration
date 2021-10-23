using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ögrenciKayıtProjesi.Models.EntityFramework;

namespace ögrenciKayıtProjesi.Controllers
{
    public class DefaultController : Controller
    {
        DbOgrenciKayıtEntities1 db = new DbOgrenciKayıtEntities1();
     
        // GET: Default
        public ActionResult Index()
        {
            var ders = db.TBLDERSLER.ToList();
            return View(ders);
        }
        [HttpGet]
        public ActionResult DersEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(TBLDERSLER p)
        {
            var ekle = db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult DersGetir(int id )
        {
            var ders = db.TBLDERSLER.Find(id);
            return View("DersGetir",ders);
        }
        public ActionResult Guncelle(TBLDERSLER p)
        {
            var dersler = db.TBLDERSLER.Find(p.DERSID);
            dersler.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }

    }
}