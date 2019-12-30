using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ComplianceMaamtaLW
{
    public partial class entryEmptySachet : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["WebForm"] = "entryEmptySachet";
            txtCheckRandid.Focus();
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        protected void checkButton_Click(object sender, EventArgs e)
        {
            if (txtCheckRandid.Text == "" || txtCheckRandid.Text.Length != 6)
            {
                showalert("Enter Complete Randomization ID");
                txtCheckRandid.Focus();
            }
            else
            {
                txtrandid.Text = txtCheckRandid.Text;

                Panel1.Visible = true;
                Panel2.Visible = false;

                if (StatusLWEnrolled() == true)
                {
                    LastDOV();
                    FieldFill();
                    txtStudyID.ReadOnly = true;
                    txtDSSID.ReadOnly = true;
                    txtWomanNm.ReadOnly = true;
                    txtDOB.ReadOnly = true;
                    txtLastDOV.ReadOnly = true;
                    txtDOV.Focus();
                }
                else
                {
                    txtStudyID.Focus();
                }
            }
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

                // Last Date of Visit:
                else if (DateTime.ParseExact(txtLastDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Last Date of Visit should be Less than Current Date");
                    txtLastDOV.Focus();
                }
                else if (DateTime.ParseExact(txtLastDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) < DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Last Date of Visit should be greater than Date of Birth");
                    txtLastDOV.Focus();
                }

                // Date of Visit:
                else if (DateTime.ParseExact(txtDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Date of Visit should be Less than Current Date");
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
                        if (StatusLWEnrolled() == false)
                        {
                            cn.Open();
                            SqlCommand cmd = new SqlCommand("insert into LW_info(random_id,study_id,dssid,woman_nm,dob,entry_date,entry_nm) values ('" + txtrandid.Text.ToUpper() + "','" + txtStudyID.Text.ToUpper() + "','" + txtDSSID.Text.ToUpper() + "','" + txtWomanNm.Text.ToUpper() + "','" + txtDOB.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", cn);
                            cmd.ExecuteNonQuery();
                            cn.Close();
                        }

                        if (SachetDataCheck() == false)
                        {
                            cn.Open();
                            SqlCommand cmd1 = new SqlCommand("insert into compliance_sachet(random_id,last_date_of_attempt,date_of_attempt,empty_sachet,actual_empty_sachet,remarks,entry_date,entry_nm) values ('" + txtrandid.Text.ToUpper() + "','" + txtLastDOV.Text + "','" + txtDOV.Text + "','" + txtEmptySac.Text + "','" + txtActualEmptySac.Text + "','" + txtremarks.InnerText.ToUpper() + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", cn);
                            cmd1.ExecuteNonQuery();
                            cn.Close();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Saved Successfully!');window.location.href='entryEmptySachet.aspx';", true);
                        }

                    }

                    catch (Exception ex)
                    {
                        if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                        {
                            showalert("Incorrect Date Format!");
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
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
            }

        }



        public bool StatusLWEnrolled()
        {
            bool exist = false;
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from LW_info where random_id='" + txtrandid.Text.ToUpper() + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }


        public bool SachetDataCheck()
        {
            bool exist = false;
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from compliance_sachet where random_id='" + txtrandid.Text.ToUpper() + "' and date_of_attempt='" + txtDOV.Text + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                    Response.Redirect("entryEmptySachet.aspx");
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }



        public void LastDOV()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select date_of_attempt from compliance_sachet where random_id='" + txtrandid.Text.ToUpper() + "' and id=(select max(id) from compliance_sachet where random_id='" + txtrandid.Text.ToUpper() + "')", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtLastDOV.Text = dr["date_of_attempt"].ToString();
                }
            }
            finally
            {
                con.Close();
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



    }
}