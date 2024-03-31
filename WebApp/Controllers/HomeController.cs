using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolsApp.App_Start;
using ToolsApp.Authentication;
using ToolsApp.EntityFramework;

namespace ToolsApp.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        QuanLiVanBanEntities db_ = new QuanLiVanBanEntities();
        // GET: Home
        public ActionResult Index(string Id = "")
        {
            int currentYear = DateTime.Now.Year;
            int lowestYear = 2000; // Năm bắt đầu

            List<SelectListItem> years = new List<SelectListItem>();
            for (int year = currentYear; year >= lowestYear; year--)
            {
                years.Add(new SelectListItem { Text = year.ToString(), Value = year.ToString() });
            }
            ViewBag.Years = years;
            var data_SumUser = db_.Users.ToList();
            ViewData["data_SumUser"] = data_SumUser.Where(a => a.AccoutType == "User").ToList().Count();
            ViewData["data_SumAdmin"] = data_SumUser.Where(a => a.AccoutType == "Admin" && a.UserName != "Admin").ToList().Count();
            ViewData["data_SumManager"] = data_SumUser.Where(a => a.AccoutType == "Admin" && a.UserName != "Admin").ToList().Count();
      
            return View();
        }
       
    }
}