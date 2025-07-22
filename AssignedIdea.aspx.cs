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
    public partial class AssignedIdea : System.Web.UI.Page
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }

            binddata();

        }

        void binddata()
        {

            if (txtsearch.Text.Trim() != "")
            {
                SqlConnection con = new SqlConnection(cs);   /* adb.representMobile like  '%'+'" + Convert.ToString(Session["empid"]) + " ' and*/
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT im.*,hod.Name,dpt.Department as [Dpt_Name],adb.dateTime as [Assign_Date],dm.Department as departmentname,dm.SBU, adb.ideaStatus from ideaMaster im inner join DepartmentMaster dm on im.Department = dm.AutoID inner join AssignDB adb on adb.ideaId = im.AutoId inner join HOD hod on im.EmpNo = hod.employeeID inner join departmentMaster dpt on hod.Department = dpt.AutoID where im.Status not in ('Implemented', 'Rejected') and adb.representMobile like  '%'+'" + Convert.ToString(Session["empid"]) + " ' and (im.autoId like  '%'+'" + txtsearch.Text + "' OR hod.Name like  '%'+'" + txtsearch.Text + "' OR im.benefit like  '%'+'" + txtsearch.Text + "' OR im.idea like  '%'+'" + txtsearch.Text + "' OR dpt.department like  '%'+'" + txtsearch.Text + "'  ) order by convert(int, im.autoid)", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();



            }
            else
            {
                //if (Convert.ToString(Session["empid"]) == "Employee") { }
                SqlConnection con = new SqlConnection(cs);   /* adb.representMobile like  '%'+'" + Convert.ToString(Session["empid"]) + " ' and*/
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT im.*,hod.Name,dpt.Department as [Dpt_Name],adb.dateTime as [Assign_Date],dm.Department as departmentname,dm.SBU, adb.ideaStatus from ideaMaster im inner join DepartmentMaster dm on im.Department = dm.AutoID inner join AssignDB adb on adb.ideaId = im.AutoId inner join HOD hod on im.EmpNo = hod.employeeID inner join departmentMaster dpt on hod.Department = dpt.AutoID where adb.representMobile like  '%'+'" + Convert.ToString(Session["empid"]) + " ' and im.Status not in ('Implemented', 'Rejected') order by convert(int, im.autoid)", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();

                /*     else
                {
                    SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                    SqlDataAdapter da1 = new SqlDataAdapter("SELECT im.*,hod.Name,dpt.Department as [Dpt_Name],adb.dateTime as [Assign_Date], dm.Department as departmentname, dm.SBU, adb.ideaStatus from ideaMaster im  inner join DepartmentMaster dm on im.Department = dm.AutoID  inner join AssignDB adb on adb.ideaId = im.AutoId inner join HOD hod on im.EmpNo = hod.employeeID inner join departmentMaster dpt on hod.Department = dpt.AutoID where adb.representMobile like  '%'+'" + Convert.ToString(Session["empid"]) + "' and im.Status not in ('Implemented', 'Rejected') order by convert(int, im.autoid)", con12);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                }*/

            }

        }
        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            binddata();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }

}