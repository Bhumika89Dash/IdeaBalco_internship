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
    public partial class AssignedIdeaHOD : System.Web.UI.Page
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        public List<string> departmentIds = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }

            bindDepartmentIdea();

        }

        private void GetDepartment()
        {
            SqlConnection con = new SqlConnection(cs);  /*EmployeeId= '11547'*/
            string query = "SELECT department from HOD where EmployeeId= '" + Convert.ToString(Session["empid"]) + "'  and type='hod'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    departmentIds.Add(row["Department"].ToString());
                }
            }
            else
            {
                departmentIds.Add("");
            }



        }
        private void bindDepartmentIdea()
        {
            if (txtsearch.Text == "")
            {


                GetDepartment();
                SqlConnection con = new SqlConnection(cs);



                string query = "SELECT im.*,dm.Department as departmentname,dm.SBU from ideaMaster im inner join DepartmentMaster dm on im.Department=dm.AutoID where im.Status='Assigned'";
                if (departmentIds.Count > 0)
                {
                    query += " and (";
                    foreach (string dept in departmentIds)
                    {
                        query += " im.department = '" + Convert.ToString(dept) + "' or";
                    }
                    query = query.Substring(0, query.Length - 2) + ")";
                }

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                searchedID();
            }
        }

        protected void searchedID()
        {

            GetDepartment();
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT im.*,dm.Department as departmentname,dm.SBU from ideaMaster im inner join DepartmentMaster dm on im.Department=dm.AutoID where im.Status='Assigned' and (im.AutoID like '%'+'" + txtsearch.Text + "'+'%') ";
            if (departmentIds.Count > 0)
            {
                query += " and (";
                foreach (string dept in departmentIds)
                {
                    query += " im.department = '" + Convert.ToString(dept) + "' or";
                }
                query = query.Substring(0, query.Length - 2) + ")";
            }

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
            GridViewRow item = (sender as LinkButton).NamingContainer as GridViewRow;
            string TRID = (item.FindControl("lblID") as Label).Text;

            Session["TRID"] = TRID;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('DetailsIdea.aspx');", true);
        }
    }

}