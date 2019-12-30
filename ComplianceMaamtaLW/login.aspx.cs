using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace ComplianceMaamtaLW
{
    public partial class login : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSS"].ConnectionString;
        SqlDataReader dreader;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ComplianceMaamtaLW"] = null;
            Session["Role"] = null;            
            txtUserNme.Focus();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Loginn();
        }


        private void Loginn()
        {
            if (txtUserNme.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter User Name!')</script>");
                txtUserNme.Focus();
            }

            else if (txtPass.Text == "")
            {
                Response.Write("<script type=\"text/javascript\">alert('Please Enter Password!')</script>");
                txtPass.Focus();
            }
            else if (LogSeach() == false)
            {
                Response.Write("<script>alert('Incorrect User Name or Password')</script>");
                txtPass.Text = "";
                txtPass.Focus();
            }
            else
            {
                FindUserRole();
                Session["ComplianceMaamtaLW"] = txtUserNme.Text;
                if (Convert.ToString(Session["Role"]) == "admin_maamtaLW")
                {                   
                    Response.Redirect("dashEmptySachet.aspx");
                }
                else
                {
                    Response.Redirect("coredss.aspx");
                }
            }
        }



        public void FindUserRole()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from login where username='" + txtUserNme.Text + "' and password='"+txtPass.Text+"'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["Role"] = dr["role"].ToString();
            }
            con.Close();
        }



        public bool LogSeach()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("select * from login where password='" + txtPass.Text + "' and username='" + txtUserNme.Text + "'", con);
                dreader = cmd.ExecuteReader();
                if (dreader.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
                Response.Write("<script>window.location.href='Login.aspx';</script>");
            }
            finally
            {
                con.Close();
            }
            return false;
        }


    }
}