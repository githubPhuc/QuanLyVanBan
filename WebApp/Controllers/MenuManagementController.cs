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
    [CustomAuthorize(Function = "MenuManagement/Index")]
    public class MenuManagementController : BaseController
    {
        QuanLyVanBanEntities db_ = new QuanLyVanBanEntities();
        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _GetList(string MenuNameSearch)
        {
            MenuNameSearch = MenuNameSearch?.Trim();
            var List = db_.Menus.Where(p =>
            (MenuNameSearch == "" || MenuNameSearch == null || p.MenuName.ToUpper().Contains(MenuNameSearch.ToUpper())) &&
            p.Id == p.Id && p.isDelete == false).ToList();
            ViewBag.List = List;
            return PartialView(new QLKTPMenuViewModel() );
        }
        public ActionResult _Insert(int Id)
        {
            ViewBag.Roots = db_.Menus.Where(p => p.ParentId == null && (p.isDelete == null || p.isDelete == false)).ToList();

            ViewBag.Pages = db_.Pages.Where(p => p.isDelete == false).ToList();

            return PartialView(new QLKTPMenuViewModel { Id = 0 });
        }
        public ActionResult _Edit(int Id)
        {
            var model = db_.Menus.FirstOrDefault(p => p.Id == Id);

            ViewBag.Roots = db_.Menus.Where(p => p.ParentId == null).ToList();

            ViewBag.Pages = db_.Pages.ToList();

            return PartialView(Mapper.MapFrom(model));
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _InsertFun(QLKTPMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    if (model.Icon == "" || model.Icon == null)
                    {
                        return Json(new { status = -1, title = "", text = "Vui lòng nhập icon", obj = "" }, JsonRequestBehavior.AllowGet);

                    }
                    var model_copy = Mapper.MapFrom(model);
                    model_copy.DatetimeCreate = DateTime.Now;
                    model_copy.UserCreate = User.UserId;

                    model_copy.DatetimeUpdate = DateTime.Now;
                    model_copy.UserUpdate = User.UserId;
                    model_copy.isDelete = false;
                        
                    #region Xử lý parent
                    model_copy.ParentId = (model.ParentId == 0 ? null : model.ParentId);
                    model_copy.PageId = (model.PageId == 0 ? null : model.PageId);
                    #endregion

                    db_.Menus.Add(model_copy);
                    db_.SaveChanges();

                    return Json(new { status = 1, title = "", text = "Created.", obj = "" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = -1, title = "", text = "Error: " + UtilsLocal.ModelStateError(ModelState), obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _EditFun(QLKTPMenuViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var item = db_.Menus.FirstOrDefault(p => p.Id == model.Id);
                    item.MenuName = model.MenuName;
                    item.Icon = model.Icon;
                    item.OrderNo = model.OrderNo;
                    item.DatetimeUpdate = DateTime.Now;
                    item.UserUpdate = User.UserId;

                    #region Xử lý parent
                    item.ParentId = (model.ParentId == 0 ? null : model.ParentId);
                    item.PageId = (model.PageId == 0 ? null : model.PageId);
                    #endregion
                    db_.Entry(item).State = EntityState.Modified;
                    db_.SaveChanges();
                    return Json(new { status = 1, title = "", text = "Updated.", obj = "" }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { status = -1, title = "", text = "Error: " + UtilsLocal.ModelStateError(ModelState), obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult _DeleteFun(int Id)
        {
            try
            {
                var item = db_.Menus.FirstOrDefault(p => p.Id == Id);
                item.isDelete = true;
                item.DatetimeDelete = DateTime.Now;
                item.UserDelete = User.UserId;
                db_.Entry(item).State = EntityState.Modified;
                db_.SaveChanges();
                return Json(new { status = 1, title = "", text = "Xóa thành công.", obj = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, title = "", text = ex.Message, obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}