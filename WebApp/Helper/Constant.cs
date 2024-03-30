using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolsApp.Helper
{
    public class Constant
    {
    }
    public class Alert
    {
        public const string SUCCESS_Copy = "Copy thành công.";
        public const string SUCCESS_ADD = "Thêm thành công.";
        public const string SUCCESS_IMPORT_NROW = "Nhập thành công {0} dòng.";
        public const string FAILS_ADD = "Thêm thất bại.";
        public const string RECHECK = "Vui lòng kiểm tra lại.";
        public const string ACCESS_DENIED = "Không được phép truy cập vào mục này! Vui lòng liên hệ IT center.";
        public const string ACCESS_FILE = "Vui lòng chọn file để nhập.";
        public const string FAILS_DELETE_ITEM = "Xóa thất bại. Phiếu này đã được xuất.";
        public const string FAILS_USER_DELETE = "Xóa thất bại. Bạn không phải người tạo phiếu này.";
        public const string FAILS_DELETE = "Xóa thất bại. Đã có dữ liệu liên quan.";
        public const string SUCCESS_DELETE = "Xóa thành công.";
        public const string SUCCESS_DELETE_NROW = "Xóa thành công {0} dòng.";
        public const string CLOSING_DATE = "Đã Khóa Sổ. Vui lòng liên hệ Tài Chính Kế Toán. Ngày chốt tồn {0}.";
        public const string SUCCESS_UPDATED = "Cập nhật thành công.";
        public const string FAILS_UPDATED = "Cập nhật thất bại.";
        public const string EXISTED_OBJECT = "{0} đã tồn tại. " + RECHECK;
        public const string NULL_OBJECT = "{0} không được để trống. " + RECHECK;
        public const string CHECK_FORMULA = "{0} không đúng kiểu dữ liệu.";
        public const string NEGATIVE_NUMBER = "{0} không được nhỏ hơn 0. " + RECHECK;

    }
}