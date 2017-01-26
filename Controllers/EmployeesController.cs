using CaseLogger3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;


/*@*Caitlin Boake 
    ASP.NET 
    5/12/16 
    C# with EF*@*/

namespace CaseLogger3.Controllers
{
    public class EmployeesController : Controller
    {

        private CaseContext db = new CaseContext();

        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee e)
        {
            if (ModelState.IsValid)
            {
                var v = db.employees.Where(model => model.EmployeeNum.Equals(e.EmployeeNum) && model.Password.Equals(e.Password)).FirstOrDefault();
                if (v != null)
                {
                    //long/old method of setting Session vars
                    //Are these declarations equivalent? They seem to work the same
                    System.Web.HttpContext.Current.Session["LogEmpID"] = v.EmployeeNum.ToString();
                    System.Web.HttpContext.Current.Session["LogEmpName"] = v.Lname.ToString();
                    //new/short method of setting Session vars
                    Session["LogEmpDbID"] = v.EmployeeID.ToString();

                    //sets local date
                    DateTime localDT = DateTime.Today;
                    string localToday = localDT.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    Session["LogDate"] = localToday;

                    //gives viewbag message, that mysteriously doesn't appear in my afterlogin page. out of reach? 
                    ViewData["Msg"] = "Login in successful";
                    ViewBag.Msg = "Login in successful";
                    return RedirectToAction("AfterLogin");
                }
                else
                    return View();
            }
            return View();
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogEmpDbID"] == null) //checks if logged in
            {
                HttpContext.Application["MsgError"] = "Please log in";
                return RedirectToAction("Login");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}