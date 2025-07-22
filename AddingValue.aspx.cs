using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace IDEA_BALCO_1
{
    public partial class AddingValue : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);
        SqlCommand Cmd = null;
        static string sbu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindSBU();
            }
        }




        private void BindSBU()
        {
            Cmd = new SqlCommand("Select Distinct SBU from SBU_Master ORDER BY SBU", con);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlsbu.DataSource = dt;
                ddlsbu.DataTextField = "SBU";
                ddlsbu.DataBind();
            }
            ddlsbu.Items.Insert(0, new ListItem("----Select SBU----", ""));

        }
        protected void ddlSBU_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());

            string query = "Select autoId from SBU_Master where SBU = '" + ddlsbu.SelectedValue + "'";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        sbu = result.ToString();
                    }


                }
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }


        }
        protected void AddSBU_Click(object sender, EventArgs e)
        {
            String sbu = txt_Sbu.Text;
            try
            {
                string q = "INSERT INTO SBU_Master (SBU) VALUES (@SBU)";
                using (SqlCommand cmd = new SqlCommand(q, con))
                {
                    cmd.Parameters.AddWithValue("@SBU", sbu);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblmessage1.Text = "SBU Updated Successfully!!";
                    lblmessage1.Visible = true;
                }
            }
            catch (SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
            BindSBU();

        }

        protected void AddDept_Click(object sender, EventArgs e)
        {
            string sbu_text = ddlsbu.Text;
            string department = txtDepartment.Text.Trim();

            using (con)
            {


                try
                {
                    string query = "INSERT INTO DepartmentMaster (SBU, Department) VALUES (@SBU, @Department)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@SBU", sbu);
                        cmd.Parameters.AddWithValue("@Department", department);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Label2.Text = "Department Updated Successfully!!";
                    Label2.Visible = true;
                }
                catch (SqlException ex)
                {

                }
                finally
                {
                    con.Close();
                }




            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

        }
    }
}
