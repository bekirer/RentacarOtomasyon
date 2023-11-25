using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RENTACARAPP.Models.Entity;

namespace RENTACARAPP.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Kullanıcı
        DBRENTALEntities6 db = new DBRENTALEntities6();
        public ActionResult Index()
        {
            var değerler = db.TUYELER.ToList();
            return View(değerler);
            
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();

        }


        [HttpPost]
        public ActionResult UyeEkle(TUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TUYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TUYELER.Find(id);
            db.TUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TUYELER.Find(id);

            return View("UyeGetir", uye);

        }
        public ActionResult UyeGuncelle(TUYELER p)
        {
            var uye = db.TUYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.EPOSTA = p.EPOSTA;
            uye.NICKNAME = p.NICKNAME;
            uye.SIFRE = p.SIFRE;
            uye.UYEFOTO = p.UYEFOTO;
            uye.TELNO = p.TELNO;
            uye.EHLIYET = p.EHLIYET;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}