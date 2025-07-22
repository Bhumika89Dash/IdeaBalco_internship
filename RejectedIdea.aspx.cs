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
    public partial class RejectedIdea : System.Web.UI.Page
    {
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

            }
        }
        private void GetDepartment()
        {
            try
            {
                SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                SqlDataAdapter da1 = new SqlDataAdapter("Select Department from HOD where EmployeeID='12221' and Type='HOD'", con12);  /*EmployeeID=" + Session["empid"].ToString() + "*/  //12221
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
                string query = @"Select im.*,hod.Name,dpt.Department as [Emp Dept],dm.Department as departmentname from ideaMaster im inner join HOD hod on im.EmpNo=hod.employeeID inner join DepartmentMaster dm on im.Department=dm.AutoID inner join DepartmentMaster dpt on hod.Department=dpt.AutoID where im.Status='Rejected'";
                if (departmentIds.Count > 0)
                {
                    query += " and ( ";

                    foreach (string item in departmentIds)
                    {
                        query += " im.Department='" + item + "' or";
                    }

                    query = query.Substring(0, query.Length - 2) + " ) ";
                }
                SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                SqlDataAdapter da1 = new SqlDataAdapter(query, con12);
                DataTable dt = new DataTable();
                da1.Fill(dt);
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



    }
}