using ProjectUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUni.Controllers
    {
    public class CategoryController : Controller
    {
//ADD CARTIDEORY
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Categories.Where(x=>x.IsDeleted==false).ToList());

        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Category a)
        {
            a.CreationTime = DateTime.Now;
            a.IsDeleted = false;
            a.CreateionUser = User.Identity.Name;
            db.Categories.Add(a);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            var category = db.Categories.SingleOrDefault(x => x.Id == id);
            category.IsDeleted = true;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int id)
        {

            return View(db.Categories.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            var category = db.Categories.Find(cat.Id);
            category.Name = cat.Name;
            cat.img = cat.img;
            cat.ModifyTime = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult category(string name)
        {
            db.adv.Include("Category").Where(p => p.Category.Name == name);
            return View();
        }
    }
}