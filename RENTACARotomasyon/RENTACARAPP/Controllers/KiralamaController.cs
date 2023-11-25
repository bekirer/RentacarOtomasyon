using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RENTACARAPP.Models.Entity;
using System.Web.Mvc;

namespace RENTACARAPP.Controllers
{
    public class KiralamaController : Controller
    { DBRENTALEntities6 db = new DBRENTALEntities6();
        // GET: Kiralama
        public ActionResult Index()
        {
            var dgr=db.TAKSIYON.ToList();   
            return View(dgr);
        }

        [HttpGet] 
        public ActionResult Kiralama()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult Kiralama(TAKSIYON p)
        {
            TimeSpan ts = (TimeSpan)(p.TESLIMTARIH - p.KIRALAMATARIH);
            TimeSpan ts2 = (TimeSpan)(p.KIRALAMATARIH - DateTime.UtcNow.Date);
            if (ts2 < TimeSpan.Zero)
            {
                ViewBag.KiralamaError = "Veriler Eklenemedi. Kiralama tarihi ve Teslim tarihini kontrol ediniz.";
                return View();
            }
            if (ts <= TimeSpan.Zero)
            {
                ViewBag.TeslimError = "Veriler Eklenemedi. Kiralama tarihi ve Teslim tarihini kontrol ediniz.";
                return View();
            }
            db.TAKSIYON.Add(p);
            db.SaveChanges();
            return View();


        }
        
       
    }


    
}