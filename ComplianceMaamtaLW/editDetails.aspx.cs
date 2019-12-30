using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ComplianceMaamtaLW
{
    public partial class editDetails : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "dashEmptySachet";

            if (!IsPostBack)
            {
                if (Session["editDetails_RandId"] != null)
                {
                    txtrandid.Text = Convert.ToString(Session["editDetails_RandId"]);
                    FieldFill();
                    FieldCompliance();
                }
                else
                {
                    Response.Redirect("dashEmptySachet.aspx");
                }
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtStudyID.Text == "" || txtStudyID.Text.Length < 5)
                {
                    showalert("Enter complete Study ID");
                    txtStudyID.Focus();
                }
                else if (txtDSSID.Text == "" || txtDSSID.Text.Length < 11)
                {
                    showalert("Enter Complete DSSID");
                    txtDSSID.Focus();
                }
                else if (txtWomanNm.Text == "")
                {
                    showalert("Enter Woman Name");
                    txtWomanNm.Focus();
                }

                else if (txtDOB.Text == "" || txtDOB.Text == "__/__/____")
                {
                    showalert("Enter Date of Birth");
                    txtDOB.Focus();
                }
                else if (txtLastDOV.Text == "" || txtLastDOV.Text == "__/__/____")
                {
                    showalert("Enter Last Date of Visit");
                    txtLastDOV.Focus();
                }
                else if (txtDOV.Text == "" || txtDOV.Text == "__/__/____")
                {
                    showalert("Enter Date of Visit");
                    txtDOV.Focus();
                }

                else if (txtEmptySac.Text == "" || txtEmptySac.Text.Length < 2)
                {
                    showalert("Enter Maamta Empty Sachet, 2 digit long!");
                    txtEmptySac.Focus();
                }
                else if (txtActualEmptySac.Text == "" || txtActualEmptySac.Text.Length < 2)
                {
                    showalert("Enter Maamta Actual Empty Sachet, 2 digit long!");
                    txtActualEmptySac.Focus();
                }

                else if (DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Date of Birth should be Less than Current Date");
                    txtDOB.Focus();
                }
                else if (DateTime.ParseExact(txtDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Date of Visit should be Less than Current Date");
                    txtDOV.Focus();
                }
                else if (DateTime.ParseExact(txtDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Date of Visit should be greater than Date of Birth");
                    txtDOV.Focus();
                }
                else if (txtLastDOV.Text != "" && ((DateTime.ParseExact(txtDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(txtLastDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))))
                {
                    showalert("Date of Visit should be greater than Last Date of Visit");
                    txtDOV.Focus();
                }
                else
                {
                    SqlConnection cn = new SqlConnection(ConDataBase);
                    try
                    {
                        cn.Open();
                        SqlCommand cmd = new SqlCommand("update LW_info set study_id='" + txtStudyID.Text.ToUpper() + "',dssid='" + txtDSSID.Text.ToUpper() + "',woman_nm='" + txtWomanNm.Text.ToUpper() + "',dob='" + txtDOB.Text + "',update_date='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "',update_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where random_id ='" + txtrandid.Text.ToUpper() + "' ", cn);
                        cmd.ExecuteNonQuery();
                        cn.Close();


                        cn.Open();
                        SqlCommand cmd1 = new SqlCommand("update compliance_sachet set  last_date_of_attempt='" + txtLastDOV.Text + "', date_of_attempt='" + txtDOV.Text + "',empty_sachet='" + txtEmptySac.Text + "', actual_empty_sachet='" + txtActualEmptySac.Text + "',update_date='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "',remarks='" + txtremarks.InnerText.ToUpper() + "',update_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where id ='" + Convert.ToString(Session["editDetails_Id"]) + "'", cn);
                        cmd1.ExecuteNonQuery();
                        cn.Close();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Updated Successfully!');window.location.href='dashEmptySachet.aspx';", true);


                    }

                    catch (Exception ex)
                    {
                        showalert(ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
            }

        }













        public void FieldFill()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from LW_info where random_id='" + txtrandid.Text.ToUpper() + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtStudyID.Text = dr["study_id"].ToString();
                    txtDSSID.Text = dr["dssid"].ToString();
                    txtWomanNm.Text = dr["woman_nm"].ToString();
                    txtDOB.Text = dr["dob"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }

        public void FieldCompliance()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from compliance_sachet where id='" + Convert.ToString(Session["editDetails_Id"]) + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtLastDOV.Text = dr["Last_date_of_attempt"].ToString();
                    txtDOV.Text = dr["date_of_attempt"].ToString();
                    txtEmptySac.Text = dr["empty_sachet"].ToString();
                    txtActualEmptySac.Text = dr["actual_empty_sachet"].ToString();
                    txtremarks.InnerText = dr["remarks"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }



    }
}