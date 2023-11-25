using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RENTACARAPP.Models.Entity;

namespace RENTACARAPP.Controllers
{
    public class SatislemanController : Controller
    {
        DBRENTALEntities6     db = new DBRENTALEntities6();
        public ActionResult Index()
        {
            var değerler = db.TSATISELEMAN.ToList();
            return View(değerler);
        }

        [HttpGet]
        public ActionResult SatislemanEkle()
        {
            return View();

        }


        [HttpPost]
        public ActionResult SatislemanEkle(TSATISELEMAN p)
        {
            if(!ModelState.IsValid) 
            {
            return View("SatislemanEkle");
            }
           db.TSATISELEMAN.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SatislemanSil(int id)
        {
            var satiselemans = db.TSATISELEMAN.Find(id);
            db.TSATISELEMAN.Remove(satiselemans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatislemanGetir(int id)
        {
            var satiselemans = db.TSATISELEMAN.Find(id);

            return View("SatislemanGetir", satiselemans);

        }
        public ActionResult SatislemanGuncelle(TSATISELEMAN p)
        {

            var satiselemans = db.TSATISELEMAN.Find(p.ID);
            satiselemans.SATISLEMAN = p.SATISLEMAN;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}