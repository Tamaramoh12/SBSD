using ProjectUni.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectUni.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;

        public HomeController()
        {
            db = new ApplicationDbContext();

        }

        public ActionResult Index()
        {
           // List<menu> s= db.menu.Where(x => x.Type == "header").ToList();
            // type header,text home ,link xxx
            //type '',text about,link kkk

            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.footer = db.menu.Where(x => x.Type == "footer").ToList();
            ViewBag.e = db.slider.ToList();
            ViewBag.cat = db.Categories.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Header()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            VMnotification model = new VMnotification();
            var notifications = db.Notification.Where(x => x.userid == User.Identity.Name).ToList();
            if (notifications == null)
            {
                model.Count = 0;
                model.notifications = null;
                return View(model);
            }
            model.Count = notifications.Count();
            model.notifications = notifications;

            return View(model);
        }
        public ActionResult Footer()
        {

            return View();
        }
        public ActionResult ADV()
        {
            ViewBag.x = db.adv.ToList();

            return View();

        }
        [Authorize]
        public ActionResult create()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();

            ViewBag.sa = db.Categories.ToList();

            return View();
        }

        public ActionResult view(int id)  // تفاصيل القطعة
        {
            var data = db.adv.Where(x => x.Id == id).Include(l=>l.images).SingleOrDefault();
             ViewBag.comments = db.comments.Where(x => x.idadv == id).Include(x=>x.image).ToList();
            return View(data);
        }
                  
        [HttpPost]
        public ActionResult create(Adv s, HttpPostedFileBase[] images)

        {
            s.IsActive = false;
            s.IsDeleted = false;
            s.ForSwap = false;
            var user = db.Users.Where(x => x.UserName == User.Identity.Name).SingleOrDefault();
            user.numberofadvs += 1;

            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.sa = db.Categories.ToList();
            if (user.numberofallowadv < user.numberofadvs)
            {
                ModelState.AddModelError("", "لا يوجد لديك رصيد كافي يرجى شحن رصيدك");
                return View(s);
            }

            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToArray();
                if (errorList[0] != "")
                {


                    return View(s);
                }
            }

            s.CreateionUser = User.Identity.Name;
            List<Images> xa = new List<Images>();

            foreach (var item in images)

            {
                byte[] data;
                using (Stream inputStream = item.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                    xa.Add(new Images() { image = data });
                }
            }
            s.images = xa;
            s.IsActive = false;
            s.ForSwap = false;
            db.adv.Add(s);
            db.SaveChanges();
         
            return RedirectToAction("listofadv");
        }

        public ActionResult DeleteAdvs(int id)
        {
             var t = db.adv.Include("images").SingleOrDefault(x => x.Id == id);
            db.adv.Remove(t);
            db.SaveChanges();
            return RedirectToAction("listofadv");
        }
        [Authorize]
        public ActionResult Donate()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            return View();
        }
       
       



        [HttpPost]
        public ActionResult Donate(Donate a, HttpPostedFileBase[] images)

        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.sa = db.Categories.ToList();

            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToArray();
                if (errorList[0] != "")
                {


                    return View(a);
                }

            }
            List<Images> xa = new List<Images>();
            if (images[0] !=null ) {
            foreach (var item in images)
            {
                byte[] data;
                using (Stream inputStream = item.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                    xa.Add(new Images() { image = data });
                }
            }
            a.Image = xa;
            }
            db.Donates.Add(a);
            db.SaveChanges();
            return Redirect("/home/Donate?done=true");
        }
        public ActionResult swap()
        {

            return View(db.adv.ToList());
        }
        [Authorize]
        public ActionResult createswap()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();

            ViewBag.sa = db.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult createswap(Adv q, HttpPostedFileBase[] images)
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToArray();
                if (errorList[0] != "")
                {


                    return View(q);
                }
              
            }


            List<Images> xa = new List<Images>();

            foreach (var item in images)
            {
                byte[] data;
                using (Stream inputStream = item.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                    xa.Add(new Images() { image = data });
                }
            }
            q.images = xa;
            q.CreateionUser = User.Identity.Name;
            q.ForSwap = true;
            db.adv.Add(q);
            db.SaveChanges();
            ViewBag.q = db.adv.Where(x => x.IsActive == true).Include(x => x.images).ToList();

            return View("listofadv");
        }

        

        public ActionResult AboutUs()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();

            return View();

        }


        public ActionResult FAQ()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();

            return View();


        }
        public ActionResult Feasdback()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            return View(db.Feadbacks.ToList());
        }

        public ActionResult createFB()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            return View();
        }
        [HttpPost]
        public ActionResult createFB(Feadback F)
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToArray();
                if (errorList[0] != "")
                {


                    return View(F);
                }
            }

            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            db.Feadbacks.Add(F);
            db.SaveChanges();

            return RedirectToAction("Index");


        }
        public ActionResult listofadv()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.q=db.adv.Where(x=>x.IsActive==true).Include(x=>x.images).ToList();

            return View();
        }
        [HttpPost]
        public ActionResult search(string text)
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.q = db.adv.Where(x => x.IsActive == true&&x.title.Contains(text)).Include(x => x.images).ToList();
            ViewBag.q = db.adv.Where(x => x.IsActive == true && x.Address.Contains(text)).Include(x => x.images).ToList();

            return View();
        }
        public ActionResult ListOfSwap()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.q = db.adv.Where(x => x.IsActive == true && x.ForSwap == true).Include(x => x.images).ToList();

            return View();
        }
        public ActionResult listofsell()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.q = db.adv.Where(x => x.IsActive == true && x.ForSwap == false).Include(x => x.images).ToList();

            return View();
        }

        public ActionResult listofadvBycategory(int id)
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.q = db.adv.Where(x => x.IsActive == true && x.CategoryId==id).Include(x => x.images).ToList();

            return View();
        }
        public ActionResult AdvForUser(string username)
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.q = db.adv.Where(x => x.IsActive == true && x.CreateionUser==username).Include(x => x.images).ToList();
            ViewBag.usera = db.Users.Where(x => x.UserName == username).SingleOrDefault();


            return View();
        }

       
     
        public ActionResult AgreementOfUse()  //اتفاقية الاستخدام
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();

            return View();

        }

        public ActionResult cooment()  // تفاصيل القطعة
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult createcooment(comment u, HttpPostedFileBase[] images)  // تفاصيل القطعة
        {


            

            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            ViewBag.sa = db.Categories.ToList();
            if (!ModelState.IsValid)
            {
                var errorList = (from item in ModelState
                                 where item.Value.Errors.Any()
                                 select item.Value.Errors[0].ErrorMessage).ToArray();
                if (errorList[0] != "")
                {


                    return View(u);
                }
            }

            u.CreateionUser = User.Identity.Name;
            List<Images> xa = new List<Images>();

            foreach (var item in images)

            {
                byte[] data;
                using (Stream inputStream = item.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                    xa.Add(new Images() { image = data });
                }
            }
            u.image = xa;
           
            db.comments.Add(u);
            db.SaveChanges();
            return RedirectToAction("listofadv");
        }
        public ActionResult Accountbanking()
        {

            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult Accountbanking(int amount)
        {
            var number = 0;
            if (amount == 2) number = 3;
            if (amount == 4) number = 8;
            if (amount == 6) number = 14;
          
            var user = db.Users.Where(x => x.UserName == User.Identity.Name).SingleOrDefault();
            user.numberofallowadv = number;
            db.SaveChanges();
            return RedirectToAction("listofadv");
        }
        public ActionResult listofcooment()
        {
            ViewBag.header = db.menu.Where(x => x.Type == "header").ToList();
            var coment = new List<comment>();
            var sa = db.comments.Include(s => s.adv).Include(x=>x.image).Where(x => x.adv.CreateionUser == User.Identity.Name).ToList();
           
            return View(sa); 
        }
        public ActionResult ActionName()
        {

            return View();
        }
    }

    //End Footer
}
