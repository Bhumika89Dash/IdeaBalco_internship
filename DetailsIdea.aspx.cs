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
    public partial class DetailsIdea : System.Web.UI.Page
    {
        static string cs_m = System.Configuration.ConfigurationManager.ConnectionStrings["kioskConnectionString"].ConnectionString;
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                string trid = Convert.ToString(Session["TRID"]);
                if (string.IsNullOrEmpty(trid)) return;
                string empNo = "";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // 1. Get idea details
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ideaMaster WHERE AutoID =" + Convert.ToInt32(trid) + "", con);
                    SqlDataReader reader1 = cmd.ExecuteReader();

                    string departmentId = "";

                    if (reader1.Read())
                    {
                        lblIdeaID.Text = reader1["AutoID"].ToString();
                        lblIdea.Text = reader1["Idea"].ToString();
                        lblBenefit.Text = reader1["Benefit"].ToString();
                        lblDate.Text = Convert.ToDateTime(reader1["IdeaDate"]).ToString("MMMM dd, yyyy");
                        lblStatus.Text = reader1["Status"].ToString();

                        empNo = reader1["EmpNo"].ToString();
                        departmentId = reader1["Department"].ToString();
                    }
                    reader1.Close();
                    //2. get employee name 
                    try
                    {
                        if (empNo.Length == 8)
                        {
                            full_name(empNo);
                        }
                        else
                        {
                            SqlCommand cmd3 = new SqlCommand("SELECT Name FROM AppUsers WHERE EmployeeID = @EmpNo", con);
                            cmd3.Parameters.AddWithValue("@EmpNo", empNo);
                            object nameResult = cmd3.ExecuteScalar();
                            lblSubmittedBy.Text = nameResult?.ToString() ?? "-";
                        }
                    }
                    catch
                    {
                        lblSubmittedBy.Text = "-";
                    }



                    // 3. Get Department Name
                    SqlCommand cmd4 = new SqlCommand("SELECT Department FROM departmentMaster WHERE AutoID = @DeptID", con);
                    cmd4.Parameters.AddWithValue("@DeptID", departmentId);

                    object deptResult = cmd4.ExecuteScalar();
                    lblDepartment.Text = deptResult?.ToString() ?? "-";

                    // 4. Get AssignedTo Names
                    SqlCommand cmd5 = new SqlCommand(@"
                        SELECT h.Name 
                        FROM assignDB a 
                        INNER JOIN HOD h ON a.representMobile = h.employeeID 
                        WHERE a.ideaId = @IdeaID", con);
                    cmd5.Parameters.AddWithValue("@IdeaID", trid);

                    SqlDataReader rdrAssign = cmd5.ExecuteReader();
                    string assignedTo = "";
                    while (rdrAssign.Read())
                    {
                        if (string.IsNullOrEmpty(assignedTo))
                            assignedTo = rdrAssign["Name"].ToString();
                        else
                            assignedTo += "/" + rdrAssign["Name"].ToString();
                    }
                    rdrAssign.Close();

                    lblAssignedTo.Text = assignedTo;
                }


            }
        }
        protected void full_name(string empNo)
        {
            using (SqlConnection con = new SqlConnection(cs_m))
            {
                try
                {
                    string fullEmpID = "BAL" + empNo;
                    SqlCommand cmd2 = new SqlCommand("SELECT full_name FROM Masterdata_HR WHERE employee_id = @EmpID", con);
                    cmd2.Parameters.AddWithValue("@EmpID", fullEmpID);

                    object result = cmd2.ExecuteScalar();
                    if (result != null)
                    {
                        lblSubmittedBy.Text = result.ToString();
                    }
                }
                catch (SqlException ex)
                {

                }

            }

        }
    }
}