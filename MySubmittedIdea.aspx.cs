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
    public partial class MySubmittedIdea : System.Web.UI.Page
    {
        string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }

            databind();

        }

        void databind()
        {

            SqlConnection con = new SqlConnection(cs);
            con.Open();
            if (txtsearch.Text.Trim() != "")
            {

                SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());

                SqlDataAdapter da = new SqlDataAdapter("SELECT im.AutoID,im.Idea,im.Benefit,im.Filename,im.EmpNo,im.IdeaDate,im.Status,dm.Department as departmentname,sb.SBU, (select top 1 Remark from ideaLog where IdeaID=im.AutoID and Action='Reject') as Remark  from ideaMaster im inner join DepartmentMaster dm on im.Department = dm.AutoID inner  join SBU_Master sb on dm.SBU = sb.autoID where im.EmpNo like  '%'+ '" + Convert.ToString(Session["empid"]) + "' and (im.AutoID like '%'+'" + txtsearch.Text + "'+'%' or im.Idea like '%'+'" + txtsearch.Text + "'+'%' or im.Benefit like '%'+'" + txtsearch.Text + "'+'%' or im.Status like '%'+'" + txtsearch.Text + "'+'%' or dm.Department like '%'+'" + txtsearch.Text + "'+'%' or im.IdeaDate like '%'+'" + txtsearch.Text + "'+'%') order by convert(int, im.autoid)", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();


            }

            else
            {
                String query = "SELECT im.AutoID,im.Idea,im.Benefit,im.Filename,im.EmpNo,im.IdeaDate,im.Status,dm.Department as departmentname,sb.SBU, (select top 1 Remark from ideaLog where IdeaID = im.AutoID and Action = 'Reject') as Remark  from ideaMaster im inner join DepartmentMaster dm on im.Department = dm.AutoID inner join SBU_Master sb on dm.SBU = sb.autoID where im.EmpNo = '" + Convert.ToString(Session["empid"]) + "' order by convert(int, im.autoid)";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }




        }
        protected void txtsearch_TextChanged(object sender, EventArgs e)
        {
            databind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            databind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}