using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASM.Models;

namespace ASM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User_Account lg)
        {
            if(ModelState.IsValid)
            {
                using (QLDaiHocEntities1 ue = new QLDaiHocEntities1())
                {
                    var log = ue.User_Account.Where(a => a.UserName.Equals(lg.UserName) && a.Password.Equals(lg.Password)).FirstOrDefault();
                    if(log != null)
                    {
                        Session["username"] = log.UserName;
                        

                        if (log.Position == "admin")
                        {
                            return RedirectToAction("UserHome", "Home");
                        }
                        if (log.Position == "staff")
                        {
                            return RedirectToAction("TraineeAccount", "StaffPage");
                        }
                        if (log.Position == "trainer")
                        {
                            Session["id"] = ue.Profile_User.Where(a => a.UserID.Equals(log.UserID));
                            return RedirectToAction("ProfileTrainer", "Trainer");
                        }
                        //if (log.Position == "trainee")
                        //{
                        //    return RedirectToAction("StaffMana", "StaffPage");
                        //}
                    }
                    else
                    {
                        Response.Write("<script>alert('sai mat khau')</script>");
                    }
                }
            }
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}