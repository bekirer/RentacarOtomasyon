using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RENTACARAPP.Models.Entity;


namespace RENTACARAPP.Controllers
{
    public class ArabaController : Controller
    {
        // GET: Araba
        DBRENTALEntities6 db = new DBRENTALEntities6();
        public ActionResult Index(string p)
        {
            var cars = from c in db.TARABA select c;
            if(!string.IsNullOrEmpty(p))
            {
                cars = cars.Where(x => x.MODEL.Contains(p));

            }
          //  var cars = db.TARABA.ToList();
            return View(cars.ToList());
        }


        [HttpGet]
        public ActionResult ArabaEkle()
        {
            List<SelectListItem> value1 = (from i in db.TKASATIPI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KASATIPI,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.v1 = value1;

            List<SelectListItem> value2 = (from i in db.TMARKA.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MARKA,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.v2 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult ArabaEkle(TARABA p)
        {
            var ktipi = db.TKASATIPI.Where(k => k.ID == p.TKASATIPI.ID).FirstOrDefault();
            var mark = db.TMARKA.Where(m => m.ID == p.TMARKA.ID).FirstOrDefault();
            p.TKASATIPI = ktipi;
            p.TMARKA = mark;
            db.TARABA.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult ArabaSil(int id)

        {
            var araba = db.TARABA.Find(id);
            db.TARABA.Remove(araba);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ArabaGetir(int id)
        {
            var arabas = db.TARABA.Find(id);

            List<SelectListItem> value1 = (from i in db.TKASATIPI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KASATIPI,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.v1 = value1;
            List<SelectListItem> value2 = (from i in db.TMARKA.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MARKA,
                                               Value = i.ID.ToString()

                                           }).ToList();
            ViewBag.v2 = value2;

            return View("ArabaGetir", arabas);
        }
        public ActionResult ArabaGuncelle(TARABA p)
        {
            var araba = db.TARABA.Find(p.ID);
            araba.MODEL= p.MODEL;
            araba.URETIMYILI = p.URETIMYILI;
            araba.KM = p.KM;
           
            var kasatipi1=db.TKASATIPI.Where(k=>k.ID==p.TKASATIPI.ID).FirstOrDefault();   
            var marka1=db.TMARKA.Where(m=>m.ID==p.TMARKA.ID).FirstOrDefault();
            araba.KASATIPI = kasatipi1.ID;
            araba.MARKA = marka1.ID;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}