using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Pages_NewSpares : System.Web.UI.Page
{
    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string dateOfEntry = DateOfEntry.Text;
        string nomenclatureName = Nomenclature.Text;
        string rackNo = RackNo.Text;

        int quantity;
        if (!int.TryParse(Quantity.Text, out quantity))
        {
            errorMessage.Text = "Quantity must be a valid integer.";
            errorMessage.ForeColor = System.Drawing.Color.Red;
            return;
        }

        string remarks = Remarks.Text;

        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
              
                string insertNomenclatureQuery = "INSERT INTO Nomenclature (NomenclatureName) VALUES (@NomenclatureName); SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(insertNomenclatureQuery, conn))
                {
                    
                    
                        cmd.Parameters.AddWithValue("@NomenclatureName", nomenclatureName);
                
                        int nomenclatureId = Convert.ToInt32(cmd.ExecuteScalar());
                    
                    

                   
                    string insertSparePartQuery = "INSERT INTO SpareParts (DateOfEntry, NomenclatureID, Quantity, RackNo, Remarks) " +
                                                  "VALUES (@DateOfEntry, @NomenclatureID, @Quantity, @RackNo, @Remarks)";
                    using (SqlCommand cmdInsert = new SqlCommand(insertSparePartQuery, conn))
                    {
                        cmdInsert.Parameters.AddWithValue("@DateOfEntry", dateOfEntry);
                        cmdInsert.Parameters.AddWithValue("@NomenclatureID", nomenclatureId);
                        cmdInsert.Parameters.AddWithValue("@Quantity", quantity);
                        cmdInsert.Parameters.AddWithValue("@RackNo", rackNo);
                        cmdInsert.Parameters.AddWithValue("@Remarks", remarks);

                        int rowsAffected = cmdInsert.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            errorMessage.Text = "Spare part entry successfully saved!";
                            errorMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            errorMessage.Text = "Error occurred while saving the entry.";
                            errorMessage.ForeColor = System.Drawing.Color.Red;
                        }
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
    private int GetAvailableQuantity(string nomenclatureName)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["data"].ConnectionString;
        string query = @"
            SELECT 
               
                SP.Quantity,
                
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
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }
    }

    protected void Nomenclature_SelectedIndexChanged(object sender, EventArgs e)
    {
        string nomenclatureID = Nomenclature.Text;
        int availableQuantity = GetAvailableQuantity(nomenclatureID);
        if (availableQuantity == 0)
        {

        }
    }
    
}
