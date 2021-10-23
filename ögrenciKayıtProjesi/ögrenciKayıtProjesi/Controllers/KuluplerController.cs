using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ögrenciKayıtProjesi.Models.EntityFramework;
namespace ögrenciKayıtProjesi.Controllers
{
    public class KuluplerController : Controller
    {
        DbOgrenciKayıtEntities1 db = new DbOgrenciKayıtEntities1();
        // GET: Kulupler
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
        [HttpGet]
        public ActionResult KulupEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KulupEkle(TBLKULUPLER p)
        {
            var ekle = db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);

            return View("GuncelleGetir",kulup);
        }
        public ActionResult Guncelle(TBLKULUPLER p)
        {
            var kulup = db.TBLKULUPLER.Find(p.KULUPID);
            kulup.KULUPAD = p.KULUPAD;
            kulup.KULUPKONTENJAN = p.KULUPKONTENJAN;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");

        }
    }
}