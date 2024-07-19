using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

public partial class Account_Login : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnClick(Object sender, EventArgs e)
    {
        string user = "admin";
        string password = "admin@123";

        if (user == UserName.Text && password == Password.Text)
        {
            Response.Redirect("~/Menu.aspx");
        }
        {
            errorMessage.Text = "Your username or password is wrong!";
        }
    }
    protected void btnSubmitOnClickDb(Object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["data"].ConnectionString);
        con.Open();
        SqlCommand com = new SqlCommand("select username, password from userData where username=@username and password=@password", con);
        com.Parameters.AddWithValue("@username", UserName.Text);
        com.Parameters.AddWithValue("@password", Password.Text);
        SqlDataAdapter DaAp = new SqlDataAdapter(com);
        DataTable DT = new DataTable();
        DaAp.Fill(DT);
        if (DT.Rows.Count > 0)
        {
            FormsAuthentication.SetAuthCookie(UserName.Text, false);
            Session["Username"] = UserName.Text;
            Response.Redirect("~/Menu.aspx");
        }
        else
        {
            errorMessage.Text = "Your username or password is wrong!";
        }
    }
}