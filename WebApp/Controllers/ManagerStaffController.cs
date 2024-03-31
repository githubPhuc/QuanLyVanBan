using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ToolsApp.Authentication;
using ToolsApp.EntityFramework;
using ToolsApp.Models;
using ToolsApp.Utilities;

namespace ToolsApp.Controllers
{
    [Authorize]
    [CustomAuthorize(Function = "ManagerStaff/Index")]
    public class ManagerStaffController : BaseController
    {
        QuanLiVanBanEntities db_ = new QuanLiVanBanEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _Image_View(string Id)
        {
            ViewData["Id"] = Id;
            return PartialView();
        }
        public ActionResult _GetList(string UsernameSearch, string AccountType, string FullnameSearch)
        {
            UsernameSearch = UsernameSearch?.Trim();
            FullnameSearch = FullnameSearch?.Trim();
            var list = db_.Users.Where(a =>
                            (string.IsNullOrEmpty(UsernameSearch) || a.UserName.ToUpper().Contains(UsernameSearch.ToUpper())) &&
                            (string.IsNullOrEmpty(AccountType) || a.AccoutType.ToUpper().Contains(AccountType.ToUpper())) &&
                            (string.IsNullOrEmpty(FullnameSearch) || (a.HoNV +" "+ a.TenNV).ToUpper().Contains(FullnameSearch.ToUpper()))
                        ).ToList();
            ViewBag.list = list;
            var dataUser = db_.Users.Where(a => a.UserName == User.UserName).FirstOrDefault();
            ViewBag.dataUser = dataUser;
            return PartialView();
        }
        public ActionResult _Insert_View()
        {
          
            return PartialView();
        }
        public ActionResult _Update_View(int Id)
        {

            var data = db_.Users.FirstOrDefault(p => p.Id == Id);
            ViewBag.model = data;
            return PartialView();
        }
        public ActionResult ChangePassword(int Id)
        {

            var user = db_.Users.FirstOrDefault(p => p.Id == Id);
            ViewBag.user = user;
            return PartialView();
        }
        #region Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Register(RegisterViewModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.HoNV) && string.IsNullOrEmpty(model.TenNV))
                {
                    return Json(new { status = -1, title = "", text = "Chưa nhập Họ và tên.", obj = "" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (string.IsNullOrEmpty(model.UserName))
                    {
                        return Json(new { status = -1, title = "", text = "Vui lòng nhập Username", obj = "" }, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        if (string.IsNullOrEmpty(model.PasswordHash))
                        {
                            return Json(new { status = -1, title = "", text = "Vui lòng nhập Password", obj = "" }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            if (string.IsNullOrEmpty(model.Email))
                            {
                                return Json(new { status = -1, title = "", text = "Vui lòng nhập Email", obj = "" }, JsonRequestBehavior.AllowGet);

                            }
                            if (string.IsNullOrEmpty(model.AccoutType))
                            {
                                return Json(new { status = -1, title = "", text = "Vui lòng chọn AccoutType", obj = "" }, JsonRequestBehavior.AllowGet);
                            }
                            var pass = ToolsApp.Utilities.UtilsLocal.mahoaS(model.PasswordHash);
                            var dataUser =await db_.Users.Where(a=>a.UserName==model.UserName).FirstOrDefaultAsync();
                            if(dataUser != null)
                            {
                                return Json(new { status = -1, title = "", text = "Vui lòng chọn AccoutType", obj = "" }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var data = new User()
                                {
                                    UserName = model.UserName,
                                    AccoutType = model.AccoutType,
                                    CCCD = model.CCCD,
                                    ChucDanh = model.ChucDanh,
                                    DanToc = model.DanToc,
                                    DiaChiTamTru = model.DiaChiTamTru,
                                    DiaChiThuongTru = model.DiaChiThuongTru,
                                    SoDienThoai = model.SoDienThoai,
                                    MaSoBHXH = model.MaSoBHXH,
                                    Email = model.Email,
                                    GhiChu = model.GhiChu,
                                    GioiTinh = model.GioiTinh,
                                    HieuLuc = true,
                                    HoNV = model.HoNV,
                                    TenNV = model.TenNV,
                                    NganhHoc = model.NganhHoc,
                                    NgaySinh = model.NgaySinh,
                                    NgayCap = model.NgayCap,
                                    NoiCap = model.NoiCap,
                                    NgayVaoLam = model.NgayVaoLam,
                                    NoiDaoTao = model.NoiDaoTao,
                                    PasswordHash = pass,
                                    PhongBan = model.PhongBan,
                                    NgayVaoDangChinhThuc = model.NgayVaoDangChinhThuc
                                };
                                db_.Users.Add(data); 
                                await db_.SaveChangesAsync();
                                return Json(new { status = 1, title = "", text = "Tạo tài khoản thành công", obj = "" }, JsonRequestBehavior.AllowGet);
                            }


                        }
                    }
                }


                return Json(new { status = -1, title = "", text = "Lỗi: Không cấu trúc api", obj = "" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, title = "", text = "Lỗi: Không cấu trúc api", obj = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
       

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult EditUser(RegisterViewModel model, int Id)
        {
            var item = db_.Users.FirstOrDefault(p => p.Id == Id);

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(model.HoNV)&& string.IsNullOrEmpty(model.TenNV))
                    {
                        return Json(new { status = -1, title = "", text = "Chưa nhập Họ và tên.", obj = "" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(model.Email.Trim()))
                        {
                            return Json(new { status = -1, title = "", text = "Email không được để trống.", obj = "" }, JsonRequestBehavior.AllowGet);

                        }

                    }
                    item.HoNV = model.HoNV;
                    item.TenNV = model.TenNV;
                    item.UserName = model.UserName;
                    item.Email = model.Email;
                   // item.PasswordHash = model.PasswordHash;
                    item.SoDienThoai = model.SoDienThoai;
                    item.AccoutType = "User";
                    db_.Entry(item).State = EntityState.Modified;
                    db_.SaveChanges();
                    return Json(new { status = 1, title = "", text = "Cập nhật thành công.", obj = "" }, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> SaveNewPassword(string Username, string newPass)
        {
            try
            {
                //// Phân tích chuỗi JSON thành danh sách đối tượng


                //using (HttpClient client = new HttpClient())
                //{
                //    var data = new { Username = Username, newPass = newPass };
                //    string token = User.token;
                //    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                //    // Gửi GET request tới API
                //    HttpResponseMessage response = await client.PostAsJsonAsync($"https://api.hoanglongsecurity.info/api/Authenticate/ChangePassword?Username={data.Username}&newPass={data.newPass}", data);
                //    HttpStatusCode statusCode = response.StatusCode;
                //    string responseData = await response.Content.ReadAsStringAsync();
                //    dynamic json = JsonConvert.DeserializeObject<dynamic>(responseData);
                //    ResponseObject responseObject = JsonConvert.DeserializeObject<ResponseObject>(responseData);
                //    if (response.StatusCode.ToString() == "200" || response.ReasonPhrase == "OK")
                //    {
                        return Json(new { status = 1, title = "", text = "", obj = "" }, JsonRequestBehavior.AllowGet);


                //    }
                //    else
                //    {
                //        return Json(new { status = -1, title = "", text = responseObject.message, obj = "" }, JsonRequestBehavior.AllowGet);
                //    }
                //}
            }
            catch (Exception ex)
            {
                return Json(new { status = -1, title = "", text = "Lỗi: Không cấu trúc api", obj = "" }, JsonRequestBehavior.AllowGet);
            }


        }

    }

}

 