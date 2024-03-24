using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zerohungy.DTO;
using Zerohungy.EF;

namespace Zerohungy.Controllers
{
    public class ModeratorController : Controller
    {
        readonly ZerohungryEntities db = new ZerohungryEntities();
        [HttpGet]
        public ActionResult MOD()
        {

            if (Session["moderator"] != null)
            {
                var data = db.Food_Collect.ToList();
               // var his=db.Histories.ToList();
                var convertedData = Convert(data);
               // var convertedhis=Convert(his);

                return View(convertedData);
            }
               
            
           return RedirectToAction("Login", "Login");
            
        }
        [HttpGet]
        public ActionResult History()
        {

            if (Session["moderator"] != null)
            {
                var his = db.Histories.ToList();
                var convertedhis = Convert(his);


                return View(convertedhis);
            }

            return RedirectToAction("Login", "Login");

        }
        [HttpPost]
        public ActionResult Logout()
        {
            Session.Abandon();
            if (Session["moderator"] != null)
            {
                return RedirectToAction("MOD","Moderator");
                
            }
            return RedirectToAction("Login", "Login");

        }
        [HttpGet]
        public ActionResult Assign(int id)
        {
            ViewBag.ID = id;
            var user = db.Employees.ToList();
            var convertUser = Convert(user);
            return View(convertUser);
        }
        [HttpPost]
        public ActionResult Assign(int id, int emp_id, string name)
        {
            ViewBag.name = name;
            var adminId = db.Moderators.Where(u => u.M_NAME.Equals(name, StringComparison.OrdinalIgnoreCase)).Select(u => u.M_ID).FirstOrDefault();
            //var ad = admin.Select;
            var collect = db.Food_Collect.Find(id);
            var rest_id=db.Food_Collect.Where(u=>u.C_ID.Equals(id)).Select(p=>p.REST_ID).FirstOrDefault();
            var loc = db.Food_Collect.Where(u => u.C_ID.Equals(id)).Select(p=>p.LOCATION).FirstOrDefault();
            var time = db.Food_Collect.Where(u => u.C_ID.Equals(id)).Select(p => p.PRESERVE_TIME).FirstOrDefault();
            var check = db.Histories.Find(id);
            
                History history = new History
                {
                    C_ID = id,
                    Approved_by = adminId,
                    Received_by = emp_id,
                    REST_ID = rest_id,
                    LOCATION = loc,
                    Approve_Date = DateTime.Today,
                    STATUS = "Approved",
                    PRESERVE_TIME=time,
                    
                };
                db.Histories.Add(history);
                db.SaveChanges();
            
            

            return RedirectToAction("MOD");
        }
        public ActionResult Decline(int id)
        { 
            var rem=db.Food_Collect.Find(id);
            var rest_id = db.Food_Collect.Where(u => u.C_ID.Equals(id)).Select(p => p.REST_ID).FirstOrDefault();
            var loc = db.Food_Collect.Where(u => u.C_ID.Equals(id)).Select(p => p.LOCATION).FirstOrDefault();
            var time = db.Food_Collect.Where(u => u.C_ID.Equals(id)).Select(p => p.PRESERVE_TIME).FirstOrDefault();
            var check = db.Histories.Find(id);
            History history = new History
            {
                C_ID = id,
                REST_ID = rest_id,
                LOCATION = loc,
                Approve_Date = DateTime.Today,
                STATUS = "Rejected",
                PRESERVE_TIME = time,

            };
            db.Histories.Add(history);
            db.Food_Collect.Remove(rem);
            db.SaveChanges();
            return RedirectToAction("MOD");
        }

        public static EmployeeDTO Convert(Employee user)
        {
            return new EmployeeDTO
            {
                EMP_ID = user.EMP_ID,
                EMP_NAME = user.EMP_NAME,
                EMP_PASS = user.EMP_PASS,
            };
        }
        public static Employee Convert(EmployeeDTO c)
        {
            return new Employee
            {
                EMP_ID = c.EMP_ID,
                EMP_NAME = c.EMP_NAME,
                EMP_PASS = c.EMP_PASS,


            };
        }
        public static List<EmployeeDTO> Convert(List<Employee> data)
        {

            var list = new List<EmployeeDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));

            }
            return list;


        }

        public static Food_CollectDTO Convert(Food_Collect c)
        {
            return new Food_CollectDTO
            {
                C_ID = c.C_ID,
                REST_ID = c.REST_ID,
                PRESERVE_TIME = c.PRESERVE_TIME,
                LOCATION = c.LOCATION,
                STATUS = c.STATUS,
            };
        }
        public static Food_Collect Convert(Food_CollectDTO c)
        {
            return new Food_Collect
            {
                C_ID = c.C_ID,
                REST_ID = c.REST_ID,
                PRESERVE_TIME = c.PRESERVE_TIME,
                LOCATION = c.LOCATION,
                STATUS = c.STATUS,

            };
        }

        public static List<Food_CollectDTO> Convert(List<Food_Collect> data)
        {

            var list = new List<Food_CollectDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));

            }
            return list;


        }
        public static HistoryDTO Convert(History c)
        {
            return new HistoryDTO
            {
                C_ID = c.C_ID,
                REST_ID = c.REST_ID,
                PRESERVE_TIME = c.PRESERVE_TIME,
                LOCATION = c.LOCATION,
                STATUS = c.STATUS,
                Approve_Date = c.Approve_Date,
                Approved_by = c.Approved_by, 
                Received_by = c.Received_by,    
            };
        }
        public static History Convert(HistoryDTO c)
        {
            return new History
            {
                C_ID = c.C_ID,
                REST_ID = c.REST_ID,
                PRESERVE_TIME = c.PRESERVE_TIME,
                LOCATION = c.LOCATION,
                STATUS = c.STATUS,
                Approve_Date = c.Approve_Date,
                Approved_by = c.Approved_by,
                Received_by = c.Received_by,

            };
        }
        public static List<HistoryDTO> Convert(List<History> data)
        {

            var list = new List<HistoryDTO>();
            foreach (var item in data)
            {
                list.Add(Convert(item));

            }
            return list;


        }
    }
}