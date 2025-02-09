using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using multiUser.Models;
namespace multiUser.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        MVC_New_DBEntities dbobj = new MVC_New_DBEntities();
        public ActionResult Login_pageload()
        {
            return View();
        }


        public ActionResult UserHome()
        {
            return View();
        }


        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult Login_click(Logincls objcls)
        {
            if (ModelState.IsValid)
            {
                var val = dbobj.sp_loginCountId(objcls.Uname, objcls.password).Single();
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(objcls.Uname, objcls.password).FirstOrDefault();
                    Session["uid"] = uid;

                    var lt = dbobj.sp_loginType(objcls.Uname, objcls.password).FirstOrDefault();
                    if (lt == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if(lt == "admin")
                    {
                        return RedirectToAction("AdminHome");
                    }
                }
            }
            else
            {
                ModelState.Clear();
                objcls.msg = "Invalid login";
                return View("Login_pageload",objcls);
            }

            return View("Login_pageload", objcls);
        }
    }
}