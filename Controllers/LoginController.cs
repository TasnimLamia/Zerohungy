using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zerohungy.DTO;
using Zerohungy.EF;

namespace Zerohungy.Controllers
{
    public class LoginController : Controller
    {
       readonly ZerohungryEntities db = new ZerohungryEntities();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Name,string Password)
        {
            var mod = (from u in db.Moderators where u.M_NAME.Equals(Name) && u.M_PASS.Equals(Password) select u).FirstOrDefault() ;
            var emp = (from u in db.Employees where u.EMP_NAME.Equals(Name) && u.EMP_PASS.Equals(Password) select u).FirstOrDefault();
            var resturant = (from u in db.Resturants where u.RESTNAME.Equals(Name) && u.REST_PASS.Equals(Password) select u).FirstOrDefault();
            if(mod!=null && emp==null && resturant==null) {
                Session["moderator"] = mod;
                Session["mod_name"] = Name;
                return RedirectToAction("MOD","Moderator");
            
            }
            if (emp != null && mod == null && resturant == null)
            {
                Session["employee"]= emp;
                Session["name"] = Name;
                return RedirectToAction("Employee", "Employee");
            }
            if(resturant!=null && emp == null && mod == null)
            {
                Session["resturant"]= resturant;
                Session["num"] = Name;
                return RedirectToAction("Resturant", "Resturant");
            }
            return View();
        }

    }
}