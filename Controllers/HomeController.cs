using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webNews.Models1;

namespace webNews.Controllers
{
    public class HomeController : Controller
    {
        webnewsEntities db = new webnewsEntities();

        public ActionResult Index()
        {
            ViewBag.news = db.news.ToList();
            ViewBag.category = db.Categories.ToList();
            return View();
        }
        public ActionResult Delete(int Id)
        {
            news nw = db.news.Find(Id);
            db.news.Remove(nw);
            db.SaveChanges();
            return RedirectToAction("index");
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
        [HttpPost]
        public ActionResult Add(news nw)
        {
            if (nw.Title == string.Empty || nw.CategoryId == 0 || nw.Text == string.Empty)
            {
                RedirectToAction("index");
            }
            db.news.Add(nw);
            db.SaveChanges();
            return RedirectToAction("index");


        }
    }
}