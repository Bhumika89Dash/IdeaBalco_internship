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
    public partial class Home : System.Web.UI.Page
    {
        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                using (con)
                {

                    int mycnt = 0; int tcnt = 0; int pcnt = 0; int icnt = 0;
                    // mycnt = number of ideas given by me in ideaMasters table 
                    try
                    {
                        con.Open();
                        string query = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                        SqlCommand getMaxCmd = new SqlCommand(query, con);
                        object ideaObj = getMaxCmd.ExecuteScalar();
                        mycnt = ideaObj != DBNull.Value ? Convert.ToInt32(ideaObj) : 0;

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    //tcnt is no. of ideas given in assignDB 
                    try
                    {

                        con.Open();
                        string query = "select count(*) from assignDB where representMobile='" + Convert.ToString(Session["empid"]) + "'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                        SqlCommand getMaxCmd = new SqlCommand(query, con);
                        object tcount = getMaxCmd.ExecuteScalar();
                        tcnt = tcount != DBNull.Value ? Convert.ToInt32(tcount) : 0;

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    //counting no of pending records in the assigndb
                    try
                    {

                        con.Open();
                        string query1 = "select count(*) from assignDB where representMobile='" + Convert.ToString(Session["empid"]) + "' and ideaStatus ='Pending'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                        SqlCommand getMaxCmd = new SqlCommand(query1, con);
                        object pcount = getMaxCmd.ExecuteScalar();
                        pcnt = pcount != DBNull.Value ? Convert.ToInt32(pcount) : 0;

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }

                    //counting no of implemented records in the assigndb
                    try
                    {


                        con.Open();
                        string query2 = "select count(*) from assignDB where representMobile='" + Convert.ToString(Session["empid"]) + "' and ideaStatus ='Implemented'"; // "+ Convert.ToString(Session["empid"]) + " //12676 =0   //10999=2

                        SqlCommand getMaxCmd = new SqlCommand(query2, con);
                        object icount = getMaxCmd.ExecuteScalar();
                        icnt = icount != DBNull.Value ? Convert.ToInt32(icount) : 0;

                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    lblMySubmitted.Text = Convert.ToString(mycnt);
                    lblAssigned.Text = Convert.ToString(tcnt);
                    lblPending.Text = Convert.ToString(pcnt);
                    lblImplemented.Text = Convert.ToString(icnt);

                    if (Convert.ToString(Session["empid"]) != "Employee")
                    {
                        string query = "select * from LOGINS where USERNAME='" + Convert.ToString(Session["empid"]) + "'"; //" + Convert.ToString(Session["empid"]) + " //11162
                        con.Open();
                        SqlDataAdapter da2 = new SqlDataAdapter(query, con);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        con.Close();
                        if (dt2.Rows.Count > 0)
                        {
                            int apcnt = 0, aacnt = 0, ancnt = 0, aicnt = 0, arcnt = 0;
                            Admin.Visible = true;
                            try
                            {



                                con.Open();
                                string query1 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Pending'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                                SqlCommand getMaxCmd = new SqlCommand(query1, con);
                                object apcntObj = getMaxCmd.ExecuteScalar();
                                apcnt = apcntObj != DBNull.Value ? Convert.ToInt32(apcntObj) : 0;

                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }
                            try
                            {



                                con.Open();
                                string query2 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Accepted'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                                SqlCommand getMaxCmd = new SqlCommand(query2, con);
                                object aacntObj = getMaxCmd.ExecuteScalar();
                                aacnt = aacntObj != DBNull.Value ? Convert.ToInt32(aacntObj) : 0;

                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }
                            try
                            {



                                con.Open();
                                string query3 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Assigned'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                                SqlCommand getMaxCmd = new SqlCommand(query3, con);
                                object ancntObj = getMaxCmd.ExecuteScalar();
                                ancnt = ancntObj != DBNull.Value ? Convert.ToInt32(ancntObj) : 0;

                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }
                            try
                            {


                                con.Open();
                                string query6 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Implemented'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                                SqlCommand getMaxCmd = new SqlCommand(query6, con);
                                object aicntObj = getMaxCmd.ExecuteScalar();
                                aicnt = aicntObj != DBNull.Value ? Convert.ToInt32(aicntObj) : 0;

                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }
                            try
                            {
                                con.Open();
                                string query5 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Rejected'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                                SqlCommand getMaxCmd = new SqlCommand(query5, con);
                                object arcntObj = getMaxCmd.ExecuteScalar();
                                arcnt = arcntObj != DBNull.Value ? Convert.ToInt32(arcntObj) : 0;

                            }
                            catch (SqlException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                con.Close();
                            }
                            Label2.Text = Convert.ToString(apcnt);
                            Label3.Text = Convert.ToString(aacnt);
                            Label5.Text = Convert.ToString(ancnt);
                            Label6.Text = Convert.ToString(aicnt);
                            Label7.Text = Convert.ToString(arcnt);
                        }



                    }












                    string query4 = "select * from HOD where EmployeeID='" + Convert.ToString(Session["empid"]) + "' and Type ='HOD'"; //" + Convert.ToString(Session["empid"]) + " //11162

                    SqlDataAdapter da1 = new SqlDataAdapter(query4, con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        int hpcnt = 0, hacnt = 0, hncnt = 0, hicnt = 0, hrcnt = 0;
                        HOD.Visible = true;
                        try
                        {


                            con.Open();
                            string query1 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Pending'"; // "+ Convert.ToString(Session["empid"]) + " //11831

                            SqlCommand getMaxCmd = new SqlCommand(query1, con);
                            object hpcntObj = getMaxCmd.ExecuteScalar();
                            hpcnt = hpcntObj != DBNull.Value ? Convert.ToInt32(hpcntObj) : 0;

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        try
                        {


                            con.Open();
                            string query2 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Accepted'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                            SqlCommand getMaxCmd = new SqlCommand(query2, con);
                            object hacntObj = getMaxCmd.ExecuteScalar();
                            hacnt = hacntObj != DBNull.Value ? Convert.ToInt32(hacntObj) : 0;

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        try
                        {



                            con.Open();
                            string query1 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Assigned'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                            SqlCommand getMaxCmd = new SqlCommand(query1, con);
                            object hncntObj = getMaxCmd.ExecuteScalar();
                            hncnt = hncntObj != DBNull.Value ? Convert.ToInt32(hncntObj) : 0;

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        try
                        {


                            con.Open();
                            string query1 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Implemented'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                            SqlCommand getMaxCmd = new SqlCommand(query1, con);
                            object hicntObj = getMaxCmd.ExecuteScalar();
                            hicnt = hicntObj != DBNull.Value ? Convert.ToInt32(hicntObj) : 0;

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        try
                        {



                            con.Open();
                            string query1 = "select count(idea) from ideaMaster where empno='" + Convert.ToString(Session["empid"]) + "' and status='Rejected'"; // "+ Convert.ToString(Session["empid"]) + " //12676

                            SqlCommand getMaxCmd = new SqlCommand(query1, con);
                            object hrcntObj = getMaxCmd.ExecuteScalar();
                            hrcnt = hrcntObj != DBNull.Value ? Convert.ToInt32(hrcntObj) : 0;

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }
                        Label9.Text = Convert.ToString(hpcnt);
                        Label10.Text = Convert.ToString(hacnt);
                        Label11.Text = Convert.ToString(hncnt);
                        Label12.Text = Convert.ToString(hicnt);
                        Label13.Text = Convert.ToString(hrcnt);
                    }
                }



            }
        }
    }
}