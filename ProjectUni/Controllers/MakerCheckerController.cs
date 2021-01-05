using ProjectUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUni.Controllers
{
    public class MakerCheckerController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.adv.Where(x=>x.IsActive==false));
        }
        public ActionResult Active(int id)
        {
            var adv = db.adv.Find(id);
            adv.IsActive = true;
            db.SaveChanges();
            Notification model=new Notification();
            model.body = "تم  الموافقه على اعلانك بنجاح";
            model.date = DateTime.Now;
            model.idadv = id;
            model.userid = adv.CreateionUser;
            db.Notification.Add(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Deactive(int id,string msg)
        {
            var adv = db.adv.Find(id);
            adv.IsActive = false;
            adv.IsDeleted = true;
            db.SaveChanges();
            Notification model = new Notification();
            model.body =" تم  رفض  اعلانك";
            model.body += msg;
            model.date = DateTime.Now;
            model.idadv = id;
            model.userid = adv.CreateionUser;
            db.Notification.Add(model);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}