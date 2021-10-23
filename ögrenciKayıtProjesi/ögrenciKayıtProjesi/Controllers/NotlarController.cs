using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ögrenciKayıtProjesi.Models;
using ögrenciKayıtProjesi.Models.EntityFramework;


namespace ögrenciKayıtProjesi.Controllers
{
    public class NotlarController : Controller
    {
        DbOgrenciKayıtEntities1 db = new DbOgrenciKayıtEntities1();
        // GET: Notlar
        public ActionResult Index()
        {
            var not = db.TBLNOTLAR.ToList();

            return View(not);
        }
        [HttpGet]
        public ActionResult NotEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NotEkle(TBLNOTLAR p)
        {
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NotGetir(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            return View("NotGetir", not); 
        }
        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNOTLAR p, int SINAV1=0, int SINAV2=0,int SINAV3=0, int PROJE=0 )
        {
            if(model.islem=="HESAPLA")
            {
                int ort = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ortalama = ort;
            }
            if(model.islem=="NOTGUNCELLE")
            {
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                snv.DURUM = p.DURUM;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
       
        
      


    }
}