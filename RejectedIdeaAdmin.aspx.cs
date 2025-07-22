using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace IDEA_BALCO_1
{
    public partial class RejectedIdeaAdmin : System.Web.UI.Page
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
                BindSBU();


            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Department = drpDepartment.SelectedValue.ToString();
            bindDepartmentIdea(Department);
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
        private void bindDepartmentIdea(string Department)
        {
            try
            {
                if (txtsearch.Text != "")
                {
                    Cmd = new SqlCommand("bindDepartmentIdea_search_one", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@SBU_ID", ddlSBU.SelectedValue);
                    Cmd.Parameters.AddWithValue("@Department", Department);
                    Cmd.Parameters.AddWithValue("@Flag", "Rejected");
                    Cmd.Parameters.AddWithValue("@Text", txtsearch.Text);
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else
                {
                    Cmd = new SqlCommand("bindDepartmentIdea", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@SBU_ID", ddlSBU.SelectedValue);
                    Cmd.Parameters.AddWithValue("@Department", Department);
                    Cmd.Parameters.AddWithValue("@Flag", "Rejected");
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GetDepartment()
        {
            try
            {
                SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                SqlDataAdapter da1 = new SqlDataAdapter("Select Department from HOD where  EmployeeID='" + Session["empid"].ToString() + "' and Type='HOD'", con12);
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



    }
}