using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToolsApp.App_Start
{
    public class clsFuntion
    {
        public string fID_Cookies()
        {
            HttpCookie cookie;
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            if (context.Request.Cookies["InNhanID"] != null)
            {
                return context.Request.Cookies["InNhanID"].Value;
            }
            else
            {
                Guid tempCartId = Guid.NewGuid();
                cookie = new HttpCookie("InNhanID", tempCartId.ToString());
                cookie.Expires = DateTime.Now.AddDays(2);
                context.Response.Cookies.Add(cookie);
                return tempCartId.ToString();
            }
        }
    }
}