using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudGridView
{
    public partial class Contact : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGridview();
            }
        }


        void populateGridview()
        {

            string query = "";
            DataTable dt = new DataTable();
        
            using (SqlConnection cnn = new SqlConnection(strcon))
            {

                query = @"SELECT * FROM ContactInfo";
                cnn.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, cnn);
                sda.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                gvContactInfo.DataSource = dt;
                gvContactInfo.DataBind();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvContactInfo.DataSource = dt;
                gvContactInfo.DataBind();
                gvContactInfo.Rows[0].Cells.Clear();
                gvContactInfo.Rows[0].Cells.Add(new TableCell());
                gvContactInfo.Rows[0].Cells[0].ColumnSpan = dt.Columns.Count;
                gvContactInfo.Rows[0].Cells[0].Text = "No data found";
                gvContactInfo.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gvContactInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection cnn = new SqlConnection(strcon))
                    {
                        cnn.Open();
                        string query = "INSERT INTO ContactInfo (FirstName,LastName,ContactNo,Email) VALUES(@FirstName,@LastName,@ContactNo,@Email)";
                        SqlCommand cmd = new SqlCommand(query, cnn);
                        cmd.Parameters.AddWithValue("@FirstName", (gvContactInfo.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", (gvContactInfo.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@ContactNo", (gvContactInfo.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", (gvContactInfo.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        cmd.ExecuteNonQuery();
                        populateGridview();

                        lblSuccesMsg.Text = "New Record Added Successfully..!";
                        lblErrorMsg.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                lblSuccesMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void gvContactInfo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            {
                gvContactInfo.EditIndex = e.NewEditIndex;
                populateGridview();
            }
        }

        protected void gvContactInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcon))
                {
                    cnn.Open();
                    string query = "DELETE FROM ContactInfo WHERE ContactID = @id";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvContactInfo.DataKeys[e.RowIndex].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    populateGridview();
                    lblSuccesMsg.Text = "Record deleted Successfully..!";
                    lblErrorMsg.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblSuccesMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void gvContactInfo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcon))
                {
                    cnn.Open();
                    string query = "UPDATE ContactInfo SET FirstName=@FirstName,LastName=@LastName,ContactNo=@ContactNo,Email=@Email WHERE ContactID = @id";
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    cmd.Parameters.AddWithValue("@FirstName", (gvContactInfo.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", (gvContactInfo.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@ContactNo", (gvContactInfo.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", (gvContactInfo.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvContactInfo.DataKeys[e.RowIndex].Value.ToString()));
                    cmd.ExecuteNonQuery();
                    gvContactInfo.EditIndex = -1;
                    populateGridview();
                    lblSuccesMsg.Text = "Selected record updated Successfully..!";
                    lblErrorMsg.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblSuccesMsg.Text = "";
                lblErrorMsg.Text = ex.Message;
            }
        }

        protected void gvContactInfo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvContactInfo.EditIndex = -1;
            populateGridview();
        }
    }
}