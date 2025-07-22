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
    public partial class PendingIdeaAdmin : System.Web.UI.Page
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
                //bindDepartmentIdea();
                BindSBU();
            }
        }
        private void GetDepartment()
        {
            try
            {
                SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                SqlDataAdapter da1 = new SqlDataAdapter("Select Department from HOD where EmployeeID=" + Session["empid"].ToString() + " and Type='HOD'", con12);
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
        protected void ddlSBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDepartment();
        }
        private void bindDepartmentIdea(string Department)
        {
            try
            {
                Cmd = new SqlCommand("bindDepartmentIdea", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@SBU_ID", ddlSBU.SelectedValue);
                Cmd.Parameters.AddWithValue("@Department", Department);
                Cmd.Parameters.AddWithValue("@Flag", "Pending");
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void BindSBU()
        {
            ddlSBU.Items.Clear();
            Cmd = new SqlCommand("SP_Bind_SBU", con);
            Cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(Cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ddlSBU.DataSource = dt;
                ddlSBU.DataTextField = "SBU";
                ddlSBU.DataValueField = "AutoID";
                ddlSBU.DataBind();
            }
            ddlSBU.Items.Insert(0, new ListItem("----Select SBU----", ""));
            ddlSBU.Items.Insert(1, new ListItem("All", "All"));
        }
        public void bindDepartment()
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
        private void bindDepartment1()
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
        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            bindDepartmentIdea(drpDepartment.SelectedValue);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindDepartmentIdea(drpDepartment.SelectedValue);
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
            bindDepartmentIdea(drpDepartment.SelectedValue);
        }



        protected void ddltype_TextChanged(object sender, EventArgs e)
        {
            if (ddltype.SelectedItem.Text == "Forward")
            {
                fwd.Visible = true;
                bindDepartment1();
            }
            else
            {
                fwd.Visible = false;
                ddldept.Items.Clear();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindDepartmentIdea(drpDepartment.SelectedValue);
        }
    }
}