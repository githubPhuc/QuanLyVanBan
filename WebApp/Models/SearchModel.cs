using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolsApp.Models
{
    public class SearchHoSoNhanVienModel
    {
        public string EmpCodeSearch { get; set; }
        public Nullable<System.Guid> GuidNhanVienIdSearch { get; set; }
        public string SAPNoSearch { get; set; }
        public string HoTenSearch { get; set; }
        public string SoDienThoaiSearch { get; set; }
        public string CMNDSearch { get; set; }
        public string MaTinhThanhSearch { get; set; }
        public string MaQuanHuyenSearch { get; set; }
        public string MaPhuongXaSearch { get; set; }
        public string TheBHYTeSearch { get; set; }
        public int? page { get; set; }
    }
    public class SearchDMLoaiSP
    {
        public string LOAISP { get; set;}
        public string TENLOAI { get; set; }
    }
    public class SearchThanhPhapNoiDia
    {
        public string MAHANG { get; set; }
        public string MATHANHPHAN { get; set; }
    }
    public class SearchDMLoaiTieuThuc
    {
        public string MALOAI_TT { get; set; }
        public string TENLOAI { get; set; }
    }
    public class SearchDMTieuThuc
    {
        public string MATT { get; set; }
        public string TENTT { get; set; }
    }
    public class SearchDVT
    {
        public string MADVT { get; set; }
        public string TENDVT { get; set; }
    }
    public class SearchDMChatLuong
    {
        public string MACHATLUONG { get; set; }
        public string TENCHATLUONG { get; set; }
    }
    public class SearchDMLOI
    {
        public string MANHOMLOI { get; set; }
        public string TENNHOMLOI { get; set; }
    }
    public class SearchDMMayKiem
    {
        public string MAMAYKIEM { get; set; }
        public string TENMAYKIEM { get; set; }
    }
    public class SearchDMLoaiVai
    {
        public string MALOAIVAI { get; set; }
        public string TENLOAIVAI { get; set; }
    }
    public class SearchDMTrangPhuc
    {
        public string MATRANGPHUC { get; set; }
        public string TENTRANGPHUC { get; set; }
    }
    public class SearchDMMaHang
    {
        public string MAMH { get; set; }
        public string TENMH { get; set; }
    }
    public class SearchDMNguonGoc
    {
        public string MANG { get; set; }
        public string TENNG { get; set; }
    }
    public class SearchDMTieuChuan
    {
        public string MATIEUCHUAN { get; set; }
    }
    public class SearchDMloaiThanhPhan
    {
        public string MATHANHPHAN { get; set; }
        public string TENTHANHPHAN { get; set; }
    }
    public class SearchDMDOBENMAU
    {
        public string MADOBEN { get; set; }
        public string TENGOI { get; set; }
    }
    public class SearchDMHDSD
    {
        public string MAHUONGDAN { get; set; }

    }
    public class SearchDMPHIENMAHANGXULY
    {
        public string MAMHGOC { get; set; }
        public string MAMHPHIEN { get; set; }
    }
    public class SearchDMcongnghe
    {
        public string MACONGNGHE { get; set; }
        public string TENCONGNGHE { get; set; }
    }
    public class SearchDMNguoncungcap
    {
        public string MANGUONCUNGCAP { get; set; }
        public string TENNGUONCUNGCAP { get; set; }
    }
    public class SearchDMTrangPhucTheoNhomHang
    {
        public string NHOMHANG { get; set; }
        public string MATRANGPHUC { get; set; }
        public string MANGUONCUNGCAP { get; set; }
        public string MACONGNGHE { get; set; }
    }
    public class SearchDMGiayBe
    {
        public string MAUGIAYBE { get; set; }
    }
    public class SearchDMDanhGiaXK
    {
        public int MATS { get; set; }
        public string MALOAIVAI { get; set; }
        public string MACHATLUONG { get; set; }
    }
    public class SearchDMKho
    {
       
        public string MAKHO { get; set; }
        public string TENKHO { get; set; }
    }
    public class SearcKHACHHANG
    {
        public string MAKH { get; set; }
        public string TENKH { get; set; }
    }
    public class SearcDMPTMH
    {
        public string MAPT { get; set; }
        public string TENPT { get; set; }
    }
    public class SearcDMNHOMPT
    {
        public string MAPT { get; set; }
        public string IDMADV { get; set; }
    }
    public class SearcDMNVKIEMHANG
    {
        public string MANV { get; set; }
        public string HOTEN { get; set; }
    }
    public class SearcDMTrucVaiThanhPham
    {
        public string MATRUC { get; set; }
        public string DAUCAY { get; set; }
    }
    public class SearchBienBanKiemVaiThanhPham
    {
        public string ngayStart { get; set; }
        public string ngayEnd { get; set; }
        public DateTime tuNgay { get; set; }
        public DateTime denNgay { get; set; }
    }
    public class Themthanhpham_
    {
        public string MATRUC { get; set; }
      
    }
}