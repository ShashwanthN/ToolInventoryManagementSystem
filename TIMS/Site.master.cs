using System;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Username"] != null)
        {
            SetMainMenuVisibility(true);
        }
        else
        {
            SetMainMenuVisibility(false);
        }
    }

    private void SetMainMenuVisibility(bool isVisible)
    {
        LoginView loginView = (LoginView)FindControl("HeadLoginView");
        if (loginView != null)
        {
            Menu mainMenu = (Menu)loginView.FindControl("MainMenu");
            if (mainMenu != null)
            {
                mainMenu.Visible = isVisible;
            }
        }
    }

    protected void HeadLoginView_ViewChanged(object sender, EventArgs e)
    {
        
    }
    protected void redirecttobalance(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/BalanceSpares.aspx");

    }
    protected void redirecttoissue(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/IssueOfSpares.aspx");

    }
    protected void redirecttospares(object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/NewSpares.aspx");

    }

}
