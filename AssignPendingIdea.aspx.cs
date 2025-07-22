using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IDEA_BALCO_1
{
    public partial class AssignPendingIdea : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);
        SqlCommand Cmd = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Cmd = new SqlCommand("SP_Bind_PendingIdeas_List", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@EmpNo", txtEmployeeID.Text);
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                grdPendingIdeas.DataSource = dt;
                grdPendingIdeas.DataBind();
            }
        }

        protected void btnassign_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            foreach (GridViewRow gvr in grdPendingIdeas.Rows)
            {
                if (((CheckBox)gvr.FindControl("chkSelect")).Checked)
                {
                    str.Append(((Label)gvr.FindControl("lblAutoID")).Text + ",");
                }
            }
            string s1 = str.ToString();
            string removecomma = s1.Remove(s1.Length - 1);
            con.Open();
            Cmd = new SqlCommand("SP_Update_Pending_Ideas_To_Assign_ID", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@AutoID", removecomma.ToString());
            string input = txtassignto.Text;
            string output = input.Split('(', ')')[1];
            Cmd.Parameters.AddWithValue("@Assign_TO_ID", output);
            int res = Cmd.ExecuteNonQuery();
            con.Close();
            if (res > 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Idea Assign sucessfully');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "alert('Somthing Went Wrong!!!...');", true);
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> GetSearch(string prefixText)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand Cmd = new SqlCommand("SP_Search_Emp_Name_By_ID", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@Employee_ID", prefixText);
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataTable Result = new DataTable();
            da.Fill(Result);
            List<string> Output = new List<string>();
            for (int i = 0; i < Result.Rows.Count; i++)
                Output.Add(Result.Rows[i][0].ToString());
            return Output;
        }

    }
}