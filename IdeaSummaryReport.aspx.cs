using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

using System.Web.UI.WebControls;

namespace IDEA_BALCO_1
{
    public partial class IdeaSummaryReport : System.Web.UI.Page
    {

        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

        SqlConnection con = new SqlConnection(cs);

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        void binddata()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT idm.AutoID,idm.EmpNo as [EmpNo], hod.Name AS [Emp_Name],Dm.Department AS [Emp_Dept],sb1.SBU as [Emp_SBU],sb.SBU AS [SBU],hod.company [Employee_Type],CONVERT(nvarchar(10),idm.IdeaDate, 103) as [IdeaDate],dpt.Department as [Benefited_Area],idm.Idea as [Idea],idm.Benefit as [Benefit],idm.Filename as [Image], idm.Status,CASE WHEN idm.implementedDate ='1900-01-01 00:00:00.0000000' THEN null ELSE CONVERT(nvarchar(10),idm.implementedDate, 103) END AS [implementedDate], (SELECT SUBSTRING((SELECT  ',' +  HD.Name FROM assignDB AD LEFT OUTER JOIN dbo.HOD HD ON AD.representMobile =  HD.employeeID where ideaId = idm.AutoID FOR XML PATH('')), 2,10000) AS AssignTo) AS AssignTo, (SELECT TOP 1 processText FROM dbo.implementationProcessDB WHERE ideaID = idm.AutoID ORDER BY AutoID DESC) AS processText, (SELECT TOP 1 Remark FROM ideaLog WHERE IdeaID=idm.AutoID ORDER BY AutoID DESC) AS [HOD_Remark] FROM dbo.ideaMaster idm LEFT OUTER JOIN dbo.HOD hod ON idm.EmpNo=hod.employeeID LEFT OUTER JOIN dbo.departmentMaster dpt ON idm.Department=dpt.AutoID LEFT OUTER JOIN  dbo.departmentMaster dm ON HOD.Department=dm.AutoID LEFT OUTER JOIN dbo.SBU_Master sb ON dpt.SBU=sb.AutoID LEFT OUTER JOIN dbo.SBU_Master sb1 ON hod.SBU=sb1.AutoID WHERE CONVERT(Date,idm.IdeaDate) BETWEEN '" + txtFromDate.Text + "' AND '" + txtToDate.Text + "'  ORDER BY idm.IdeaDate DESC", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            gvMISReport.DataSource = dt1;
            gvMISReport.DataBind();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void gvMISReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMISReport.PageIndex = e.NewPageIndex;
            binddata();
        }
        protected void Export_To_Excel(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Idea Control List.xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            gvMISReport.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            binddata();

        }
        public DataTable GetDepartmentideaMasterCounts(string FromDate, string ToDate)
        {
            DataTable Dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "usp_Get_Department_ideaMaster_Counts";
            Cmd.Parameters.AddWithValue("@FromDate", FromDate);
            Cmd.Parameters.AddWithValue("@ToDate", ToDate);
            DA = new SqlDataAdapter(Cmd);
            DA.Fill(Dt);
            return Dt;
        }
    }
}