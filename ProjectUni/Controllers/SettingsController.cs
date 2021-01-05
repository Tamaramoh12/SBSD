using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectUni.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUni.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SettingsController : Controller
    {
        // GET: Settings
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateSlider()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateSlider(slider v, HttpPostedFileBase file)
        {
            slider s = new slider();
            s.CreateionUser = User.Identity.Name;
            s.IsDeleted = false;
            s.CreationTime = DateTime.Now;
            s.Links = v.Links;
            s.Text = v.Text;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                s.photo = memoryStream.ToArray();
            }

            db.slider.Add(s);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult listofslider()
        {


            return View(db.slider.ToList());
        }
        public ActionResult Deleteslider(int id)
        {
            var x = db.slider.SingleOrDefault(p => p.Id == id);
            db.slider.Remove(x);
            db.SaveChanges();
            return RedirectToAction("listofslider");
        }
        public ActionResult createmenu()
        {

            return View();
        }
        [HttpPost]
        public ActionResult createmenu(menu c)
        {
            menu d = new menu();
            d.IsDeleted = false;
            d.CreationTime = DateTime.Now;
            db.menu.Add(c);
            db.SaveChanges();
            return RedirectToAction("listofmenu");
        }
        public ActionResult Deletemenu(int id)
        {
            var f = db.menu.SingleOrDefault(p => p.Id == id);
            db.menu.Remove(f);
            db.SaveChanges();
            return RedirectToAction("listofmenu");
        }
        public ActionResult Edit(int id)
        {

            return View(db.menu.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(menu s)
        {
            var category = db.menu.Find(s.Id);
            s.text = s.text;
            s.link = s.link;
            s.ModifyTime = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("listofmenu");
        }
        public ActionResult listofmenu()
        {

            return View(db.menu.ToList());
        }
        public ActionResult createrole()
        {

            return View();
        }
        [HttpPost]
        public ActionResult createrole(string rolename)
        {
            IdentityRole e = new IdentityRole();
            e.Name = rolename;

            db.Roles.Add(e);
            db.SaveChanges();
            return RedirectToAction("listofrole");
        }
        public ActionResult listofrole()
        {
            ViewBag.s = db.Roles.ToList();
            return View();

        }
        public ActionResult AddRoleToUser()
        {
            ViewBag.user = db.Users.ToList();
            ViewBag.role = db.Roles.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddUserToRole(string userid, string rolename)
        {
            var usermanger = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            usermanger.AddToRole(userid, rolename);
            db.SaveChanges();
            return RedirectToAction("listofrole");
        }
        public ActionResult createcat()
        {

            return View();
        }

        [HttpPost]
        public ActionResult createcat(Category f)
        {
            Category d = new Category();
            d.IsDeleted = false;
            d.CreationTime = DateTime.Now;
            db.Categories.Add(f);
            db.SaveChanges();
            return RedirectToAction("listofcat");
        }

        public ActionResult listofcat()
        {

            return View(db.Categories.ToList());


        }
        public ActionResult Deletecat(int id)
        {
            var t = db.Categories.SingleOrDefault(p => p.Id == id);
            db.Categories.Remove(t);
            db.SaveChanges();
            return RedirectToAction("listofcat");
        }
        public ActionResult listofdonate()
        {


            return View(db.Donates.Include("image").ToList());
        }
        public ActionResult image(int id)
        {
            var t = db.Donates.Include("image").SingleOrDefault(x => x.Id == id);
            return View(t);
        }
        public ActionResult imageAdv(int id)
        {
            var t = db.adv.Include("images").SingleOrDefault(x => x.Id == id);
            return View(t);
        }

        public ActionResult listoffeadback()
        {

            return View(db.Feadbacks.ToList());


        }
        public ActionResult deletefb(int id)
        {
            var t = db.Feadbacks.SingleOrDefault(p => p.Id == id);
            db.Feadbacks.Remove(t);
            db.SaveChanges();
            return RedirectToAction("listoffeadback");
        }
    }
}
    
        


