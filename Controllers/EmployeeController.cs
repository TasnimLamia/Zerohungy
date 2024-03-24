using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zerohungy.EF;

namespace Zerohungy.Controllers
{
    public class EmployeeController : Controller
    {
        readonly ZerohungryEntities db = new ZerohungryEntities();
        // GET: Employee
        [HttpGet]
        public ActionResult Employee()
        {
            if (Session["employee"] != null)
            {
                var data = db.Food_Collect.ToList();
                var convertedData = ModeratorController.Convert(data);
                return View(convertedData);
            }
            return RedirectToAction("Login", "Login");

        }
        [HttpPost]
        public ActionResult Logout() {
            Session.Abandon();
            if (Session["employee"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return RedirectToAction("Employee");
        
        }
        [HttpPost]
        public ActionResult Employee(string name,int id)
        {
            ViewBag.name = name;
           // var empId = db.Employees.Where(u => u.EMP_NAME.Equals(name, StringComparison.OrdinalIgnoreCase)).Select(u => u.EMP_ID).FirstOrDefault();
            //var data1 = db.Food_Collect.Where(emp => emp.Received_By == empId).Select(p => p.Collectid).FirstOrDefault();
            var data2 = db.Histories.Find(id);
            var collect = db.Food_Collect.Find(id);
            if (data2.STATUS != "Collected")
            {
                data2.STATUS = "Collected";
                db.Food_Collect.Remove(collect);
                db.SaveChanges();
            }
            else
            {
                TempData["collect"] = "Already Marked as Collected";
                return RedirectToAction("Employee");
            }




            return RedirectToAction("Employee");

        }
    }
}