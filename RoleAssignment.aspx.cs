using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;

namespace IDEA_BALCO_1
{
    public partial class RoleAssignment : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

        SqlConnection con = new SqlConnection(cs);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand("SP_Get_EmpDetails", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@employeeID", txtEmployeeID.Text);
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                lblEmployeeID.Text = "<b>Employee ID: </b> " + dt.Rows[0]["EmployeeID"].ToString();
                lblEmployeeName.Text = "<b>Employee Name: </b> " + dt.Rows[0]["Name"].ToString();
                lblCurrentRole.Text = "<b>Current Role:  </b>" + dt.Rows[0]["Current_Role"].ToString();
                lblDepartment.Text = "<b>Department:  </b>" + dt.Rows[0]["Department"].ToString();
                lblDesignation.Text = "<b>SBU:  </b>" + dt.Rows[0]["SBU"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SqlCommand Cmd = new SqlCommand("Update_Assign_Role", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Employee_ID", txtEmployeeID.Text);
            Cmd.Parameters.AddWithValue("@Role_Type", ddlRole.SelectedItem.Text);
            con.Open();
            Cmd.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Record updated successfully!');location.href = 'RoleAssignment.aspx';", true);
        }
    }
}