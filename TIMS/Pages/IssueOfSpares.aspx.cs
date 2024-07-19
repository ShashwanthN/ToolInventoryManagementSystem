using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Pages_IssueOfSpares : System.Web.UI.Page
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
    string query = "SELECT NomenclatureID, NomenclatureName FROM Nomenclature";

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Nomenclature.DataSource = reader;
                Nomenclature.DataTextField = "NomenclatureName";
                Nomenclature.DataValueField = "NomenclatureID";
                Nomenclature.DataBind();
                
            }
        }
    }
}

    

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string nomenclatureID = Nomenclature.SelectedValue;
        int quantity = int.Parse(Quantity.Text);
        string issueType = IssueType.SelectedValue;
        string purpose = Purpose.Text;
        string issueTo = IssueTo.Text;
        string issueDate = IssueDate.Text;

        int availableQuantity = GetAvailableQuantity(nomenclatureID);

        if (quantity <= 0 || quantity > availableQuantity)
        {
            errorMessage.Text = "Invalid quantity. Please enter a value between 0 and " + availableQuantity;
            errorMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    BEGIN TRANSACTION;
                    INSERT INTO IssueOfSpares (NomenclatureID, Quantity, IssueType, Purpose, IssueTo, IssueDate) 
                    VALUES (@NomenclatureID, @Quantity, @IssueType, @Purpose, @IssueTo, @IssueDate);
                    UPDATE SpareParts SET Quantity = Quantity - @Quantity WHERE NomenclatureID = @NomenclatureID;
                    COMMIT;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@NomenclatureID", nomenclatureID);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@IssueType", issueType);
                    cmd.Parameters.AddWithValue("@Purpose", purpose);
                    cmd.Parameters.AddWithValue("@IssueTo", issueTo);
                    cmd.Parameters.AddWithValue("@IssueDate", issueDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rowsAffected > 0)
                    {
                        errorMessage.Text = "Issue of spares entry successfully saved!";
                        errorMessage.ForeColor = System.Drawing.Color.Green;
                        Nomenclature_SelectedIndexChanged(sender, e);
                    }
                    else
                    {
                        errorMessage.Text = "Error occurred while saving the entry.";
                        errorMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errorMessage.Text = "Error: " + ex.Message;
            errorMessage.ForeColor = System.Drawing.Color.Red;
        }
    }

    private int GetAvailableQuantity(string nomenclatureID) 
    {
        string connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
        string query = @"
            SELECT ISNULL(SUM(SP.Quantity), 0) AS AvailableQuantity
            FROM SpareParts SP
            WHERE SP.NomenclatureID = @NomenclatureID";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NomenclatureID", nomenclatureID);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }

    protected void Nomenclature_SelectedIndexChanged(object sender, EventArgs e)
    {
        string nomenclatureID = Nomenclature.SelectedValue;
        int availableQuantity = GetAvailableQuantity(nomenclatureID);
        Label1.Text = "Available: " + availableQuantity;
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      
    }
}
