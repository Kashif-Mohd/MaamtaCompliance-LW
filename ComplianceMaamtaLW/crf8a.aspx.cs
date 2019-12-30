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
    public partial class crf8a : System.Web.UI.Page
    {
        string currentdate;
        static string LW_TRIAL_FormID;
        static string LW_TRIAL_DOB;

        //MySQL 
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "crf8";
                txtdssid.Focus();                
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        // Check Button:

        protected void checkButton_Click(object sender, EventArgs e)
        {
            // Q16:
            try
            {
                currentdate = DateTime.Now.ToString("dd-MM-yyyy");
                if (txtQ16DateStart.Text == "" || txtQ16DateStart.Text == "__-__-____")
                {
                    showalert("Enter Start Date Q16!");
                    txtQ16DateStart.Focus();
                }
                else if (DateTime.ParseExact(txtQ16DateStart.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Should be Less than Current Date!");
                    txtQ16DateStart.Focus();
                }
                else if (DateTime.ParseExact(txtq14.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtQ16DateStart.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Incorrect Date, Should be Greater than Date of Enrollment (" + txtq14.Text + ")");
                    txtQ16DateStart.Focus();
                }
                else
                {
                    if (CompleteForm() == false)
                    {
                        Panel1.Visible = true;
                        txtStudyID.ReadOnly = true;
                        txtQ16DateStart.ReadOnly = true;
                        txtq16.Text = txtQ16DateStart.Text;
                        btnchk.Visible = false;
                        FieldFill();
                        txtq4.Focus();
                    }
                    else
                    {
                        txtQ16DateStart.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtQ16DateStart.Focus();
                }
                else
                {
                    showalert(ex.Message);
                }
            }
        }




        public bool CompleteForm()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where study_id='" + txtStudyID.Text + "' and q16='" + txtQ16DateStart.Text + "' and status='1'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Already Exist!')", true);
                    exist = true;
                    txtQ16DateStart.Focus();
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }



        public void FieldFill()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where study_id='" + txtStudyID.Text + "' and q16='" + txtQ16DateStart.Text + "' and status='0'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    txtq2.Text = dr["q2"].ToString();
                    txtq3.Text = dr["q3"].ToString();
                    txtq4.Text = dr["q4"].ToString();
                    txtq5.Text = dr["q5"].ToString();
                   // txtq15.Text = dr["q15"].ToString();
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




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtdssid.Text == "" || txtdssid.Text.Length < 5)
            {
                showalert("Enter DSSID, minimun length should be 5");
                txtdssid.Focus();
            }
            else
            {
                ShowData();
                txtdssid.Focus();
            }
        }


        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select a.study_id,a.lw_crf1_09 as woman_nm, a.lw_crf1_10  as husband_nm,a.dssid, a.lw_crf_3a_2 as DOE,b.lw_crf2_21 as DOB, a.lw_crf_3a_18 as random_id,a.lw_crf_3a_19 as ARM		 from view_crf3a as a left join view_crf2 as b on a.assis_id=b.assis_id     where a.dssid like '%" + txtdssid.Text + "%'", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + ex.Message + "')</script>");
            }
            finally
            {
                con.Close();
            }
        }


        protected void next_Click(object sender, EventArgs e)
        {
            LW_TRIAL_FormID = null;
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
                    //FindFormID();

                    string TimeQ25 = Convert.ToString(Convert.ToDateTime(txtq23.Text).AddMinutes(10).TimeOfDay);
                    TimeQ25 = TimeQ25.Substring(0, 5);

                    int Age = Convert.ToInt32((Convert.ToDateTime(txtq16.Text) - Convert.ToDateTime(LW_TRIAL_DOB)).TotalDays);


                    if (InCompleteForm() == false)
                    {

                        MySqlCommand cmd = new MySqlCommand("insert into crf8(study_id,q2 ,q3 ,q4	,q5	,q6	,q7	,dssid	,q14	,q15	,q16	,q17	,q18	,q19	,q20	,q21	,q22	,q23	,q24	, q25, status, entry_dt, entry_nm) values ('" + txtStudyID.Text + "','" + txtq2.Text + "','" + txtq3.Text + "','" + txtq4.Text.ToUpper() + "','" + txtq5.Text.ToUpper() + "','" + txtq6WomanNm.Text.ToUpper() + "','" + txtq7HusbandNm.Text.ToUpper() + "','" + txtdssidQ8toQ13.Text.ToUpper() + "','" + txtq14.Text + "','" + Age + "','" + txtq16.Text + "','" + txtq17.Text + "','" + txtq18.Text + "' ,'" + txtq19.Text + "','" + txtq20.Text + "','" + txtq21.Text + "' ,'" + txtq22.Text + "','" + txtq23.Text + "','" + txtq22.Text + "' ,'" + TimeQ25 + "','" + "0" + "','" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", cn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MySqlCommand cmd = new MySqlCommand("update crf8 set q2='" + txtq2.Text + "'	,q3='" + txtq3.Text + "'	,q4='" + txtq4.Text + "'	,q5='" + txtq5.Text + "'	,q6='" + txtq6WomanNm.Text + "'	,q7='" + txtq7HusbandNm.Text + "'	,dssid='" + txtdssidQ8toQ13.Text + "'	,q14='" + txtq14.Text + "'	,q15='" + Age + "'	,q16='" + txtq16.Text + "'	,q17='" + txtq17.Text + "'	,q18='" + txtq18.Text + "'	,q19='" + txtq19.Text + "'	,q20='" + txtq20.Text + "'	,q21='" + txtq21.Text + "'	,q22='" + txtq22.Text + "'	,q23='" + txtq23.Text + "'	,q24='" + txtq22.Text + "'	,q25='" + TimeQ25 + "', entry_dt='" + DateTime.Now.ToString("dd-MM-yyyy") + "', entry_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where  study_id='" + txtStudyID.Text + "' and q16='" + txtq16.Text + "'  and status=0", cn);
                        cmd.ExecuteNonQuery();
                    }
                    InCompleteForm();
                    cn.Close();
                    Response.Redirect("crf8b.aspx?&FormID=" + LW_TRIAL_FormID + "&Study_ID=" + txtStudyID.Text.ToUpper());
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











        public bool InCompleteForm()
        {
            bool exist = false;
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                MySqlCommand cmd = new MySqlCommand("select * from crf8 where study_id='" + txtStudyID.Text + "' and q16='" + txtQ16DateStart.Text + "' and status='0'", con);
                con.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    LW_TRIAL_FormID = dr["id"].ToString();
                    exist = true;
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }



        protected void Link_OpenForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "admin_maamtaLW" || Convert.ToString(Session["Role"]) == "super_admin")
            {
                LW_TRIAL_DOB = null;
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                txtStudyID.Text = commandArgs[0];
                txtdssidQ8toQ13.Text = commandArgs[1];
                txtq6WomanNm.Text = commandArgs[2];
                txtq7HusbandNm.Text = commandArgs[3];
                txtq14.Text = commandArgs[4];
                LW_TRIAL_DOB = commandArgs[5];

                forSearch.Visible = false;
                forEntry.Visible = true;

                txtQ16DateStart.Focus();
            }
            else
            {
                showalert("Only Admin has right to update details");
            }
        }



    }
}