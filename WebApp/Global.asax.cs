using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Http;
using Newtonsoft.Json;
using ToolsApp.App_Start;
using ToolsApp.Authentication;
using ToolsApp.Utilities;

namespace ToolsApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {

            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.RegisterMappings();
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            #region Check BE
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName + Parameters.CookieName.Cookie_Name];
            if (authCookie != null)
            {
                if (authCookie.Value.Length > 0)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                    try
                    {
                        CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                        if (serializeModel!=null)
                        {
                            CustomPrincipal newUser = new CustomPrincipal(serializeModel.UserName);
                            newUser.UserId = serializeModel.UserId;
                            newUser.UserName = serializeModel.UserName;
                            newUser.FullName = serializeModel.HoNV+" "+serializeModel.TenNV;
                            newUser.Email = serializeModel.Email;
                            HttpContext.Current.User = newUser;
                        }                        
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            #endregion            
        }
    }
}