using CaseLogger3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaseLogger3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Application["MsgError"] = "";
        }

        //I just remembered that I should have a module here, I added it late in the development of this project
        //So what exactly is going on here below? 
        //It seems like I'm 2 separate session variables, one is set to the integer 1 (but why?)
        //And the other is set to a new instance of the Employee object
        //How should I have used this employee object in my program?
        //When is this module called? Upon the creation of session variables in my Employee Controller upon login?
        protected void Session_Start(Object sender, EventArgs e)
        {
            int temp = 1;
            HttpContext.Current.Session.Add("_SessionCompany", temp);
            HttpContext.Current.Session.Add("_thisEmployee", new Employee());
        }
    }
}
