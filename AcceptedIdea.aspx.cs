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
    public partial class AcceptedIdea : System.Web.UI.Page
    {

        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

        SqlConnection con = new SqlConnection(cs);

        public List<string> departmentIds = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                bindDepartmentIdea();



                // finding the department of the HOD from HOD table with Employee id=Session["empid"] 
                string q = "select department	 from HOD where employeeId='" + Convert.ToString(Session["empid"]) + "'";
                con.Open();
                SqlCommand Cmd = new SqlCommand(q, con);
                string hod_dept = null;
                SqlDataReader reader = Cmd.ExecuteReader();
                if (reader.Read()) { hod_dept = reader["department"].ToString(); }
                con.Close();

                SqlDataAdapter da1 = new SqlDataAdapter("select hod.Name as drName,hod.employeeID as drMobile from HOD hod inner join ideaMaster im on hod.Department=im.Department where hod.Department='" + hod_dept + "' group by hod.Name,hod.employeeID", con);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                chkDrList.DataSource = dt;
                chkDrList.DataValueField = "drMobile";
                chkDrList.DataTextField = "drName";
                chkDrList.DataBind();

            }
        }
        private void GetDepartment()
        {
            try
            {

                SqlDataAdapter da1 = new SqlDataAdapter("Select Department from HOD where EmployeeID='" + Session["empid"].ToString() + "' and Type='HOD'", con);// EmployeeID=" + Session["empid"].ToString() + " //12835
                DataTable dt = new DataTable();
                da1.Fill(dt);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            departmentIds.Add(dr["Department"].ToString());
                        }
                    }
                    else
                    {
                        departmentIds.Add("");
                    }
                }
                else
                {
                    departmentIds.Add("");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bindDepartmentIdea()
        {
            try
            {
                GetDepartment();
                string query = @"Select top 2 im.*,hod.Name,dpt.Department as [Emp Dept],dm.Department as departmentname from ideaMaster im with (NoLOCK) inner join HOD hod on im.EmpNo=hod.employeeID inner join DepartmentMaster dm with (NoLOCK) on im.Department=dm.AutoID inner join DepartmentMaster dpt with (NoLOCK) on hod.Department=dpt.AutoID where status = 'Assigned' and  ("; //remove status = 'Assigned' and 
                if (departmentIds.Count > 0)
                {
                    //query += "( ";

                    foreach (string item in departmentIds)
                    {
                        query += " im.Department='" + item + "' or";
                    }

                    query = query.Substring(0, query.Length - 2) + " ) ";
                }
                if (txtsearch.Text != "")
                {
                    query = query + " and ( im.AutoID LIKE '%'+'" + txtsearch.Text + "'+'%' OR hod.name LIKE '%'+'" + txtsearch.Text + "'+'%'  OR im.Idea LIKE '%'+'" + txtsearch.Text + "'+'%'  OR im.Benefit LIKE '%'+'" + txtsearch.Text + "'+'%' OR dm.Department LIKE '%'+'" + txtsearch.Text + "'+'%' OR im.EmpNo LIKE '%'+'" + txtsearch.Text + "'+'%')";
                }

                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                //Error.Visible = true;
                //Error.Attributes.Add("class", "alert alert-danger alert-dismissible");
                //lblErrorHead.Text = ex.Message.ToString();
                //lblSubHead.Text = "...";
            }
        }
        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            bindDepartmentIdea();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindDepartmentIdea();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void ChkCntrl_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ChkCntrl_CheckedChanged1(object sender, EventArgs e)
        {

            CheckBox ChkBoxHeader = (CheckBox)GridView1.HeaderRow.FindControl("ChkCntrl1");
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("ChkCntrl");
                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }



        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("ChkCntrl") as CheckBox);
                    if (chkRow.Checked)
                    {
                        Label rid = (row.Cells[1].FindControl("lblid") as Label);
                        foreach (ListItem item in chkDrList.Items)
                        {
                            if (item.Selected == true)
                            {
                                Label lblId = (Label)row.FindControl("lblid");

                                using (con)
                                {
                                    int icnt = 0; int lcnt = 0;
                                    con.Open();
                                    SqlCommand getMaxCmd = new SqlCommand("SELECT MAX(AutoID) FROM ideaMaster", con);
                                    object ideaObj = getMaxCmd.ExecuteScalar();
                                    icnt = ideaObj != DBNull.Value ? Convert.ToInt32(ideaObj) : 0;

                                    getMaxCmd.CommandText = "SELECT MAX(AutoID) FROM ideaLog";
                                    object logObj = getMaxCmd.ExecuteScalar();
                                    lcnt = logObj != DBNull.Value ? Convert.ToInt32(logObj) : 0;
                                    con.Close();
                                    //getting hodid from ideamasters
                                    string hodid = "";
                                    string hoddept = "";
                                    con.Open();

                                    //getting empid of the person who gave the idea
                                    string q = "Select empno, department  from IDEAMASTER where AutoID ='" + lblId.Text + "'";
                                    SqlCommand Cmd = new SqlCommand(q, con);
                                    //Cmd.Parameters.AddWithValue("@AutoID", ideaId);

                                    SqlDataReader reader = Cmd.ExecuteReader();
                                    if (reader.Read())
                                    {
                                        hodid = reader["EmpNo"].ToString();
                                        hoddept = reader["department"].ToString();
                                    }

                                    con.Close();



                                    con.Open();

                                    SqlCommand assignDB = new SqlCommand("INSERT INTO assignDB (ideaId, department, representMobile, remarkHOD, ideaStatus, dateTime) VALUES (@ideaId, @department, @representMobile, @remarkHOD, @ideaStatus, @date)", con);
                                    assignDB.Parameters.AddWithValue("@IdeaID", icnt + 1);
                                    assignDB.Parameters.AddWithValue("@department", hoddept);
                                    assignDB.Parameters.AddWithValue("@representMobile", item.Value);
                                    assignDB.Parameters.AddWithValue("@remarkHOD", txtremarks.Text);
                                    assignDB.Parameters.AddWithValue("@ideaStatus", "Pending");
                                    assignDB.Parameters.AddWithValue("@date", DateTime.Now);
                                    assignDB.ExecuteNonQuery();
                                    con.Close();

                                    con.Open();
                                    // changing the status of task is assigned 

                                    string query = "UPDATE IDEAMASTER SET Status = 'Assigned' WHERE EmpNo = @hodid";
                                    SqlCommand cmd = new SqlCommand(query, con);

                                    cmd.Parameters.AddWithValue("@hodid", hodid);
                                    int answer = cmd.ExecuteNonQuery();
                                    con.Close();






                                    string empid = Convert.ToString(Session["empid"]);
                                    con.Open();
                                    SqlCommand logCmd = new SqlCommand("INSERT INTO ideaLog (AutoID, IdeaID, Action, Remark, ByUser, Datetime) VALUES (@LogID, @IdeaID, @Action, @Remark, @ByUser, @Datetime)", con);
                                    logCmd.Parameters.AddWithValue("@LogID", lcnt + 1);
                                    logCmd.Parameters.AddWithValue("@IdeaID", icnt + 1);
                                    logCmd.Parameters.AddWithValue("@Action", "Assign");
                                    logCmd.Parameters.AddWithValue("@Remark", txtremarks.Text);
                                    logCmd.Parameters.AddWithValue("@ByUser", empid);
                                    logCmd.Parameters.AddWithValue("@Datetime", DateTime.Now);
                                    logCmd.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                        }
                    }
                }
            }
            bindDepartmentIdea();
        }
    }
}