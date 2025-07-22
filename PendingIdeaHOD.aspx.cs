using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace IDEA_BALCO_1
{
    public partial class PendingIdeaHOD : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

        public List<string> departmentIds = new List<string>();
        SqlConnection con = new SqlConnection(cs);
        SqlCommand Cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                bindDepartmentIdea();

            }
        }
        private void GetDepartment()
        {
            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter("Select Department from HOD where EmployeeID='" + Session["empid"].ToString() + "' and Type='HOD'", con); //" + Session["empid"].ToString() + " //13584
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

        private void bindDepartmentIdea()
        {
            try
            {
                GetDepartment();
                /*select top 200 due to server issue*/
                string query = "Select top 200 im.AutoID,im.EmpNo,hod.Name,dpt.Department as [Emp Dept],im.Idea,im.Benefit,dm.Department as departmentname,im.Filename,im.IdeaDate from ideaMaster im with (NoLOCK) inner join HOD hod on im.EmpNo = hod.employeeID inner join DepartmentMaster dm With (NOLOCK) on im.Department = dm.AutoID inner join DepartmentMaster dpt with (NOLOCK) on hod.Department = dpt.AutoID where im.Status = 'Pending' and"; //im.Status = 'Pending' and
                if (departmentIds.Count > 0)
                {
                    query += " ( ";

                    foreach (string item in departmentIds)
                    {
                        query += " im.Department='" + item + "' or";
                    }

                    query = query.Substring(0, query.Length - 2) + " ) ";

                }
                if (txtsearch.Text != "")
                {
                    query = query + " and ( im.AutoID LIKE '%'+'" + txtsearch.Text + "'+'%' OR hod.name LIKE '%'+'" + txtsearch.Text + "'+'%'  OR im.Idea LIKE '%'+'" + txtsearch.Text + "'+'%'  OR im.Benefit LIKE '%'+'" + txtsearch.Text + "'+'%' OR dm.Department LIKE '%'+'" + txtsearch.Text + "'+'%')";
                }

                con.Open();
                SqlDataAdapter da1 = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                con.Close();

            }
            catch (Exception ex)
            {

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

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (CheckBox)row.FindControl("ChkCntrl");
                    if (chkRow.Checked)
                    {
                        Label lblId = (Label)row.FindControl("lblid");
                        string ideaId = lblId.Text.Trim();

                        string status = ddltype.SelectedItem.Text.Trim();
                        string department = ddldept.SelectedValue;
                        string empid = Convert.ToString(Session["empid"]);
                        string remark = txtremarks.Text.Trim();

                        using (con)
                        {
                            con.Open();

                            SqlCommand updateCmd = new SqlCommand("UPDATE ideaMaster SET Status = @Status WHERE AutoID = @AutoID", con);

                            updateCmd.Parameters.AddWithValue("@Status", status);
                            updateCmd.Parameters.AddWithValue("@Dept", department);
                            updateCmd.Parameters.AddWithValue("@AutoID", ideaId);
                            updateCmd.ExecuteNonQuery();

                            int newIdeaId = 0, newLogId = 0;
                            SqlCommand getMaxCmd = new SqlCommand("SELECT MAX(AutoID) FROM ideaMaster", con);
                            object ideaObj = getMaxCmd.ExecuteScalar();
                            newIdeaId = ideaObj != DBNull.Value ? Convert.ToInt32(ideaObj) : 0;

                            getMaxCmd.CommandText = "SELECT MAX(AutoID) FROM ideaLog";
                            object logObj = getMaxCmd.ExecuteScalar();
                            newLogId = logObj != DBNull.Value ? Convert.ToInt32(logObj) : 0;

                            SqlCommand logCmd = new SqlCommand("INSERT INTO ideaLog (AutoID, IdeaID, Action, Remark, ByUser, Datetime) VALUES (@LogID, @IdeaID, @Action, @Remark, @ByUser, @Datetime)", con);
                            logCmd.Parameters.AddWithValue("@LogID", newLogId + 1);
                            logCmd.Parameters.AddWithValue("@IdeaID", newIdeaId + 1);
                            logCmd.Parameters.AddWithValue("@Action", status);
                            logCmd.Parameters.AddWithValue("@Remark", remark);
                            logCmd.Parameters.AddWithValue("@ByUser", empid);
                            logCmd.Parameters.AddWithValue("@Datetime", DateTime.Now);
                            logCmd.ExecuteNonQuery();



                            con.Close();

                            if (ddltype.SelectedItem.Text.Trim() == "Accept")
                            {
                                con.Open();

                                //getting empid of the person who gave the idea
                                string q = "Select empno from IDEAMASTER where AutoID ='" + lblId.Text + "'";
                                SqlCommand Cmd = new SqlCommand(q, con);
                                //Cmd.Parameters.AddWithValue("@AutoID", ideaId);
                                string empno = null;
                                SqlDataReader reader = Cmd.ExecuteReader();
                                if (reader.Read()) { empno = reader["EmpNo"].ToString(); }

                                con.Close();
                                con.Open();

                                SqlCommand clubCmd = new SqlCommand("INSERT INTO IdeaClubPoints (EmployeeID, IdeaID, description, pointsAdded, pointRedeemed, status,date) VALUES (@EmployeeID, @IdeaID,@description, @pointsAdded, @pointRedeemed, @status, @date)", con);
                                clubCmd.Parameters.AddWithValue("@EmployeeID", empno);
                                clubCmd.Parameters.AddWithValue("@IdeaID", newIdeaId + 1);
                                clubCmd.Parameters.AddWithValue("@description", "Points added on accepting idea");
                                clubCmd.Parameters.AddWithValue("@pointsAdded", 1);
                                clubCmd.Parameters.AddWithValue("@pointRedeemed", 0);
                                clubCmd.Parameters.AddWithValue("@status", status);
                                clubCmd.Parameters.AddWithValue("@date", DateTime.Now);
                                clubCmd.ExecuteNonQuery();




                                con.Close();
                            }


                        }
                    }
                }

            }
            bindDepartmentIdea();
        }



        protected void ddltype_TextChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedItem.Text == "Forward")
            {
                fwd.Visible = true;
                bindDepartment();
            }
            else
            {
                fwd.Visible = false;
                ddldept.Items.Clear();
            }
        }
        public void bindDepartment()
        {
            try
            {
                ddldept.Items.Clear();
                ddldept.Items.Add("Select");
                SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                SqlDataAdapter da1 = new SqlDataAdapter("Select dm.AutoID,dm.SBU,sbu.SBU + ' - ' + dm.Department AS Department from DepartmentMaster dm INNER JOIN SBU_Master sbu ON dm.SBU = sbu.AutoID  where sbu.AutoID not in  (7,8,15,29,21,25) and dm.AutoID not in (3,12,25,37,40,43,52) ", con12);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                ddldept.DataSource = dt;
                ddldept.DataBind();
            }
            catch (Exception ex)
            {

            }
        }


    }
}