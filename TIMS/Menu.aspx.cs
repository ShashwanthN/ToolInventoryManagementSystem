using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RedirectToIssueOfSpares(Object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/IssueOfSpares.aspx");
    }

    protected void RedirectToBalance(Object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/BalanceSpares.aspx");

    }
    protected void RedirectToNewSpares(Object sender, EventArgs e)
    {
        Response.Redirect("~/Pages/NewSpares.aspx");
    }


}