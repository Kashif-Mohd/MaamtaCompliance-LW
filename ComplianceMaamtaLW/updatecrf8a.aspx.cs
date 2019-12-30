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
    public partial class updatecrf8a : System.Web.UI.Page
    {
        string currentdate;

        //MySQL 
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashCrf8";
                FieldFill();
                txtq2.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }










        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where id='" + Request.QueryString["FormID"] + "'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtq2.Text = dr["q2"].ToString();
                    txtq3.Text = dr["q3"].ToString();
                    txtq4.Text = dr["q4"].ToString();
                    txtq5.Text = dr["q5"].ToString();

                    txtStudyID.Text = dr["study_id"].ToString();
                    txtq6WomanNm.Text = dr["q6"].ToString();
                    txtq7HusbandNm.Text = dr["q7"].ToString();
                    txtdssidQ8toQ13.Text = dr["dssid"].ToString();
                    txtq14.Text = dr["q14"].ToString();
                    txtq16.Text = dr["q16"].ToString();

                    txtq17.Text = dr["q17"].ToString();
                    txtq18.Text = dr["q18"].ToString();
                    txtq19.Text = dr["q19"].ToString();
                    txtq20.Text = dr["q20"].ToString();
                    txtq21.Text = dr["q21"].ToString();
                    txtq22.Text = dr["q22"].ToString();
                    txtq23.Text = dr["q23"].ToString();
                    //txtq24.Text = dr["q24"].ToString();
                    //txtq25.Text = dr["q25"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }














        protected void next_Click(object sender, EventArgs e)
        {
            currentdate = DateTime.Now.ToString("dd-MM-yyyy");

            MySqlConnection cn = new MySqlConnection(LiveServer);
            cn.Open();
            try
            {
                // Q2:
                if (DateTime.ParseExact(txtq2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq2.Focus();
                }
                else if (DateTime.ParseExact(txtq14.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq2.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq14.Text + ")");
                    txtq2.Focus();
                }

                // Q16:
                else if (DateTime.ParseExact(txtq16.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq16.Focus();
                }
                else if (DateTime.ParseExact(txtq14.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq16.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq14.Text + ")");
                    txtq16.Focus();
                }

                // Q18:
                else if (txtq18.Text != "88-88-8888" && (DateTime.ParseExact(txtq18.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq18.Focus();
                }
                else if (txtq18.Text != "88-88-8888" && (DateTime.ParseExact(txtq16.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq18.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Should be Greater than Q16 Date (" + txtq16.Text + ")");
                    txtq18.Focus();
                }

                // Q20:
                else if (DateTime.ParseExact(txtq20.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq20.Focus();
                }
                else if (DateTime.ParseExact(txtq14.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq20.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq14.Text + ")");
                    txtq20.Focus();
                }

                // Q22:
                else if (DateTime.ParseExact(txtq22.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtq22.Focus();
                }
                else if (DateTime.ParseExact(txtq14.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtq22.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq14.Text + ")");
                    txtq22.Focus();
                }

                else
                {

                    int Age = 0;
                    MySqlCommand cmd_DOB = new MySqlCommand("select a.lw_crf_3a_4,b.lw_crf2_21  from form_crf_3a as a left join form_crf_2 as b on a.assis_id=b.assis_id where a.lw_crf_3a_4='" + txtStudyID.Text + "'", cn);
                    MySqlDataReader dr = cmd_DOB.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        Age = Convert.ToInt32((Convert.ToDateTime(txtq16.Text) - Convert.ToDateTime(dr["lw_crf2_21"].ToString())).TotalDays);
                    }
                    cn.Close();


                    string TimeQ25 = Convert.ToString(Convert.ToDateTime(txtq23.Text).AddMinutes(10).TimeOfDay);
                    TimeQ25 = TimeQ25.Substring(0, 5);











                    cn.Open();
                    MySqlCommand cmd = new MySqlCommand("update crf8 set q2='" + txtq2.Text + "'	,q3='" + txtq3.Text + "'	,q4='" + txtq4.Text + "'	,q5='" + txtq5.Text + "'	,q6='" + txtq6WomanNm.Text + "'	,q7='" + txtq7HusbandNm.Text + "'	,dssid='" + txtdssidQ8toQ13.Text + "'	,q14='" + txtq14.Text + "',q15='" + Age + "'		,q17='" + txtq17.Text + "'	,q18='" + txtq18.Text + "'	,q19='" + txtq19.Text + "'	,q20='" + txtq20.Text + "'	,q21='" + txtq21.Text + "'	,q22='" + txtq22.Text + "'	,q23='" + txtq23.Text + "'	,q24='" + txtq22.Text + "'	,q25='" + TimeQ25 + "', entry_dt='" + DateTime.Now.ToString("dd-MM-yyyy") + "', entry_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where  id='" + Request.QueryString["FormID"] + "'", cn);
                    cmd.ExecuteNonQuery();

                    cn.Close();
                    Response.Redirect("updatecrf8b.aspx?&FormID=" + Request.QueryString["FormID"] + "&Study_ID=" + txtStudyID.Text.ToUpper());
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtq16.Focus();
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









    }
}