using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using multiUser.Models;

namespace multiUser.Controllers
{
    public class UserRegController : Controller
    {
        // GET: UserReg

        MVC_New_DBEntities dbobj = new MVC_New_DBEntities();
        public ActionResult Insertuser_Pageload()
        {
            return View();
        }

        public ActionResult Insertuser_click(UserInsert clsobj,HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {

                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Photos", fname);
                    clsobj.photo = fullpath;


                }

                var getmaxid = dbobj.sp_MaxIdlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                //get
                dbobj.sp_userReg(regid, clsobj.name, clsobj.age, clsobj.address, clsobj.email,clsobj.photo);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "successfully inserted....";
                return View("Insertuser_Pageload", clsobj);
            }
            return View("Insertuser_Pageload", clsobj);
        }
    }
}