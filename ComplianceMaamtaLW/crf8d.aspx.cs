using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ComplianceMaamtaLW
{
    public partial class crf8d : System.Web.UI.Page
    {
        string currentdate;
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "crf8";
             //   FieldFill();
                txtq41.Focus();
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(LiveServer);
            cn.Open();
            try
            {
                currentdate = DateTime.Now.ToString("dd-MM-yyyy");
                //if (DateTime.ParseExact(txtq43.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                //{
                //    showalert("Incorrect Date, Should be Less than Current Date!");
                //    txtq43.Focus();
                //}
                //else if (DateTime.ParseExact(txtq45.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                //{
                //    showalert("Incorrect Date, Should be Less than Current Date!");
                //    txtq45.Focus();
                //}
                //else
                //{
                MySqlCommand cmd = new MySqlCommand("update crf8 set q41='" + txtq41.SelectedValue + "',q42='" + txtq42.SelectedValue + "',q43='" + txtq43.Text + "',	q44='" + txtq44.InnerText + "',	q45='" + txtq45.Text + "',	q46='" + txtq46.InnerText + "',q47_01='" + txtq4701.Text + "',q47_02='" + txtq4702.Text + "',q47_03='" + txtq4703.Text + "',q47_04='" + txtq4704.Text + "',q48='" + txtq48.SelectedValue + "',q49_01='" + (chkQ49_01.Checked == true ? "1" : "") + "',q49_02='" + (chkQ49_02.Checked == true ? "2" : "") + "',q49_03='" + (chkQ49_03.Checked == true ? "3" : "") + "',q50='" + txtq50.SelectedValue + "',q51='" + txtq51.SelectedValue + "',q52='" + txtq52.SelectedValue + "', status='1'       where  id='" + Request.QueryString["FormID"] + "' and status=0", cn);
                cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Saved Successfully!');window.location.href='crf8a.aspx';", true);
                // }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtq43.Focus();
                }
                else
                {
                    showalert(ex.Message);
                }
            }
            finally
            {
                cn.Close();
            }
        }





        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where  id='" + Request.QueryString["FormID"] + "'  and status=0", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtq41.SelectedValue = dr["q41"].ToString();
                    txtq42.SelectedValue = dr["q42"].ToString();
                    txtq43.Text = dr["q43"].ToString();
                    txtq44.InnerText = dr["q44"].ToString();
                    txtq45.Text = dr["q45"].ToString();
                    txtq46.InnerText = dr["q46"].ToString();


                    txtq4701.Text = dr["q47_01"].ToString();
                    txtq4702.Text = dr["q47_02"].ToString();
                    txtq4703.Text = dr["q47_03"].ToString();
                    txtq4704.Text = dr["q47_04"].ToString();
                    txtq48.SelectedValue = dr["q48"].ToString();
                    chkQ49_01.Checked = (dr["q49_01"].Equals("1"));
                    chkQ49_02.Checked = (dr["q49_02"].Equals("2"));
                    chkQ49_03.Checked = (dr["q49_03"].Equals("3"));
                    txtq50.SelectedValue = dr["q50"].ToString();
                    txtq51.SelectedValue = dr["q51"].ToString();
                    txtq52.SelectedValue = dr["q52"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }


    }
}