using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class LeaveController : Controller
    {

        DB09TMS155_1718Entities db = new DB09TMS155_1718Entities();

        // GET: Leave
        public ActionResult Details()
        {

            //List<sp_view_mvc_Result> lst = new List<sp_view_mvc_Result>();
            //lst=db.sp_view_mvc().ToList();
            List<sp_view_mvc_Result> lst = new List<sp_view_mvc_Result>();
            lst = db.sp_view_mvc().ToList();

            return View(lst);
        }

        public ActionResult Approve_Leave(int lid)
        {

            db.sp_update_leave(lid);

            return RedirectToAction("Details");
        }

        public ActionResult Remove_Leave(int leid)
        {

            db.sp_delete_leave(leid);

            return RedirectToAction("Details");
        }
    
        public ActionResult Viewbystatus(FormCollection form)
        {

            string status = form["txtStatus"];

            List<sp_view_mvc_Result> templst = new List<sp_view_mvc_Result>();
            templst = db.sp_view_mvc().ToList().FindAll(a => a.stat == status);
            return View("Details", templst);

        }
    }
}
