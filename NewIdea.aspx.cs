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
    public partial class NewIdea : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["empid"]) == "")
            {
                Response.Redirect("Login.aspx");
            }

            binddata();

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString();

            if (string.IsNullOrEmpty(cs))
            {
                throw new Exception("Connection string missing ");
            }

            int maxId = 0;
            string query = "SELECT TOP 1 AutoId FROM ideaMaster ORDER BY AutoId DESC";

            using (SqlConnection con = new SqlConnection(cs))
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);

                    maxId = Convert.ToInt32(cmd.ExecuteScalar());
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

            int autoid = maxId + 1;
            string department = ddlarea.SelectedValue.ToString();
            string idea = txtideas.Text;
            string empno = Convert.ToString(Session["empid"]);
            string Benefit = txtbenifits.Text;
            DateTime ideadate = DateTime.Now;
            string status = "Pending";
            string Filename = "";
            string implementedby = txtmobile.ToString();
            foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                if (filename != "")
                {
                    postedFile.SaveAs(Server.MapPath("idea_uploads//" + filename));
                    Filename = filename;
                }

            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    string query1 = "INSERT INTO IdeaMaster (autoid,department,idea,Benefit,filename,EmpNo,IdeaDate,Status,implementedby) VALUES (@autoid,@department,@Idea,@Benefit,@Filename,@empno,@ideadate,@status,@implementedby)";
                    SqlCommand cmd = new SqlCommand(query1, con);
                    cmd.Parameters.AddWithValue("@autoid", autoid);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@idea", idea);
                    cmd.Parameters.AddWithValue("@filename", Filename);
                    cmd.Parameters.AddWithValue("@Empno", empno);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@Benefit", Benefit);
                    cmd.Parameters.AddWithValue("@IdeaDate", ideadate);
                    cmd.Parameters.AddWithValue("@implementedby", implementedby);



                    int answer = cmd.ExecuteNonQuery(); //returns 1 with a row is inserted and 0 if not inserted 

                    if (answer > 0)
                    {
                        Response.Write("<script>alert('Inserted successfully!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('failed!!')</script>");
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
        void binddata()
        {
            SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());

            SqlDataAdapter da1 = new SqlDataAdapter("SELECT DISTINCT sb.SBU,dpt.SBU as [SBU_ID] FROM [b_ideaatbalco].[dbo].[SBU_Master] sb INNER JOIN [b_ideaatbalco].[dbo].[departmentMaster] dpt ON sb.AutoID=dpt.SBU WHERE dpt.SBU NOT IN (7,8,15,29,21,25,38) ORDER BY SBU", con12);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ddlsbu.DataSource = dt1;

            ddlsbu.DataBind();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsolutePath);
        }

        protected void ddlsbu_TextChanged(object sender, EventArgs e)
        {
            ddlarea.Items.Clear();
            SqlConnection con12 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["b_ideaatbalcoConnectionString"].ToString());

            SqlDataAdapter da = new SqlDataAdapter("Select * from departmentMaster where SBU='" + ddlsbu.SelectedValue + "' AND AutoID NOT IN (3,12,25,37,40,43,47,52,100,105,103,97,30,98,94,93)", con12);
            DataTable dt = new DataTable();
            da.Fill(dt);

            ddlarea.DataSource = dt;
            ddlarea.Items.Add("Select");
            ddlarea.DataBind();
        }
    }
}