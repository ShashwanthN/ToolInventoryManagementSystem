using System;
using System.Web;
using System.Web.Security;

public partial class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
            if (!Request.IsAuthenticated && !Request.Url.AbsolutePath.EndsWith("Login.aspx"))
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }
        
        
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            
        }

        protected void Session_End(object sender, EventArgs e)
        {
            
            
        }

        protected void Application_End(object sender, EventArgs e)
        {
            
        }
    }

