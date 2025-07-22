using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace IDEA_BALCO_1
{
    public partial class PointSummary : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                binddata();

            }
        }
        public DataTable GetPointLdeger(string EmployeeID)
        {
            DataTable Dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "usp_Get_Point_Ldeger";
            Cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            DA = new SqlDataAdapter(Cmd);
            DA.Fill(Dt);
            return Dt;
        }
        void binddata()
        {

            // "10999"  //Convert.ToString(Session["empid"])
            DataTable Dt = GetPointLdeger(Convert.ToString(Session["empid"]));
            GridView1.DataSource = Dt;
            GridView1.DataBind();

            if (Dt.Rows.Count > 0)
            {
                decimal total = Convert.ToDecimal(Dt.Compute("SUM(Points)", string.Empty));
                decimal Redeemed = Convert.ToDecimal(Dt.Compute("SUM(Redeemed)", string.Empty));
                GridView1.FooterRow.Cells[2].Text = "Total : ";
                GridView1.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                GridView1.FooterRow.Cells[3].Text = total.ToString("N2");
                GridView1.FooterRow.Cells[4].Text = Redeemed.ToString("N2");
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            binddata();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}