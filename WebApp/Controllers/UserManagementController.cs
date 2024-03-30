using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolsApp.App_Start;
using ToolsApp.Authentication;
using ToolsApp.EntityFramework;
using ToolsApp.Models;
using ToolsApp.Utilities;

namespace ToolsApp.Areas.Admin.Controllers
{
    [Authorize]
    [CustomAuthorize(Function = "UserManagement/Index")]
    public class UserManagementController : BaseController
    {
        QuanLyVanBanEntities db_ = new QuanLyVanBanEntities();


        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _GetList(string UsernameSearch, string EmailSearch)
        {
            UsernameSearch = UsernameSearch?.Trim();
            EmailSearch = EmailSearch?.Trim();
            var List = db_.Users.Where(p =>
            (UsernameSearch == "" || UsernameSearch == null || p.UserName.ToUpper().Contains(UsernameSearch.ToUpper())) &&
            (EmailSearch == "" || EmailSearch == null || p.Email.ToUpper().Contains(EmailSearch.ToUpper()))  && p.AccoutType == "Admin").ToList();
            var lst = List.Select(p => p.UserName).ToList();
            ViewBag.List = List;
            return PartialView(new UserViewModel());
        }
        public ActionResult _Insert(int Id)
        {
            var users = db_.Users.Select(p => p.UserName).ToList();
            #region Load user from DKSH db
            var allUsers = db_.Users.Where(p => p.HieuLuc == true &&
                !users.Contains(p.UserName)
            ).ToList();
            #endregion

            ViewBag.allUsers = allUsers;


            #region Load page
            var pages = db_.Pages.ToList();
            ViewBag.pages = pages;
            #endregion            

            return PartialView(new UserViewModel { Id = 0 });
        }
        public ActionResult _Edit(int Id)
        {
            var model = db_.Users.FirstOrDefault(p => p.Id == Id);
            #region Load page
            var pages = db_.Pages.ToList();
            ViewBag.pages = pages;
            #endregion                                    

            return PartialView(model);
        }
        //Edit role
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _EditFun(QL_UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = db_.Users.FirstOrDefault(p => p.Id == model.Id);
                    if (item == null)
                    {
                        return Json(new { status = -1, title = "", text = "User không tồn tại!!.", obj = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        #region Page
                        var Lst = db_.User_Page.Where(a => a.userId == model.Id).ToList();

                        if (model.Pages == null)
                        {
                            db_.User_Page.RemoveRange(Lst);
                            db_.Entry(item).State = EntityState.Modified;
                            db_.SaveChanges();
                            return Json(new { status = 1, title = "", text = "Cập nhật thành công.", obj = "" }, JsonRequestBehavior.AllowGet);
                        }
                        if (model.Pages != null && model.Pages.Length > 0)
                        {
                            if (Lst != null && Lst.Count() > 0)
                            {
                                foreach (var data in Lst)
                                {
                                    db_.User_Page.Remove(data);
                                }
                            }
                            db_.SaveChanges();
                            #endregion
                            var Pages = model.Pages.Split(',');
                            foreach (var item_ in Pages)
                            {
                                var data = new User_Page
                                {
                                    userId = model.Id,
                                    PageId = int.Parse(item_),
                                    DatetimeCreate = DateTime.Now,
                                    UserCreate = User.UserId,
                                    DatetimeUpdate = DateTime.Now,
                                    UserUpdate = User.UserId,
                                };
                                item.User_Page.Add(data);
                            }
                            db_.Entry(item).State = EntityState.Modified;
                            db_.SaveChanges();
                            return Json(new { status = 1, title = "", text = "Cập nhật thành công.", obj = "" }, JsonRequestBehavior.AllowGet);
                        }
                        return Json(new { status = -1, title = "", text = "Upload false page is null.", obj = "" }, JsonRequestBehavior.AllowGet);

                    }

                }
                catch (Exception ex)
                {
                    return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return Json(new { status = -1, title = "", text = "Error: " + message, obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _DeleteFun(QL_UserViewModel model)
        {
            try
            {
                var item = db_.Users.FirstOrDefault(p => p.Id == model.Id);
                if (item == null)
                {
                    return Json(new { status = -1, title = "", text = "User không tồn tại!!.", obj = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var Lst = db_.User_Page.Where(a => a.userId == model.Id).ToList();

                    if (Lst.Count() == 0)
                    {
                        return Json(new { status = -1, title = "", text = "Người dùng này chưa được phân quyền.", obj = "" }, JsonRequestBehavior.AllowGet);
                    }
                    if (Lst.Count() > 0)
                    {
                        foreach (var data in Lst)
                        {
                            db_.User_Page.Remove(data);
                        }
                    }
                    db_.SaveChanges();
                    return Json(new { status = 1, title = "", text = "Xóa quyền thành công.", obj = "" }, JsonRequestBehavior.AllowGet);
                }
            }   
            catch (Exception ex)
            {
                return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
