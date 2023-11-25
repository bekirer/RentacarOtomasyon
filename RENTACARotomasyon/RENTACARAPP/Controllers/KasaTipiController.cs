using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData.ModelProviders;
using System.Web.Mvc;
using RENTACARAPP.Models.Entity;

namespace RENTACARAPP.Controllers
{
    public class KasaTipiController : Controller
    {
        // GET: KasaTipi
        DBRENTALEntities6 db = new DBRENTALEntities6();
        public ActionResult Index()
        {
            var değerler = db.TKASATIPI.ToList();
            return View(değerler);
        }

        [HttpGet]
        public ActionResult KasatipiEkle()
        { return View();            
        }
       
        [HttpPost]
        public ActionResult KasatipiEkle(TKASATIPI p)
        {
            db.TKASATIPI.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
           
        }

        public ActionResult KasaTipiSil(int id)
        {
            var kategori=db.TKASATIPI.Find(id);
            db.TKASATIPI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KasaTipiGetir(int id)
        {
            var ktgr = db.TKASATIPI.Find(id);
          
            return View("KasaTipiGetir",ktgr);
           
        }
        public ActionResult KasaTipiGuncelle(TKASATIPI p)
        {
            var ktg = db.TKASATIPI.Find(p.ID);
            ktg.KASATIPI = p.KASATIPI;
            db.SaveChanges();   
           return RedirectToAction("Index");

        }

    }
}