using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace IDEA_BALCO_1
{
    public partial class EmpDeptUpdate : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);
        SqlCommand Cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSBU();
            }
        }

        public void BindSBU()
        {
            Cmd = new SqlCommand("SP_Bind_SBU", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlSBU.DataSource = dt;
                ddlSBU.DataValueField = "AutoID";
                ddlSBU.DataTextField = "SBU";
                ddlSBU.DataBind();
                ddlSBU.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        protected void ddlSBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            drpDepartment.Items.Clear();
            Cmd = new SqlCommand("SP_Bind_Department", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@SBU_ID", ddlSBU.SelectedValue);
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                drpDepartment.DataSource = dt;
                drpDepartment.DataTextField = "Department";
                drpDepartment.DataValueField = "AutoID";
                drpDepartment.DataBind();
            }
            drpDepartment.Items.Insert(0, new ListItem("----Select Department----", ""));
            drpDepartment.Items.Insert(1, new ListItem("All", "All"));
        }


        protected void btnupddepartment_Click(object sender, EventArgs e)
        {
            Cmd = new SqlCommand("SP_Update_Department", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@SBU", ddlSBU.SelectedItem.Value);
            Cmd.Parameters.AddWithValue("@Department", drpDepartment.SelectedItem.Value);
            Cmd.Parameters.AddWithValue("@EmployeeID", txtEmpID.Text);
            con.Open();
            int i = Cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Department Updated Successfully!');location.href = '/SuperAdmin/Emp_Department_Update/';", true);
            }
        }
    }
}