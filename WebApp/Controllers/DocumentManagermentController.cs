using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolsApp.Authentication;
using ToolsApp.EntityFramework;
using ToolsApp.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Aspose.Words;
using System.Data.Entity;
namespace ToolsApp.Controllers
{
    [Authorize]
    [CustomAuthorize(Function = "DocumentManagerment/Index")]
    public class DocumentManagermentController : BaseController
    {
        QuanLiVanBanEntities db_ = new QuanLiVanBanEntities();
        public ActionResult Index()
        {
            var loaiVanBans = db_.loaivanbans.ToList();
            var vanbandichuyens = db_.VanBanDiChuyens.ToList();
            var phongBans = db_.DanhSachPhongbans.ToList();
            ViewBag.loaiVanBans = loaiVanBans;
            ViewBag.vanbandichuyens = vanbandichuyens;
            ViewBag.phongBans = phongBans;
            return View();
        }
        public ActionResult GetList(string IdPhongBanSearch, string IdLoaiVanBanSearch)
        {
            var list = db_.thongtinvanbans.Where(a =>
                  (IdPhongBanSearch == "" || IdPhongBanSearch == null || a.IdPhongBan.ToString().Contains(IdPhongBanSearch)) &&
                  (IdLoaiVanBanSearch == "" || IdLoaiVanBanSearch == null || a.idLoaiVanBan.ToString().Contains(IdLoaiVanBanSearch))&&a.isDelete== false).ToList();
            ViewBag.list = list;
            return PartialView();
        }
        public ActionResult _Insert()
        {
            var loaiVanBans = db_.loaivanbans.ToList();
            var vanbandichuyens = db_.VanBanDiChuyens.ToList();
            var phongBans = db_.DanhSachPhongbans.ToList();
            ViewBag.loaiVanBans = loaiVanBans;
            ViewBag.vanbandichuyens = vanbandichuyens;
            ViewBag.phongBans = phongBans;
            return PartialView();
        }
        public ActionResult _Edit(int Id)
        {
            var loaiVanBans = db_.loaivanbans.ToList();
            var vanbandichuyens = db_.VanBanDiChuyens.ToList();
            var phongBans = db_.DanhSachPhongbans.ToList();
            var vanBans = db_.thongtinvanbans.FirstOrDefault(a=>a.Id == Id);
            ViewBag.vanBans = vanBans;
            ViewBag.loaiVanBans = loaiVanBans;
            ViewBag.vanbandichuyens = vanbandichuyens;
            ViewBag.phongBans = phongBans;

            return PartialView();
        }
        public ActionResult ViewDocument(string fileName)
        {
            string uploadsFolder = Server.MapPath("~/Uploads");
            string wordFilePath = Path.Combine(uploadsFolder, fileName);
            if (Path.GetExtension(wordFilePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
            {
                string pdfPath = ConvertWordToPdf(wordFilePath);
                return File(pdfPath, "application/pdf");
            }
            else
            {
                return File(wordFilePath, MimeMapping.GetMimeMapping(wordFilePath));
            }
        }

        private string ConvertWordToPdf(string wordFilePath)
        {
            string tempPath = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(wordFilePath));
            Aspose.Words.Document doc = new Aspose.Words.Document(tempPath);
            string pdfPath = Path.ChangeExtension(tempPath, ".pdf");
            doc.Save(pdfPath, Aspose.Words.SaveFormat.Pdf);
            return pdfPath;
        }
        public ActionResult ViewFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string physicalPath = Server.MapPath(filePath);
                if (System.IO.File.Exists(physicalPath))
                {
                    return File(physicalPath, "application/octet-stream", Path.GetFileName(physicalPath));
                }
            }
            return HttpNotFound();
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _InsertFun(ThongTinVanBanModels model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Xử lý tải lên file và lưu vào thư mục
                    var file = Request.Files["TaiLieuDinhKem"];
                    if (file != null && file.ContentLength > 0)
                    {
                        string uploadDir = Server.MapPath("~/Uploads");
                        if (!Directory.Exists(uploadDir))
                        {
                            Directory.CreateDirectory(uploadDir);
                        }
                        string filePath = Path.Combine(uploadDir, Path.GetFileName(file.FileName));
                        file.SaveAs(filePath);
                        model.TaiLieuDinhKem = "/Uploads/" + file.FileName;      

                    }
                    else
                    {
                        if (model.NguonVB == "")
                        {
                            return Json(new { success = false, message = "Vui lòng nhập nguồn văn bản" });
                        }
                        else
                        {
                            if (model.TaiLieuDinhKem == null)
                            {
                                return Json(new { success = false, message = "Vui lòng chọn tài liệu đính kèm" });

                            }

                        }
                    }
                     
                    
                    var item = new thongtinvanban();
                    item.IdPhongBan = model.IdPhongBan;
                    item.idLoaiVanBan = model.idLoaiVanBan;
                    item.IdVanBanDiChuyen = model.IdVanBanDiChuyen;
                    item.NguonVB = model.NguonVB;
                    item.SoVBNoiBo = model.SoVBNoiBo;
                    item.ButPhe = model.ButPhe;
                    item.TaiLieuDinhKem = model.TaiLieuDinhKem;
                    item.NgayPhongBanSoanThao = model.NgayPhongBanSoanThao;
                    item.DatetimeCreate = DateTime.Now;
                    item.isDelete = false;
                    item.UserCreate = User.UserId;
                    db_.thongtinvanbans.Add(item);
                    db_.SaveChanges();
                    return Json(new { success = true, message = "Thêm mới thành công!" });
                }
                catch (Exception ex)
                {

                    return Json(new { success = false, message = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ!" });
            }

        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _UpdateFun(ThongTinVanBanModels model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Xử lý tải lên file và lưu vào thư mục
                    var file = Request.Files["TaiLieuDinhKem"];
                    if (file != null && file.ContentLength > 0)
                    {
                        string uploadDir = Server.MapPath("~/Uploads");
                        if (!Directory.Exists(uploadDir))
                        {
                            Directory.CreateDirectory(uploadDir);
                        }
                        string fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + Guid.NewGuid() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(uploadDir, Path.GetFileName(fileName));

                        file.SaveAs(filePath);
                        model.TaiLieuDinhKem = "/Uploads/" + fileName;      

                    }
                    else
                    {
                        if (model.NguonVB == "")
                        {
                            return Json(new { success = false, message = "Vui lòng nhập nguồn văn bản" });
                        }
                        else
                        {
                            if (model.TaiLieuDinhKem == null)
                            {
                                return Json(new { success = false, message = "Vui lòng chọn tài liệu đính kèm" });

                            }

                        }
                    }


                    var item = db_.thongtinvanbans.FirstOrDefault(x => x.Id == model.Id);
                    if (item != null)
                    {
                        item.IdPhongBan = model.IdPhongBan;
                        item.idLoaiVanBan = model.idLoaiVanBan;
                        item.IdVanBanDiChuyen = model.IdVanBanDiChuyen;
                        item.NguonVB = model.NguonVB;
                        item.SoVBNoiBo = model.SoVBNoiBo;
                        item.ButPhe = model.ButPhe;
                        item.TaiLieuDinhKem = model.TaiLieuDinhKem;
                        item.NgayPhongBanSoanThao = model.NgayPhongBanSoanThao;
                        item.DatetimeUpdate = DateTime.Now;
                        item.UserUpdate = User.UserId;
                        db_.Entry(item).State = EntityState.Modified;
                        db_.SaveChanges();
                        return Json(new { success = true, message = "Cập nhật thành công!" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Cập nhật thất bại!" });

                    }
                }
                catch (Exception ex)
                {

                    return Json(new { success = false, message = ex.Message });
                }
            }
            else
            {
                return Json(new { success = false, message = "Dữ liệu không hợp lệ!" });
            }

        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult _DeleteFun(int Id)
        {
            
                try
                {
                    var item = db_.thongtinvanbans.FirstOrDefault(x => x.Id == Id);
                    if (item != null)
                    {                        
                        item.isDelete = true;
                        db_.Entry(item).State = EntityState.Modified;
                        db_.SaveChanges();
                        return Json(new { success = true, message = "Xóa thành công!" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Xóa thất bại!" });

                    }
                }
                catch (Exception ex)
                {

                    return Json(new { success = false, message = ex.Message });
                }
           

        }
    }
}