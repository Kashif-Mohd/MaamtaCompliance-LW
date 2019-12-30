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
    public partial class updatecrf8c : System.Web.UI.Page
    {
        string currentdate;
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashCrf8";
                FieldFill();
                txtq31.Focus();
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void next_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(LiveServer);
            cn.Open();
            try
            {
                currentdate = DateTime.Now.ToString("dd-MM-yyyy");
                if (txtq34.Text == "5" && txtq35.Text != "88-88-8888" && (DateTime.ParseExact(txtq35.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq35.Focus();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("update crf8 set q31='" + txtq31.Text + "',q31_other='" + txtq31_other.InnerText + "',q32_1a='" + txtq32_1a.Text + "',		q32_2a='" + txtq32_2a.Text + "',	q32_3a='" + txtq32_3a.Text + "',	q32_4a='" + txtq32_4a.Text + "',	q32_5a='" + txtq32_5a.Text + "',	q32_6a='" + txtq32_6a.Text + "'     ,q33_01='" + (chk01.Checked == true ? "1" : "") + "',q33_02='" + (chk02.Checked == true ? "2" : "") + "',q33_03='" + (chk03.Checked == true ? "3" : "") + "',q33_04='" + (chk04.Checked == true ? "4" : "") + "',q33_05='" + (chk05.Checked == true ? "5" : "") + "',q33_06='" + (chk06.Checked == true ? "6" : "") + "',q33_07='" + (chk07.Checked == true ? "7" : "") + "',q33_08='" + (chk08.Checked == true ? "8" : "") + "',	        q33_other='" + txtq33_other.Text + "',	q34='" + txtq34.Text + "',	q34_other='" + txtq34_other.Text + "',	q35='" + txtq35.Text + "',	q36='" + txtq36.Text + "',	q37='" + txtq37.Text + "',q37_other='" + txtq37_other.Text + "',	q38='" + txtq38.Text + "',	q38_other='" + txtq38_other.InnerText + "',	q39='" + txtq39.Text + "',	q40='" + txtq40.InnerText + "'          where  id='" + Request.QueryString["FormID"] + "'", cn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("updatecrf8d.aspx?&FormID=" + Request.QueryString["FormID"] + "&Study_ID=" + Request.QueryString["Study_ID"]);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtq35.Focus();
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
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where  id='" + Request.QueryString["FormID"] + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtq31.Text = dr["q31"].ToString();
                    txtq31_other.InnerText = dr["q31_other"].ToString();
                    txtq32_1a.Text = dr["q32_1a"].ToString();
                    txtq32_2a.Text = dr["q32_2a"].ToString();
                    txtq32_3a.Text = dr["q32_3a"].ToString();
                    txtq32_4a.Text = dr["q32_4a"].ToString();
                    txtq32_5a.Text = dr["q32_5a"].ToString();
                    txtq32_6a.Text = dr["q32_6a"].ToString();

                    chk01.Checked = (dr["q33_01"].Equals("1"));
                    chk02.Checked = (dr["q33_02"].Equals("2"));
                    chk03.Checked = (dr["q33_03"].Equals("3"));
                    chk04.Checked = (dr["q33_04"].Equals("4"));
                    chk05.Checked = (dr["q33_05"].Equals("5"));
                    chk06.Checked = (dr["q33_06"].Equals("6"));
                    chk07.Checked = (dr["q33_07"].Equals("7"));
                    chk08.Checked = (dr["q33_08"].Equals("8"));

                    txtq33_other.Text = dr["q33_other"].ToString();
                    txtq34.Text = dr["q34"].ToString();
                    txtq34_other.Text = dr["q34_other"].ToString();
                    txtq35.Text = dr["q35"].ToString();
                    txtq36.Text = dr["q36"].ToString();
                    txtq37.Text = dr["q37"].ToString();
                    txtq37_other.Text = dr["q37_other"].ToString();
                    txtq38.Text = dr["q38"].ToString();
                    txtq38_other.InnerText = dr["q38_other"].ToString();
                    txtq39.Text = dr["q39"].ToString();
                    txtq40.InnerText = dr["q40"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }

    }
}