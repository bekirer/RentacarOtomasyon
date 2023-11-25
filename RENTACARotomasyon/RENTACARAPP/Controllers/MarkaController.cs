using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RENTACARAPP.Models.Entity;

namespace RENTACARAPP.Controllers
{
    public class MarkaController : Controller
    {
        DBRENTALEntities6 db = new DBRENTALEntities6();   
        public ActionResult Index()
        {
            var degerler = db.TMARKA.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult MarkaEkle() 
        
        { 
            return  View();
            
        }
        public ActionResult MarkaEkle(TMARKA x) 
        
        { 
        db.TMARKA.Add(x);
        db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MarkaSil(int id)

        {
            var marka=db.TMARKA.Find(id);
            db.TMARKA.Remove(marka);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        public ActionResult MarkaGetir(int id)
        {
            var brand=db.TMARKA.Find(id);
            return View("MarkaGetir", brand);
        }
        public ActionResult MarkaGuncelle(TMARKA p)
        {
            var mark=db.TMARKA.Find(p.ID);
            mark.MARKA = p.MARKA;
            mark.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
                
    }
}