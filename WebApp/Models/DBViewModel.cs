using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToolsApp.EntityFramework;

namespace ToolsApp.Models
{
    public partial class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "ResetCode is required")]
        public string ResetCode { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$", ErrorMessage = "Password must meet requirements")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 8 and 255 characters", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
    public partial class UserJson
    {
        public string username { get; set; }
        public string password { get; set; }
    }
 
    public class ResponseObject
    {
        public string message { get; set; }
        public object data { get; set; }
        public string token { get; set; }
        public DateTime expiration { get; set; }
        public string id { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int idDepartment { get; set; }
    }
    public partial class QL_UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string SalesRepCode { get; set; }
        public string HoNV { get; set; }
        public string TenNV { get; set; }
        public string Email { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public DateTime DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public DateTime DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public DateTime DatetimeDelete { get; set; }
        public string Roles { get; set; }
        public string Pages { get; set; }
        public string Softwares { get; set; }
        public string PrincipalGroups { get; set; }
    }
    public partial class QLKTPPageViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "The field is required.")]
        public int Id { get; set; }
        [Display(Name = "Code")]
        [Required(ErrorMessage = "The field is required.")]
        public string Code { get; set; }
        [Display(Name = "Info")]
        public string Info { get; set; }
        [Display(Name = "Controler")]
        [Required(ErrorMessage = "The field is required.")]
        public string Controler { get; set; }
        [Display(Name = "Action")]
        [Required(ErrorMessage = "The field is required.")]
        public string Action { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public DateTime DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public DateTime DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public DateTime DatetimeDelete { get; set; }
    }
    public partial class QLKTPRoleViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "The field Id is required.")]
        public int Id { get; set; }
        [Display(Name = "Code")]
        [Required(ErrorMessage = "The field Code is required.")]
        public string Code { get; set; }
        [Display(Name = "Role name")]
        [Required(ErrorMessage = "The field RoleName is required.")]
        public string RoleName { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public DateTime DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public DateTime DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public DateTime DatetimeDelete { get; set; }
    }
    public partial class QLKTPMenuViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "The field Id is required.")]
        public int Id { get; set; }
        [Display(Name = "Menu Name")]
        [Required(ErrorMessage = "The field MenuName is required.")]
        public string MenuName { get; set; }
        [Display(Name = "Parent Id")]
        public Nullable<int> ParentId { get; set; }
        [Display(Name = "Page Id")]
        public Nullable<int> PageId { get; set; }
        [Display(Name = "Icon")]
        public string Icon { get; set; }
        [Display(Name = "Order No")]
        [Required(ErrorMessage = "The field OrderNo is required.")]
        public Nullable<int> OrderNo { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public DateTime DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public DateTime DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public DateTime DatetimeDelete { get; set; }
    }
    public partial class QLKTPSoftwareGroupViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "The field Id is required.")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "The field Title is required.")]
        public string Title { get; set; }
        public string Domain { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public DateTime DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public DateTime DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public DateTime DatetimeDelete { get; set; }
        public string ColorCode { get; set; }
    }
    public partial class QLKTPSoftwareViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "The field Id is required.")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "The field Title is required.")]
        public string Title { get; set; }
        public Nullable<int> GroupId { get; set; }
        public string Domain { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public Nullable<int> OrderNo { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public DateTime DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public DateTime DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public DateTime DatetimeDelete { get; set; }
        public string Sites { get; set; }
    }
    public partial class QLKTPUserBlackListViewModel
    {
        public long Id { get; set; }
        public string BlackListUser { get; set; }
        public string BlackListFullname { get; set; }
        public string Email { get; set; }
        public string PrincipalId { get; set; }
        public string PrincipalName { get; set; }
        public string Ticket { get; set; }
        public string Reason { get; set; }
        public string UserCreate { get; set; }
        public string UserFullnameCreate { get; set; }
        public DateTime DatetimeCreate { get; set; }
        public string UserUpdate { get; set; }
        public string UserFullnameUpdate { get; set; }
        public DateTime DatetimeUpdate { get; set; }
        public Nullable<bool> isDelete { get; set; }
        public string UserDelete { get; set; }
        public string UserFullnameDelete { get; set; }
        public DateTime DatetimeDelete { get; set; }
    }
    public partial class SitesViewModel
    {
        [Display(Name = "Site Code")]
        [Required(ErrorMessage = "The field SiteCode is required.")]
        [StringLength(3, ErrorMessage = "Must be between 1 and 3 characters", MinimumLength = 1)]
        public string SiteCode { get; set; }
        [Display(Name = "Site Name")]
        [Required(ErrorMessage = "The field SiteName is required.")]
        public string SiteName { get; set; }
    }
    public partial class TaiKhoanViewModels
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public Nullable<bool> IsHieuLuc { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
        public string NguoiCapNhat { get; set; }
        public DateTime NgayCapNhat { get; set; }
    }
    public partial class Response
    {
        public string Status { get; set; }

        public string Message { get; set; }
    }
  
    public partial class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
    }
    public partial class RegisterViewModel
    {

        public string AccoutType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string SoDienThoai { get; set; }
        public string HoNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string DiaChiTamTru { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public Nullable<int> CCCD { get; set; }
        public DateTime NgayCap { get; set; }
        public string NoiCap { get; set; }
        public string MaSoBHXH { get; set; }
        public string TrinhDoVanHoa { get; set; }
        public string TrinhDoChuyenMon { get; set; }
        public string NganhHoc { get; set; }
        public string NoiDaoTao { get; set; }
        public string TrinhDoChinhTri { get; set; }
        public DateTime NgayVaoDangDuBi { get; set; }
        public DateTime NgayVaoDangChinhThuc { get; set; }
        public string PhongBan { get; set; }
        public string ChucDanh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string GhiChu { get; set; }
    }
    public class QREvent_ViewModel
    {
        public int IdJob { get; set; }
        public int Id { get; set; }
        public string JobName { get; set; }
        public string Messger { get; set; }
        public string path_Qr { get; set; }
        public bool status { get; set; }
        public DateTime time_Create { get; set; }
        public string UsernameCreate { get; set; }
    }

    public class Qr_Patrol_View
    {
        public int Id { get; set; }
        public string code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        public int id_Job { get; set; }
        public int time_Check { get; set; }
    }
    public class QRCodeData
    {
        public int IdJob { get; set; }
        public string QrText { get; set; }
        public string Base64Image { get; set; }
    }
    public class Qr_Event_View
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Messger { get; set; }
        public string path_Qr { get; set; }
        public DateTime time_Create { get; set; }
        public DateTime time_Update { get; set; }
        public DateTime time_Delete { get; set; }
        public string UsernameCreate { get; set; }
        public string UsernameUpdate { get; set; }
        public string UsernameDelete { get; set; }
        public bool status { get; set; }
        public int IdJob { get; set; }
    }
    public class render_Qr
    {
        public string Mess { get; set; }
    }
    public class Location_ViewModel
    {
        public int IdJob { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string street { get; set; }
        public string subAdministrativeArea { get; set; }
        public string administrativeArea { get; set; }
        public string country { get; set; }
        public int JobId { get; set; }
        public bool IsTruSoChinh { get; set; }
        public string nameLocation { get; set; }

    }
    public class Job_ViewModel
    {
        public int Id { get; set; }
        public string NameLocation { get; set; }
        public string subAdministrativeArea { get; set; }
        public string UserCreate { get; set; }
        public bool status { get; set; }
        public DateTime TimeDelete { get; set; }
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        public string administrativeArea { get; set; }
        public string country { get; set; }
        public DateTime TimeCreate { get; set; }
        public string street { get; set; }
        public int idDepartment { get; set; }
        public string UserDelete { get; set; }

    }
    public  class JobDetail_ViewModel
    {
        public int Id { get; set; }
        public int idjob { get; set; }
        public string job_Detail_Name { get; set; }
        public string JobDescription { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string UserCreate { get; set; }
        public string UserUpdate { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
    public  class DepartmentView_Model
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string taxCode { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string country { get; set; }
        public string ward { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string phone { get; set; }
        public bool status { get; set; }
        public string street { get; set; }
    }
    public  class UserJobView_Model
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Id_Detail_Job { get; set; }
    }
    public class AttendanceFaceViewModel
    {
        public int Id { get; set; }
        public string Location_In_X { get; set; }
        public string Location_In_Y { get; set; }
        public string Location_Out_X { get; set; }
        public string Location_Out_Y { get; set; }
        public Nullable<int> Check_Location_In { get; set; }
        public Nullable<int> Check_Location_Out { get; set; }
        public string Time_In { get; set; }
        public string Time_Out { get; set; }
        public string Admin_UserName_Update { get; set; }
        public string Admin_UserName_Confirm { get; set; }
        public string Admin_Messger_Update { get; set; }
        public string Admin_time_Update { get; set; }
        public string TimeConfirm { get; set; }
        public bool isConfirm { get; set; }
        public bool isStatus { get; set; }
        public string Datetime_ { get; set; }
    }  
    public class CheckImage_Model
    {
        
        public string username { get; set; }
        public string[] nameImage { get; set; }
       
    }
    public class JobViewModel
    {
        public string NameLocation { get; set; }
        public string JobDescription { get; set; }
        public string JobAddress { get; set; }
        public string Position { get; set; }
        public string Shift { get; set; }
    }
    public class ProfileUserviewModel
    {
        public string Id { get; set; }
        public string imageName { get; set; }
        public string birtDate { get; set; }
        public string placeOfBirt { get; set; }
        public string placeOfOrigin { get; set; }
        public string curResidence { get; set; }
        public string resident { get; set; }
        public string temResidence { get; set; }
        public string gender { get; set; }
        public string taxCode { get; set; }
        public string marital { get; set; }
        public string ethnicity { get; set; }
        public string religion { get; set; }
        public string nationality { get; set; }
        public string educationalLevel { get; set; }
        public string otherNum { get; set; }
        public string address { get; set; }
        public string zalo { get; set; }
        public string CCCD { get; set; }
        public string imageFrontCCCD { get; set; }
        public string imageBackCCCD { get; set; }
        public string passPortNum { get; set; }
        public string codeBank { get; set; }
        public string numBank { get; set; }
        public string nameAccountBank { get; set; }

    }
    public  class notification_ViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
    }
    public class Salaries_ViewModel
    {
        public string username { get; set; }
        public string Thangnam { get; set; }
        public string idJob { get; set; }
        public decimal LuongCoBanGoc { get; set; }
        public decimal ThamNien { get; set; }
        public decimal xangxe { get; set; }
        public decimal Com { get; set; }
        public decimal DienThoai { get; set; }
        public decimal ChuyenCan { get; set; }
        public decimal HieuQuaCV { get; set; }
        public decimal CongTet { get; set; }
        public decimal HeSoThuong { get; set; }
    
    }
    public class PaymentInfoModel
    {
        public int[] Month { get; set; }
        public decimal[] TotalPayment { get; set; }
    }
    public class BlogModels
    {
        public int idDepartment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UsernameCreate  { get; set; }
        public string Url { get; set; }
        public DateTime dateTime { get; set; }
        public string Image { get; set; }
        public string isShow { get; set; }
        
    }
}   