using CaseLogger3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*@*Caitlin Boake 
    ASP.NET 
    5/12/16 
    C# with EF*@*/


namespace CaseLogger3.Controllers
{
    public class StudentsController : Controller
    {

        private CaseContext db = new CaseContext();

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult StudentSearch()
        {
            if (Session["LogEmpDbID"] != null)
            {
                return View();
            }
            else
            {
                Session["MsgError"] = "Please log in"; //I guess the session hasn't "begun" yet? I tried viewdata vars too but ended up using the app var
                HttpContext.Application["MsgError"] = "Please log in";
                return RedirectToAction("Login", "Employees");
            }
        }

        [HttpPost]
        public ActionResult StudentSearch(string txtLname, string txtSdtID)
        {
            var studentobj = from s in db.students
                             select s;

            //if textbox is not blank, search by last name
            if (txtLname != "")
            {
                studentobj = studentobj.Where(s => s.Lname == txtLname);
                if (studentobj != null) //if found
                {
                    return View(studentobj.ToList());   //because duplicates are not impossible, I am sending ToList() instead of ToString() here
                }
                else
                {
                    ViewBag.NotFound = "Student not found."; //not showing up in my page
                    Session["notFound"] = "Student not found.";
                    return View();
                }
            }

            //if textbox is not blank, search by student id
            if (txtSdtID != "")
            {
                //converts entry string to int 
                //how can I error catch for this? I need to learn to use try/catch/finally
                //also, how can I validate text
                int int_txtSdtID = Convert.ToInt32(txtSdtID);
                studentobj = studentobj.Where(s => s.StudentNum == int_txtSdtID);
                db.students.Find(int_txtSdtID); //cool fact, this is the same query as above!
                if (studentobj != null) //if found
                {
                    return View(studentobj.ToList());
                }
                else
                {
                    ViewBag.NotFound = "Student not found."; //not showing up in my page, its not accessible, the studentobj is not null even if not found
                    return View();
                }
            }
            return View();
        }

        public ActionResult NewCase(int? id)
        {
            //redirect to cases controller with routing var passvar
            if (id != null)
            {
                int thisStdID = (int)id;
                return RedirectToAction("Create", "Cases", new { passvar = thisStdID }); //holds student id
            }
            else
            {
                return RedirectToAction("Create", "Cases"); //if somehow the student id is unavailable it just links to the create page in cases
            }
        }

        protected override void Dispose(bool disposing) //disposes of db
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}