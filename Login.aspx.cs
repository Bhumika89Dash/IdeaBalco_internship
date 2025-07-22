using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;


using System.Web.UI.WebControls;

namespace IDEA_BALCO_1
{
    public partial class Login : System.Web.UI.Page
    {
        string empid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]).Trim() != "")
            {
                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();
                if (Request.Cookies["ASP.NET_SessionId"] != null)
                {
                    Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                    Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                }



                //TextBox1.Attributes.Add("autocomplete", "off");
            }
            if (!IsPostBack)
            {
                txtUserId.Attributes.Add("autocomplete", "off");
                txtPassword.Attributes.Add("autocomplete", "off");
                txtUserId.Focus();



            }
        }
        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string Path = string.Empty;
            Path = Request.QueryString["Page"];
            try
            {

                if (txtUserId.Text.Trim() != "")
                {
                    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["kioskConnectionString"].ToString());
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("select * from AD_Memberships where MembershipProvider = 'BALCO'", con);
                    DataSet vdomain = new DataSet();
                    da.Fill(vdomain);


                    var vdomain1 = vdomain.Tables[0].Rows[0]["Domain"].ToString();

                    PrincipalContext MyDomain = new PrincipalContext(ContextType.Domain, vdomain.Tables[0].Rows[0]["Domain"].ToString(), null, ContextOptions.SimpleBind | ContextOptions.Sealing, vdomain.Tables[0].Rows[0]["ConnectionUsername"].ToString(), vdomain.Tables[0].Rows[0]["ConnectionPassword"].ToString());
                    if (MyDomain.ValidateCredentials(txtUserId.Text, txtPassword.Text))
                    {
                        if (txtUserId.Text.Length == 8)
                        {
                            Session["empid"] = txtUserId.Text.Trim();
                        }
                        else if (txtUserId.Text.Length == 9)
                        {
                            Session["empid"] = txtUserId.Text.Trim();
                        }
                        else if (txtUserId.Text.Length == 5)
                        {

                            Session["empid"] = "BAL" + txtUserId.Text.TrimEnd().TrimStart();
                        }
                        else
                        {
                            Session["empid"] = txtUserId.Text.Trim();
                        }

                        // matching the text user id with the database and finding a match 




                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Masterdata_Darwinbox WHERE employee_id ='" + txtUserId.Text + "' ", con);
                        // through dataset 
                        DataSet ds = new DataSet();
                        sda.Fill(ds);

                        // getting the data 
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (row != null)
                            {
                                string cn = row["full_name"].ToString();
                                string email = row["company_email_id"].ToString();

                                Session["name"] = cn.Trim();
                                Session["logintype"] = "Employee";
                                FormsAuthentication.RedirectFromLoginPage(txtUserId.Text, false);
                                FormsAuthenticationTicket fat = new FormsAuthenticationTicket(1, txtUserId.Text, DateTime.Now, DateTime.Now.AddMinutes(20), false, FormsAuthentication.FormsCookiePath);

                                empid = Session["empid"].ToString();
                                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat)));
                                if (Path == null)
                                {

                                    Response.Redirect("Home.aspx");
                                }
                                else
                                {
                                    Response.Redirect(Path);
                                }
                            }

                        }
                    }
                }
                else
                {

                    Session["empid"] = txtUserId.Text;
                    empid = Session["empid"].ToString();
                    lblErr.Text = "Invalid Username or Password !";
                }
            }
            catch (Exception ex)
            {
                lblErr.Text = ex.Message;

            }


        }






    }
}