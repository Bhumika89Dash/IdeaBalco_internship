using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.IO;

namespace IDEA_BALCO_1
{
    public partial class MISReport : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();


        SqlConnection con = new SqlConnection(cs);
        SqlCommand Cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindSBU();
                ddlDepartment.Items.Insert(0, new ListItem("----Select Department----", ""));

            }
        }

        void binddata()
        {

            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter();
                DataTable dt1 = new DataTable();
                DateTime fromDate = DateTime.ParseExact(txtDateFrom.Text, "dd-MM-yyyy", null);
                DateTime toDate = DateTime.ParseExact(txtDateTo.Text, "dd-MM-yyyy", null);

                if (ddlDepartment.SelectedValue.ToString() == "All" && ddlStatus.SelectedValue.ToString() == "All")
                {
                    if (ddlSBU.SelectedValue.ToString() == "All")
                    {
                        SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                        da1 = new SqlDataAdapter("SELECT idm.AutoID,idm.EmpNo as [EmpNo], hod.Name AS [Emp_Name],Dm.Department AS [Emp_Dept],sb1.SBU as [Emp_SBU], sb.SBU AS[SBU], hod.company[Employee_Type], CONVERT(nvarchar(10), idm.IdeaDate, 103) as [IdeaDate], dpt.Department as [Benefited_Area], idm.Idea as [Idea], idm.Benefit as [Benefit], idm.Filename as [Image], idm.Status, CASE WHEN idm.implementedDate = '1900-01-01 00:00:00.000000' THEN null ELSE CONVERT(nvarchar(10), idm.implementedDate, 103) END AS[implementedDate], (SELECT SUBSTRING((SELECT  ',' + HD.Name FROM assignDB AD LEFT OUTER JOIN dbo.HOD HD ON AD.representMobile = HD.employeeID where ideaId = idm.AutoID FOR XML PATH('')), 2, 10000) AS[AssignTo]) AS[AssignTo], (SELECT TOP 1 processText FROM dbo.implementationProcessDB WHERE ideaID = idm.AutoID ORDER BY AutoID DESC) AS processText, (SELECT TOP 1 Remark FROM ideaLog WHERE IdeaID = idm.AutoID ORDER BY AutoID DESC) AS[HOD_Remark] FROM dbo.ideaMaster idm LEFT OUTER JOIN dbo.HOD hod ON idm.EmpNo = hod.employeeID LEFT OUTER JOIN dbo.departmentMaster dpt ON idm.Department = dpt.AutoID LEFT OUTER JOIN dbo.departmentMaster dm ON HOD.Department = dm.AutoID LEFT OUTER JOIN dbo.SBU_Master sb ON dpt.SBU = sb.AutoID LEFT OUTER JOIN dbo.SBU_Master sb1 ON hod.SBU = sb1.AutoID WHERE idm.IdeaDate BETWEEN try_CAST('" + fromDate.ToString("MM-dd-yyyy") + "' AS DATE) AND TRY_CAST('" + toDate.ToString("MM-dd-yyyy") + "' AS DATE) ORDER BY idm.IdeaDate DESC", con12);

                        da1.Fill(dt1);
                        gvMISReport.DataSource = dt1;
                        gvMISReport.DataBind();

                    }
                    else
                    {
                        SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                        da1 = new SqlDataAdapter("SELECT idm.AutoID,idm.EmpNo as [EmpNo], hod.Name AS [Emp_Name],Dm.Department AS [Emp_Dept],sb1.SBU as [Emp_SBU],sb.SBU AS [SBU],hod.company [Employee_Type],CONVERT(nvarchar(10),idm.IdeaDate, 103) as [IdeaDate],dpt.Department as [Benefited_Area],idm.Idea as [Idea],idm.Benefit as [Benefit],idm.Filename as [Image], idm.Status,CASE WHEN idm.implementedDate ='1900-01-01 00:00:00.0000000' THEN null ELSE CONVERT(nvarchar(10),idm.implementedDate, 103) END AS [implementedDate], (SELECT SUBSTRING((SELECT  ',' +  HD.Name FROM assignDB AD LEFT OUTER JOIN dbo.HOD HD ON AD.representMobile =  HD.employeeID where ideaId = idm.AutoID FOR XML PATH('')), 2,10000) AS AssignTo) AS AssignTo, (SELECT TOP 1 processText FROM dbo.implementationProcessDB WHERE ideaID = idm.AutoID ORDER BY AutoID DESC) AS processText, (SELECT TOP 1 Remark FROM ideaLog WHERE IdeaID=idm.AutoID ORDER BY AutoID DESC) AS [HOD_Remark] FROM dbo.ideaMaster idm LEFT OUTER JOIN dbo.HOD hod ON idm.EmpNo=hod.employeeID LEFT OUTER JOIN dbo.departmentMaster dpt ON idm.Department=dpt.AutoID LEFT OUTER JOIN  dbo.departmentMaster dm ON HOD.Department=dm.AutoID LEFT OUTER JOIN dbo.SBU_Master sb ON dpt.SBU=sb.AutoID LEFT OUTER JOIN dbo.SBU_Master sb1 ON hod.SBU=sb1.AutoID WHERE idm.IdeaDate BETWEEN try_CAST('" + fromDate.ToString("MM-dd-yyyy") + "' AS DATE) AND TRY_CAST('" + toDate.ToString("MM-dd-yyyy") + "' AS DATE) AND IDM.Department IN (SELECT AutoID FROM departmentMaster WHERE SBU='" + ddlSBU.SelectedValue.ToString() + "') ORDER BY idm.IdeaDate DESC", con12);

                        da1.Fill(dt1);
                        gvMISReport.DataSource = dt1;
                        gvMISReport.DataBind();

                    }
                }
                if (ddlDepartment.SelectedValue.ToString() == "All" && ddlStatus.SelectedValue.ToString() != "All")
                {
                    if (ddlSBU.SelectedValue.ToString() == "All")
                    {
                        SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                        da1 = new SqlDataAdapter("SELECT idm.AutoID,idm.EmpNo as [EmpNo], hod.Name AS [Emp_Name],Dm.Department AS [Emp_Dept],sb1.SBU as [Emp_SBU],sb.SBU AS [SBU],hod.company [Employee_Type],CONVERT(date,idm.IdeaDate, 103) as [IdeaDate],dpt.Department as [Benefited_Area],idm.Idea as [Idea],idm.Benefit as [Benefit],idm.Filename as [Image], idm.Status,CASE WHEN idm.implementedDate ='1900-01-01 00:00:00.0000000' THEN null ELSE CONVERT(date,idm.implementedDate, 103) END AS [implementedDate], (SELECT SUBSTRING((SELECT  ',' +  HD.Name FROM assignDB AD LEFT OUTER JOIN dbo.HOD HD ON AD.representMobile =  HD.employeeID where ideaId = idm.AutoID FOR XML PATH('')), 2,10000) AS AssignTo) AS AssignTo, (SELECT TOP 1 processText FROM dbo.implementationProcessDB WHERE ideaID = idm.AutoID ORDER BY AutoID DESC) AS processText, (SELECT TOP 1 Remark FROM ideaLog WHERE IdeaID=idm.AutoID ORDER BY AutoID DESC) AS [HOD_Remark] FROM dbo.ideaMaster idm LEFT OUTER JOIN dbo.HOD hod ON idm.EmpNo=hod.employeeID LEFT OUTER JOIN dbo.departmentMaster dpt ON idm.Department=dpt.AutoID LEFT OUTER JOIN  dbo.departmentMaster dm ON HOD.Department=dm.AutoID LEFT OUTER JOIN dbo.SBU_Master sb ON dpt.SBU=sb.AutoID LEFT OUTER JOIN dbo.SBU_Master sb1 ON hod.SBU=sb1.AutoID WHERE idm.IdeaDate BETWEEN try_CAST('" + fromDate.ToString("MM-dd-yyyy") + "' AS DATE) AND TRY_CAST('" + toDate.ToString("MM-dd-yyyy") + "' AS DATE) AND idm.Status = '" + ddlStatus.SelectedValue.ToString() + "' ORDER BY idm.IdeaDate DESC", con12);
                        da1.Fill(dt1);
                        gvMISReport.DataSource = dt1;
                        gvMISReport.DataBind();

                    }
                    else
                    {
                        SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                        da1 = new SqlDataAdapter("SELECT idm.AutoID,idm.EmpNo as [EmpNo], hod.Name AS [Emp_Name],Dm.Department AS [Emp_Dept],sb1.SBU as [Emp_SBU],sb.SBU AS [SBU],hod.company [Employee_Type],CONVERT(nvarchar(10),idm.IdeaDate, 103) as [IdeaDate],dpt.Department as [Benefited_Area],idm.Idea as [Idea],idm.Benefit as [Benefit],idm.Filename as [Image], idm.Status,CASE WHEN idm.implementedDate ='1900-01-01 00:00:00.0000000' THEN null ELSE CONVERT(nvarchar(10),idm.implementedDate, 103) END AS [implementedDate], (SELECT SUBSTRING((SELECT  ',' +  HD.Name FROM assignDB AD LEFT OUTER JOIN dbo.HOD HD ON AD.representMobile =  HD.employeeID where ideaId = idm.AutoID FOR XML PATH('')), 2,10000) AS AssignTo) AS AssignTo, (SELECT TOP 1 processText FROM dbo.implementationProcessDB WHERE ideaID = idm.AutoID ORDER BY AutoID DESC) AS processText, (SELECT TOP 1 Remark FROM ideaLog WHERE IdeaID=idm.AutoID ORDER BY AutoID DESC) AS [HOD_Remark] FROM dbo.ideaMaster idm LEFT OUTER JOIN dbo.HOD hod ON idm.EmpNo=hod.employeeID LEFT OUTER JOIN dbo.departmentMaster dpt ON idm.Department=dpt.AutoID LEFT OUTER JOIN  dbo.departmentMaster dm ON HOD.Department=dm.AutoID LEFT OUTER JOIN dbo.SBU_Master sb ON dpt.SBU=sb.AutoID LEFT OUTER JOIN dbo.SBU_Master sb1 ON hod.SBU=sb1.AutoID WHERE idm.IdeaDate BETWEEN try_CAST('" + fromDate.ToString("MM-dd-yyyy") + "' AS DATE) AND TRY_CAST('" + toDate.ToString("MM-dd-yyyy") + "' AS DATE) AND IDM.Department IN (SELECT AutoID FROM departmentMaster WHERE SBU='" + ddlSBU.SelectedValue.ToString() + "')  AND idm.Status = '" + ddlStatus.SelectedValue.ToString() + "' ORDER BY idm.IdeaDate DESC", con12);

                        da1.Fill(dt1);
                        gvMISReport.DataSource = dt1;
                        gvMISReport.DataBind();

                    }
                }
                if (ddlDepartment.SelectedValue.ToString() != "All" && ddlStatus.SelectedValue.ToString() == "All")
                {
                    SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                    da1 = new SqlDataAdapter("SELECT idm.AutoID,idm.EmpNo as [EmpNo], hod.Name AS [Emp_Name],Dm.Department AS [Emp_Dept],sb1.SBU as [Emp_SBU],sb.SBU AS [SBU],hod.company [Employee_Type],CONVERT(nvarchar(10),idm.IdeaDate, 103) as [IdeaDate],dpt.Department as [Benefited_Area],idm.Idea as [Idea],idm.Benefit as [Benefit],idm.Filename as [Image], idm.Status,CASE WHEN idm.implementedDate ='1900-01-01 00:00:00.0000000' THEN null ELSE CONVERT(nvarchar(10),idm.implementedDate, 103) END AS [implementedDate], (SELECT SUBSTRING((SELECT  ',' +  HD.Name FROM assignDB AD LEFT OUTER JOIN dbo.HOD HD ON AD.representMobile =  HD.employeeID where ideaId = idm.AutoID FOR XML PATH('')), 2,10000) AS AssignTo) AS AssignTo, (SELECT TOP 1 processText FROM dbo.implementationProcessDB WHERE ideaID = idm.AutoID ORDER BY AutoID DESC) AS processText, (SELECT TOP 1 Remark FROM ideaLog WHERE IdeaID=idm.AutoID ORDER BY AutoID DESC) AS [HOD_Remark] FROM dbo.ideaMaster idm LEFT OUTER JOIN dbo.HOD hod ON idm.EmpNo=hod.employeeID LEFT OUTER JOIN dbo.departmentMaster dpt ON idm.Department=dpt.AutoID LEFT OUTER JOIN  dbo.departmentMaster dm ON HOD.Department=dm.AutoID LEFT OUTER JOIN dbo.SBU_Master sb ON dpt.SBU=sb.AutoID LEFT OUTER JOIN dbo.SBU_Master sb1 ON hod.SBU=sb1.AutoID WHERE idm.IdeaDate BETWEEN try_CAST('" + fromDate.ToString("MM-dd-yyyy") + "' AS DATE) AND TRY_CAST('" + toDate.ToString("MM-dd-yyyy") + "' AS DATE)  AND idm.Department=" + ddlDepartment.SelectedValue.ToString() + " ORDER BY idm.IdeaDate DESC", con12);

                    da1.Fill(dt1);
                    gvMISReport.DataSource = dt1;
                    gvMISReport.DataBind();

                }
                if (ddlDepartment.SelectedValue.ToString() != "All" && ddlStatus.SelectedValue.ToString() != "All")
                {
                    SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
                    da1 = new SqlDataAdapter("SELECT idm.AutoID,idm.EmpNo as [EmpNo], hod.Name AS [Emp_Name],Dm.Department AS [Emp_Dept],sb1.SBU as [Emp_SBU],sb.SBU AS [SBU],hod.company [Employee_Type],CONVERT(nvarchar(10),idm.IdeaDate, 103) as [IdeaDate],dpt.Department as [Benefited_Area],idm.Idea as [Idea],idm.Benefit as [Benefit],idm.Filename as [Image], idm.Status,CASE WHEN idm.implementedDate ='1900-01-01 00:00:00.0000000' THEN null ELSE CONVERT(nvarchar(10),idm.implementedDate, 103) END AS [implementedDate], (SELECT SUBSTRING((SELECT  ',' +  HD.Name FROM assignDB AD LEFT OUTER JOIN dbo.HOD HD ON AD.representMobile =  HD.employeeID where ideaId = idm.AutoID FOR XML PATH('')), 2,10000) AS AssignTo) AS AssignTo, (SELECT TOP 1 processText FROM dbo.implementationProcessDB WHERE ideaID = idm.AutoID ORDER BY AutoID DESC) AS processText, (SELECT TOP 1 Remark FROM ideaLog WHERE IdeaID=idm.AutoID ORDER BY AutoID DESC) AS [HOD_Remark] FROM dbo.ideaMaster idm LEFT OUTER JOIN dbo.HOD hod ON idm.EmpNo=hod.employeeID LEFT OUTER JOIN dbo.departmentMaster dpt ON idm.Department=dpt.AutoID LEFT OUTER JOIN  dbo.departmentMaster dm ON HOD.Department=dm.AutoID LEFT OUTER JOIN dbo.SBU_Master sb ON dpt.SBU=sb.AutoID LEFT OUTER JOIN dbo.SBU_Master sb1 ON hod.SBU=sb1.AutoID WHERE CONVERT(Date,idm.IdeaDate) BETWEEN '" + txtDateFrom.Text + "' AND '" + txtDateTo.Text + "'  AND idm.Department=" + ddlDepartment.SelectedValue.ToString() + " AND idm.Status='" + ddlStatus.SelectedValue.ToString() + "' ORDER BY idm.IdeaDate DESC", con12);

                    da1.Fill(dt1);
                    gvMISReport.DataSource = dt1;
                    gvMISReport.DataBind();

                }
            }
            catch (Exception ex)
            {

            }
        }
        public DataTable GetideaMasterCounts(string FromDate, string ToDate, string SBU, string Dept_ID)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());
            DateTime fromDate = DateTime.ParseExact(txtDateFrom.Text, "dd-MM-yyyy", null);
            DateTime toDate = DateTime.ParseExact(txtDateTo.Text, "dd-MM-yyyy", null);
            DataTable Dt = new DataTable();
            SqlDataAdapter DA = new SqlDataAdapter();
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = connection;
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.CommandText = "usp_Get_ideaMaster_Counts";
            Cmd.Parameters.AddWithValue("@FromDate", fromDate);
            Cmd.Parameters.AddWithValue("@ToDate", toDate);
            Cmd.Parameters.AddWithValue("@SBU", SBU);
            Cmd.Parameters.AddWithValue("@Dept_ID", Dept_ID);
            DA = new SqlDataAdapter(Cmd);
            DA.Fill(Dt);
            return Dt;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtDateFrom.Text.ToString() == "" || txtDateTo.Text.ToString() == "")
            {

            }
            else
            {

                binddata();
                string FromDate = txtDateFrom.Text;
                string ToDate = txtDateTo.Text;
                string SBU = ddlSBU.SelectedValue;
                string Dept_ID = ddlDepartment.SelectedValue;

                DataTable Dt = GetideaMasterCounts(FromDate, ToDate, SBU, Dept_ID);
                lblIdeaSubmitted.Text = Dt.Rows[0]["TotalSubmitted"].ToString();
                lblPendingideas.Text = Dt.Rows[0]["TotalPending"].ToString();
                lblAssignedideas.Text = Dt.Rows[0]["TotalAssigned"].ToString();
                lblImplemetedideas.Text = Dt.Rows[0]["TotalImplemeted"].ToString();
                lblRejectedideas.Text = Dt.Rows[0]["TotalRejected"].ToString();
                lblApprovedideas.Text = Dt.Rows[0]["TotalAccepted"].ToString();
                lblIdeaGivenBy.Text = Dt.Rows[0]["IdeaGivenBy"].ToString();
                lblIdeaFor.Text = Dt.Rows[0]["IdeaGivenFor"].ToString();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }
        protected void gvMISReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMISReport.PageIndex = e.NewPageIndex;
            binddata();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {

            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=MasterReport.xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            gvMISReport.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        private void BindSBU()
        {
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
            if (ddlSBU.SelectedItem.Text == "All")
            {
                ddlDepartment.Visible = false;
                lblDepartment.Visible = false;
                ddlDepartment.Items.Clear();
                ddlDepartment.Items.Insert(0, new ListItem("All", "All"));
                ddlDepartment.SelectedIndex = 0;
            }
            else
            {

                ddlDepartment.Visible = true;
                lblDepartment.Visible = true;

                ddlDepartment.Items.Clear();
                Cmd = new SqlCommand("SP_Bind_Department", con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@SBU_ID", ddlSBU.SelectedValue);
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlDepartment.DataSource = dt;
                    ddlDepartment.DataTextField = "Department";
                    ddlDepartment.DataValueField = "AutoID";
                    ddlDepartment.DataBind();
                }
                ddlDepartment.Items.Insert(0, new ListItem("----Select Department----", ""));
                ddlDepartment.Items.Insert(1, new ListItem("All", "All"));
            }
        }

    }
}