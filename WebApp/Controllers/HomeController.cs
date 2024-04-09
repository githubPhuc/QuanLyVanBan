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
            var data = db_.sp_thongkeChart(0,0).ToList();
            return View();
        }
        public ActionResult getChart(int month = 0, int year = 2024)
        {
            var data = db_.sp_thongkeChart(0, DateTime.Now.Year).ToList();
            ViewBag.data = data;
            List<int> dataSoVBDi = new List<int>();
            List<int> dataSoVBDen = new List<int>();
            foreach (var item in data)
            {
                dataSoVBDi.Add(item.SoVanBanDi??0);
                dataSoVBDen.Add(item.SoVanBanDen??0);
            }
            ViewBag.dataSoVBDi = dataSoVBDi;
            ViewBag.dataSoVBDen = dataSoVBDen;
            return PartialView();
        }
        public ActionResult getTable(int month=0,int year = 2024)
        {
            var data = db_.sp_thongke(month, year).ToList();
            ViewBag.data = data;
            return PartialView();
        }
        public ActionResult getList(string stringInput)
        {
            string[] stringArray = stringInput.Split(',');
            List<int> intList = new List<int>();
            foreach (string numStr in stringArray)
            {
                int numInt;
                if (int.TryParse(numStr, out numInt))
                {
                    intList.Add(numInt);
                }
            }
            var data = db_.thongtinvanbans.Where(a => intList.Contains(a.Id)).ToList();
            ViewBag.data = data;
            return PartialView();
        }

    }
}