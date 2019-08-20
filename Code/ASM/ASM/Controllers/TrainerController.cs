using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASM.Models;

namespace ASM.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult ProfileTrainer()
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
         //   string a = Convert.ToString(Session["id"]);
            return View(db.Profile_User.Find( Session["id"] , null));

        }

    }
}