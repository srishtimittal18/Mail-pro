using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MailPro.Models;
using System.Web.Security;

namespace MailPro.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using(var context = new MailProEntities())
            {
                bool IsValid = context.FacultyTable.Any(x => x.FacultyEmail == model.FacultyEmail && x.Password == model.Password);
                if(IsValid)
                {
                    FormsAuthentication.SetAuthCookie(model.FacultyEmail, false);
                    return RedirectToAction("Index", "GetAllSudents");
                }
                ModelState.AddModelError("", "Invalid Email or Password");
                return View();
            }
            
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(FacultyTable model)
        {
            using( var context = new MailProEntities())
            {
                context.FacultyTable.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
    }
}