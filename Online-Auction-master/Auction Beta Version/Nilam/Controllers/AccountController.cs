using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dbLayer; //so that I can access it
using System.Data.Entity;

namespace Nilam.Controllers
{
    public class AccountController : Controller
    {
        AuctionEntities ac = new AuctionEntities(); //instance of my database 

        // GET: Account
        public ActionResult Index()
        {
            return View("Index");
        }

        //Create Account

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(userTable u)
        {
            using (ac)
            {
                ac.userTables.Add(u);
                ac.SaveChanges();
                
                return RedirectToAction("Login");
            }
        }

        //Log in
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(userTable u)
        {
            using (ac)
            {
                var usr = ac.userTables.SingleOrDefault(us => us.userName == u.userName && us.passWord == u.passWord);
                if (usr != null)
                {
                    Session["userID"] = usr.userID.ToString();
                    Session["userName"] = usr.userName.ToString();
                    Session["userStatus"] = usr.userStatus.ToString();
                    Session["role"] = usr.role.ToString();
                    return RedirectToAction("LoggedIn");

                }

                    else
                    {
                        ModelState.AddModelError("", "User Name or Password is Wrong");
                    }
            }

            return View();

        }




        public ActionResult LoggedIn()
        {
            if (Session["role"].ToString() == "Admin")
            {
                return View();
            }
            else if (Session["role"].ToString() == "User")
            {
                return View("userView");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        //verification table
        public ActionResult invalidUserList()
        {
            return View(ac.userTables.Where(whichOne => whichOne.userStatus == "invalid" && whichOne.role=="User"));
        }


        //verify User
        public ActionResult verifyUser(int userID = 1)
        {
            return View(ac.userTables.Find(userID));
        }

        [HttpPost]
        public ActionResult verifyUser(userTable verify)
        {
            ac.Entry(verify).State = EntityState.Modified;
            ac.SaveChanges();

            return RedirectToAction("invalidUserList");
        }



        //show profile
        public ActionResult showProfileInformation()
        {
            int userIDFROMsession = Convert.ToInt32(Session["userID"]);
            return View(ac.userTables.Where(whichOne => whichOne.userID == userIDFROMsession));
        }

        //Edit profile
        public ActionResult editProfile(int userID = 1)
        {
            return View(ac.userTables.Find(userID));
        }

        [HttpPost]
        public ActionResult editProfile(userTable editPRO)
        {
            ac.Entry(editPRO).State = EntityState.Modified;
            ac.SaveChanges();

            return RedirectToAction("LoggedIn");
        }




        public ActionResult Logout()
        {
            // Session.clear();
            //Session["userNmae"]==null;

            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login");
        }



    }
}