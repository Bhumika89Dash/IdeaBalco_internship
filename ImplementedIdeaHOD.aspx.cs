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
    public partial class ImplementedIdeaHOD : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);
        public List<string> departmentIds = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
            catch (SqlException ex)
            {
            }
        }


        private void getDepartment()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Department from HOD where EmployeeID='" + Session["empid"].ToString() + "' and type='HOD'", con); //13584 //" + Session["empid"].ToString() + "
                DataTable dt = new DataTable();
                da.Fill(dt);
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
            catch (SqlException ex)
            {
            }
        }

        private void bindDepartmentIdea()
        {
            try
            {
                getDepartment();
                string query = @"SELECT top 10 im.*,dm.Department as departmentname,dm.SBU from ideaMaster im inner join DepartmentMaster dm on im.Department=dm.AutoID where im.Status='Implemented' ";
                if (departmentIds.Count > 0)
                {
                    query += " and ( ";

                    foreach (string item in departmentIds)
                    {
                        query += " im.Department='" + item + "' or";
                    }

                    query = query.Substring(0, query.Length - 2) + " ) ";
                }
                if (txtsearch.Text != "")
                {
                    query = query + " and ( im.AutoID LIKE '%'+'" + txtsearch.Text + "'+'%' OR dm.Department LIKE '%'+'" + txtsearch.Text + "'+'%'  OR im.Idea LIKE '%'+'" + txtsearch.Text + "'+'%'  OR im.Benefit LIKE '%'+'" + txtsearch.Text + "'+'%')";
                }



                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
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

        protected void lnkView_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow item = (sender as LinkButton).NamingContainer as GridViewRow;
                string TRID = (item.FindControl("lblID") as Label).Text;

                Session["TRID"] = TRID;
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "TestAlert", "alert('Script is working fine ');", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('DetailsIdea.aspx');", true);
            }

            catch (SqlException ex)
            {

            }
        }
    }
}