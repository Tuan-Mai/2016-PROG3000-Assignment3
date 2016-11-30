using PROG3000_asn3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROG3000_asn3.Controllers
{
    public class UserAccountsController : Controller
    {
        // GET: UserAccounts
        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
            }
            return View();
        }

        [HttpPost]
        public ActionResult UserLogin(string username, string password)
        {
            if (password.Equals(ReverseUsername(username)))
            {
                Session["user"] = new User() { Login = "User", Username = username, Password = password };
                return RedirectToAction("Index", "UserAccounts");
            }

            else
            {
                Session["user"] = new User() { Login = "Failed" };
                return RedirectToAction("Index", "UserAccounts");
            }
            return View();
        }

        [HttpPost]
        public ActionResult ManagerLogin(string username, string password)
        {


            if (password.Equals(ReverseUsername(username)))
            {
                if (username.Equals("Ray") || username.Equals("Amanda"))
                {
                    Session["user"] = new User() { Login = "Admin", Username = username, Password = password };
                    return RedirectToAction("Index", "UserAccounts");
                }

                else
                {
                    Session["user"] = new User() { Login = "NotManager" };
                    return RedirectToAction("Index", "UserAccounts");
                }
            }

            else
            {
                Session["user"] = new User() { Login = "Failed" };
                return RedirectToAction("Index", "UserAccounts");
            }
            return View();
        }

        public static string ReverseUsername(string username)
        {
            username = username.ToLower();
            char[] charArray = username.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public ActionResult ReviewReceivables()
        {
            return View();
        }
    }
}