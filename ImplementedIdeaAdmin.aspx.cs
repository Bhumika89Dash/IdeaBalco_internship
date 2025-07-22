using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace IDEA_BALCO_1
{
    public partial class ImplementedIdeaAdmin : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);
        SqlCommand Cmd = null;

        public List<string> departmentIds = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSBU();
                drpDepartment.Items.Insert(0, new ListItem("----Select Department----", ""));
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
        protected void lblid_Click(object sender, EventArgs e)
        {
            GridViewRow item = (sender as LinkButton).NamingContainer as GridViewRow;
            string TRID = (item.FindControl("lblID") as LinkButton).Text;

            Session["TRID"] = TRID;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('DetailsIdea.aspx');", true);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Department = drpDepartment.SelectedValue.ToString();
            bindDepartmentIdea(Department);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                clearError();
                GridView1.PageIndex = e.NewPageIndex;
                string Department = drpDepartment.SelectedValue.ToString();
                bindDepartmentIdea(Department);
            }
            catch (Exception ex)
            {

            }
        }


        private void bindDepartmentIdea(string Department)
        {
            try
            {


                if (txtsearch.Text.Trim() != "")
                {
                    //code for search box 

                    Cmd = new SqlCommand("bindDepartmentIdea_search_one", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@SBU_ID", ddlSBU.SelectedValue);
                    Cmd.Parameters.AddWithValue("@Department", Department);
                    Cmd.Parameters.AddWithValue("@Flag", "Implemented");
                    Cmd.Parameters.AddWithValue("@Text", txtsearch.Text);
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();


                }
                else
                {
                    //code without search - auto load


                    Cmd = new SqlCommand("bindDepartmentIdea", con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@SBU_ID", ddlSBU.SelectedValue);
                    Cmd.Parameters.AddWithValue("@Department", Department);
                    Cmd.Parameters.AddWithValue("@Flag", "Implemented");
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert(ex.Message)</script>");
            }


        }











        private void clearError()
        {

        }

    }
}