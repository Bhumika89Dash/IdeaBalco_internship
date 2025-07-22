using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data;
using System.Data.SqlClient;

namespace IDEA_BALCO_1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {


        static string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();
        SqlConnection con = new SqlConnection(cs);

        protected void Page_Load(object sender, EventArgs e)
            {
            lblname.Text = Convert.ToString(Session["name"]);
            if (Convert.ToString(Session["empid"]) == "")
                {
                    Response.Redirect("Login.aspx");
                }

                if (!IsPostBack)
                {

                    if (Convert.ToString(Session["logintype"]) == "Employee")
                    {


                        NEW.Visible = true;
                        CON.Visible = false;
                        Admin.Visible = false;
                        HOD.Visible = false;

                    try
                    {
                        using (con = new SqlConnection(cs))
                        {

                            string query = "Select * from Logins where Username = '" + Convert.ToString(Session["empid"]) + "'";
                            SqlCommand CMD = new SqlCommand(query, con);
                            
                            con.Open();
                            SqlDataReader dr = CMD.ExecuteReader();
                            if (dr != null)
                            {
                                Admin.Visible = true;
                            }

                        }
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
                        using (con = new SqlConnection(cs))
                        {

                            string query = "select * from HOD where employeeId = '" + Convert.ToString(Session["empid"]) + "' and Type = 'HOD'";
                            SqlCommand CMD = new SqlCommand(query, con);
                            
                            con.Open();
                            SqlDataReader dr = CMD.ExecuteReader();
                            if (dr != null)
                            {
                                HOD.Visible = true;
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }




                   



                    }
                }
            }

            public void GetIPAddress()
            {
                string ipaddress;
                ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (ipaddress == "" || ipaddress == null)
                    ipaddress = Request.ServerVariables["REMOTE_ADDR"];
                lblmyip.Text = ipaddress;

            }
        }
    }
