using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

public partial class Pages_BalanceSpares : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateNomenclatureDropDown();
        }
    }

    protected void PopulateNomenclatureDropDown()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
        string query = "SELECT DISTINCT NomenclatureName FROM Nomenclature";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    NomenclatureDropDown.DataSource = reader;
                    NomenclatureDropDown.DataTextField = "NomenclatureName";
                    NomenclatureDropDown.DataBind();
                }
            }
        }
    }

    protected void NomenclatureDropDown_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedNomenclature = NomenclatureDropDown.SelectedValue;
        DisplaySparePartDetails(selectedNomenclature);
        BindIssueOfSparesGrid(selectedNomenclature);
    }

    private void DisplaySparePartDetails(string nomenclatureName)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
        string query = @"
            SELECT 
                N.NomenclatureName AS Nomenclature,
                SP.Quantity,
                SP.DateOfEntry,
                SP.RackNo
            FROM 
                Nomenclature N
            LEFT JOIN 
                SpareParts SP ON N.NomenclatureID = SP.NomenclatureID
            WHERE 
                N.NomenclatureName = @NomenclatureName";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NomenclatureName", nomenclatureName);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            NomenclatureLabel.Text = reader["Nomenclature"].ToString();
                            QuantityLabel.Text = reader["Quantity"] != DBNull.Value ? reader["Quantity"].ToString() : "";
                            DateOfEntryLabel.Text = reader["DateOfEntry"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfEntry"]).ToString("yyyy-MM-dd") : "";
                            RackNoLabel.Text = reader["RackNo"] != DBNull.Value ? reader["RackNo"].ToString() : "";
                        }
                        DetailsPanel.Style["display"] = "block";
                    }
                    else
                    {
                        DetailsPanel.Style["display"] = "none";
                    }
                }
            }
        }
    }

    private void BindIssueOfSparesGrid(string nomenclatureName)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
        string query = @"
            SELECT 
                N.NomenclatureName AS Nomenclature,
                ISS.Quantity,
                ISS.IssueType,
                ISS.IssueTo,
                ISS.IssueDate
            FROM 
                Nomenclature N
            LEFT JOIN 
                IssueOfSpares ISS ON N.NomenclatureID = ISS.NomenclatureID
            WHERE 
                N.NomenclatureName = @NomenclatureName";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NomenclatureName", nomenclatureName);

                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.Dat  ource = dt;
                    GridView1.DataBind();
                }
            }
        }
    }
}
