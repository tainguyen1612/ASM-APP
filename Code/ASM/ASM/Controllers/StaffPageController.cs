using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASM.Models;

namespace ASM.Controllers
{
    public class StaffPageController : Controller
    {
        //Show trainee account
        public ActionResult TraineeAccount()
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            List<User_Account> acc1 = db.User_Account.Where(a => a.Position == "trainee").ToList();
            return View(acc1);
        }
        //CRUD trainee account
        public ActionResult AddAccountTrainee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAccountTrainee(User_Account acc)
        {
            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                if (ModelState.IsValid)
                {
                    db.User_Account.Add(acc);
                    if (acc.Position == "trainee")
                    {
                        db.SaveChanges();
                    }
                    return RedirectToAction("TraineeAccount", "StaffPage");
                }
            }
            return View();
        }
        public ActionResult EditAccountTrainee(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var acc = db.User_Account.FirstOrDefault(x => x.UserID == id);
            return View(acc);
        }
        [HttpPost]
        public ActionResult EditAccountTrainee(User_Account acc)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            User_Account us = new User_Account();
            us.UserID = acc.UserID;
            us.UserName = acc.UserName;
            us.Password = acc.Password;
            us.Position = acc.Position;
            db.Entry(us).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("TraineeAccount", "StaffPage");
        }

        public ActionResult DeleteAccountTrainee(string id)
        {
            DeleteAccount(id);
            return RedirectToAction("TraineeAccount", "StaffPage");
        }
        [HttpPost]
        private void DeleteAccount(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var acc = db.User_Account.FirstOrDefault(x => x.UserID == id);
            db.User_Account.Remove(acc);
            db.SaveChanges();
        }


        // GET: StaffPage
        public ActionResult StaffMana()
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            List<Category_Course> course = db.Category_Course.ToList();
            return View(course);
        }
        //CRUD View category
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category_Course cate)
        {
            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                if (ModelState.IsValid)
                {
                    db.Category_Course.Add(cate);
                    db.SaveChanges();
                    return RedirectToAction("StaffMana", "StaffPage");
                }
            }
            return View();
        }
        public ActionResult EditCategory(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var cate = db.Category_Course.FirstOrDefault(x => x.CategoryID == id);
            return View(cate);
        }
        [HttpPost]
        public ActionResult EditCategory(Category_Course cate)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            Category_Course category = new Category_Course();
            category.CategoryID = cate.CategoryID;
            category.Category_Name = cate.Category_Name;
            category.Description = cate.Description;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("StaffMana", "StaffPage");
        }

        public ActionResult DeleteCategory(string id)
        {
            Delete(id);
            return RedirectToAction("StaffMana", "StaffPage");
        }
        [HttpPost]
        private void Delete(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var cate = db.Category_Course.FirstOrDefault(x => x.CategoryID == id);
            db.Category_Course.Remove(cate);
            db.SaveChanges();
        }

        //CRUD View Profile trainer
        //View
        public ActionResult ProTrainer()
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            List<Profile_User> pro = db.Profile_User.ToList();
            List<User_Account> us = db.User_Account.ToList();
            var ma = from b in us
                     join c in pro
                     on b.UserID equals c.UserID
                     where b.Position == "trainer" && b.Position == "trainee"
                     select new Profile_User()
                     {
                         UserID = c.UserID,
                         Full_Name = c.Full_Name,
                         Address = c.Address,
                         Phone = c.Phone,
                         DateOfBirth = c.DateOfBirth,

                     };
            
            return View(ma);
        }
        //Add / edit / delete
        public ActionResult AddPro()
        {
            Profile_User us = new Profile_User();
            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                us.IdCollection = db.User_Account.Where(a => a.Position == "trainer" | a.Position == "trainer").ToList();
            }
            
            return View(us);
        }
        [HttpPost]
        public ActionResult AddPro(Profile_User pro)
        {
            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                if (ModelState.IsValid)
                {
                    db.Profile_User.Add(pro);
                    db.SaveChanges();
                    return RedirectToAction("ProTrainer", "StaffPage");
                }
                else
                {
                    return RedirectToAction("ProTrainer", "StaffPage");
                }
            }
        }
        public ActionResult EditPro(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var pro = db.Profile_User.FirstOrDefault(x => x.UserID == id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult EditPro(Profile_User pro)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            Profile_User prous = new Profile_User();
            prous.UserID = pro.UserID;
            prous.Full_Name = pro.Full_Name;
            prous.Address = pro.Address;
            prous.Phone = pro.Phone;
            prous.DateOfBirth = pro.DateOfBirth;
            db.Entry(prous).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ProTrainer", "StaffPage");
        }

        public ActionResult DeletePro(string id)
        {
            DeleteProfile(id);
            return RedirectToAction("ProTrainer", "StaffPage");
        }
        [HttpPost]
        private void DeleteProfile(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var pro = db.Profile_User.FirstOrDefault(x => x.UserID == id);
            db.Profile_User.Remove(pro);
            db.SaveChanges();
        }

        //CRUD View Course
        public ActionResult CourseMana()
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            List<Course> course = db.Course.ToList();
            return View(course);
        }
        //CRUD View category
        public ActionResult AddCourse()
        {
            Course us = new Course();

            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                us.IdCollection2 = db.User_Account.Where(a => a.Position == "trainee").ToList();
                us.cateCollection = db.Category_Course.ToList();
            }
            return View(us);
        }
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                if (ModelState.IsValid)
                {
                    db.Course.Add(course);
                    db.SaveChanges();
                    return RedirectToAction("CourseMana", "StaffPage");
                }
            }
            return View();
        }
        public ActionResult EditCourse(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            List<Category_Course> cate = db.Category_Course.ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "CategoryID", "CategoryID");

            // Set vào ViewBag
            ViewBag.CategoryList = cateList;

            List<User_Account> us = db.User_Account.Where(a=> a.Position == "trainee").ToList();

            // Tạo SelectList
            SelectList userList = new SelectList(us, "UserID", "UserID");

            // Set vào ViewBag
            ViewBag.userList = userList;

            var co = db.Course.FirstOrDefault(x => x.CourseID == id);
            return View(co);
        }
        [HttpPost]
        public ActionResult EditCourse(Course co)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            Course course = new Course();
            course.CourseID = co.CourseID;
            course.Course_Name = co.Course_Name;
            course.Description = co.Description;
            course.CategoryID = co.CategoryID;
            course.UserID = co.UserID;
            db.Entry(course).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CourseMana", "StaffPage");
        }

        public ActionResult DeleteCourse(string id)
        {
            Delete_Course(id);
            return RedirectToAction("CourseMana", "StaffPage");
        }
        [HttpPost]
        private void Delete_Course(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var co = db.Course.FirstOrDefault(x => x.CourseID == id);
            db.Course.Remove(co);
            db.SaveChanges();
        }
        // View Topic
        public ActionResult TopicMana()
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            List<Topic> topic = db.Topic.ToList();
            return View(topic);
        }
        ///CRUD View Topic
        public ActionResult AddTopic()
        {
            Topic to = new Topic();

            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                to.IdCollection3 = db.User_Account.Where(a => a.Position == "trainer").ToList();
                to.coCollection = db.Course.ToList();
            }
            return View(to);
        }
        [HttpPost]
        public ActionResult AddTopic(Topic topic)
        {
            using (QLDaiHocEntities1 db = new QLDaiHocEntities1())
            {
                if (ModelState.IsValid)
                {
                    db.Topic.Add(topic);
                    db.SaveChanges();
                    return RedirectToAction("TopicMana", "StaffPage");
                }
            }
            return View();
        }
        public ActionResult EditTopic(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            List<Course> co = db.Course.ToList();

            // Tạo SelectList
            SelectList courseList = new SelectList(co, "CourseID", "CourseID");

            // Set vào ViewBag
            ViewBag.CourseList = courseList;

            List<User_Account> us = db.User_Account.Where(a => a.Position == "trainer").ToList();

            // Tạo SelectList
            SelectList userTrainerList = new SelectList(us, "UserID", "UserID");

            // Set vào ViewBag
            ViewBag.userTrainerList = userTrainerList;

            var to = db.Topic.FirstOrDefault(x => x.TopicID == id);
            return View(to);
        }
        [HttpPost]
        public ActionResult EditTopic(Topic to)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            Topic topic = new Topic();
            topic.TopicID = to.TopicID;
            topic.Topic_Name = to.Topic_Name;
            topic.Description = to.Description;
            topic.CourseID = to.CourseID;
            topic.UserID = to.UserID;
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("TopicMana", "StaffPage");
        }

        public ActionResult DeleteTopic(string id)
        {
            Delete_Topic(id);
            return RedirectToAction("TopicMana", "StaffPage");
        }
        [HttpPost]
        private void Delete_Topic(string id)
        {
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var co = db.Topic.FirstOrDefault(x => x.CourseID == id);
            db.Topic.Remove(co);
            db.SaveChanges();
        }


        //check value exits 
        public JsonResult CheckValueTrainee(string check)
        {
            System.Threading.Thread.Sleep(200);
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var searchID = db.User_Account.Where(x => x.UserID == check).SingleOrDefault();
            if (searchID != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public JsonResult CheckNameTrainee(string username)
        {
            System.Threading.Thread.Sleep(500);
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var searchName = db.User_Account.Where(x => x.UserName == username).SingleOrDefault();
            if (searchName != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
        //Check category
        public JsonResult CheckValueCate(string check)
        {
            System.Threading.Thread.Sleep(200);
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var searchID = db.Category_Course.Where(x => x.CategoryID == check).SingleOrDefault();
            if (searchID != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public JsonResult CheckNameCate(string username)
        {
            System.Threading.Thread.Sleep(500);
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var searchName = db.Category_Course.Where(x => x.Category_Name == username).SingleOrDefault();
            if (searchName != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        //Check value profile
        public JsonResult CheckProId(string check)
        {
            System.Threading.Thread.Sleep(500);
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var searchID = db.Profile_User.Where(x => x.UserID == check).SingleOrDefault();
            if (searchID != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }

        public JsonResult CheckPhone(string phone)
        {
            System.Threading.Thread.Sleep(500);
            QLDaiHocEntities1 db = new QLDaiHocEntities1();
            var searchPhone = db.Profile_User.Where(x => x.Phone == phone).SingleOrDefault();
            if (searchPhone != null )
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
    }
}