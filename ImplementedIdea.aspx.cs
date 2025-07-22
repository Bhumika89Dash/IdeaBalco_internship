using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace IDEA_BALCO_1
{
    public partial class ImplementedIdea : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }

            binddata();

        }
        private void binddata()
        {
            if (txtsearch.Text != "")
            {
                searchedID();


            }
            else
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "SELECT im.*,hod.Name,dm.Department as departmentname,dm.SBU,adb.ideaStatus, sb.SBU as SBU_Name  from ideaMaster im inner join DepartmentMaster dm on im.Department = dm.AutoID  inner join AssignDB adb on adb.ideaId = im.AutoId inner join HOD hod on im.EmpNo = hod.employeeID inner join SBU_Master sb on hod.SBU = sb.AutoID where adb.representMobile ='" + Convert.ToString(Session["empid"]) + "' and im.Status='Implemented' order by convert(int, im.autoid)";  // adb.representMobile = " + Convert.ToString(Session["empid"]) + "
                /* adb.representMobile = '" + Convert.ToString(Session["empid"]) + "' */
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void searchedID()
        {


            SqlConnection con = new SqlConnection(cs);
            /*'" + Convert.ToString(Session["empid"]) + "'*/
            string query = "SELECT im.*,hod.Name,dm.Department as departmentname,dm.SBU,adb.ideaStatus, sb.SBU as SBU_Name  from ideaMaster im inner join DepartmentMaster dm on im.Department = dm.AutoID  inner join AssignDB adb on adb.ideaId = im.AutoId inner join HOD hod on im.EmpNo = hod.employeeID inner join SBU_Master sb on hod.SBU = sb.AutoID where adb.representMobile ='" + Convert.ToString(Session["empid"]) + "' and Status='Implemented' and (im.AutoID like '%'+'" + txtsearch.Text + "'+'%' OR dm.Department like '%'+'" + txtsearch.Text + "'+'%' OR im.Idea like '%'+'" + txtsearch.Text + "'+'%' OR im.Benefit like '%'+'" + txtsearch.Text + "'+'%' OR adb.ideaStatus like '%'+'" + txtsearch.Text + "'+'%') order by convert(int, im.autoid)";  //" + Convert.ToString(Session["empid"]) + "

            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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

        protected void lnkView_Click(object sender, EventArgs e)
        {
            GridViewRow item = (sender as LinkButton).NamingContainer as GridViewRow;
            string TRID = (item.FindControl("lblID") as Label).Text;

            Session["TRID"] = TRID;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenWindow", "window.open('DetailsIdea.aspx');", true);
        }
    }
}