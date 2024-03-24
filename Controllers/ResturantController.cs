using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zerohungy.DTO;
using Zerohungy.EF;

namespace Zerohungy.Controllers
{
    public class ResturantController : Controller
    {
        readonly ZerohungryEntities db = new ZerohungryEntities();
        [HttpGet]
        public ActionResult Resturant()
        {
            if (Session["resturant"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Login");
            
        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Abandon();
            if (Session["resturant"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return RedirectToAction("Resturant");

        }
        [HttpPost]
        public ActionResult Resturant(Food_CollectDTO req, string id)
        {

            var data = db.Resturants.Where(u => u.RESTNAME.Equals(id)).Select(p => p.RESTID).FirstOrDefault();
            
            Food_Collect request = new Food_Collect
            {
                PRESERVE_TIME = req.PRESERVE_TIME,
                LOCATION = req.LOCATION,
                REST_ID = data,
                STATUS="PENDING"
            };

            db.Food_Collect.Add(request);

            db.SaveChanges();

            return RedirectToAction("Resturant");

        }
    }
}