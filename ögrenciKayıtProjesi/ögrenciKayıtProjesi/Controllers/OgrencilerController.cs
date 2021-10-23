using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ögrenciKayıtProjesi.Models.EntityFramework;

namespace ögrenciKayıtProjesi.Controllers
{
    public class OgrencilerController : Controller
    {
        DbOgrenciKayıtEntities1 db = new DbOgrenciKayıtEntities1();

        // GET: Ogrenciler
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult ogrEkle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }
                                          ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult ogrEkle(TBLOGRENCILER p)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            p.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p);
            
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }
                                          ).ToList();
            ViewBag.dgr = degerler;
            
            var ogrenci = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir", ogrenci);
        }
        public ActionResult Guncelle(TBLOGRENCILER p)
        {
            var ogrenci = db.TBLOGRENCILER.Find(p.OGRID);
            ogrenci.OGRAD = p.OGRAD;
            ogrenci.OGRSOYAD = p.OGRSOYAD;
            ogrenci.OGRFOTO = p.OGRFOTO;
            ogrenci.OGRCINSIYET = p.OGRCINSIYET;
            ogrenci.OGRKULUP = p.OGRKULUP;
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            ogrenci.OGRKULUP = klp.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenciler");


        }
       
    }
}