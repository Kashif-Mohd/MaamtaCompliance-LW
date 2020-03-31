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
    public partial class second_updatecrf11d : System.Web.UI.Page
    {
        static string forUpdateRec;
        static string Q70Records;

        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FieldFill();

                GridView();
                countQ70Records();
                Session["WebForm"] = "second_crf11";
                chk01.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            countQ70Records();
            SqlConnection cn = new SqlConnection(ConDataBase);
            cn.Open();
            try
            {
                if (Q70Records == "0" && txtq69.Text == "1")
                {
                    GridView();
                    showalert("Please add Medicine Records");
                    txtq69.Focus();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update second_crf11 set lw_crf11_64_01='" + (chk01.Checked == true ? "1" : "") + "',lw_crf11_64_02='" + (chk02.Checked == true ? "2" : "") + "',lw_crf11_64_03='" + (chk03.Checked == true ? "3" : "") + "', lw_crf11_64_04='" + (chk04.Checked == true ? "4" : "") + "', lw_crf11_64_05='" + (chk05.Checked == true ? "5" : "") + "', lw_crf11_64_06='" + (chk06.Checked == true ? "6" : "") + "', lw_crf11_64_07='" + (chk07.Checked == true ? "7" : "") + "', lw_crf11_64_07x1='" + txtq64a.Text + "', lw_crf11_64_07x2='" + txtq64b.Text + "', lw_crf11_64_07x3='" + txtq64c.Text + "', lw_crf11_64_07x4='" + txtq64d.Text + "', lw_crf11_65='" + txtq65.Text + "', lw_crf11_66='" + txtq66.Text + "', lw_crf11_67='" + txtq67.Text + "',lw_crf11_68a='" + txtq68a.Text + "',lw_crf11_68b='" + txtq68b.Text + "', lw_crf11_69='" + txtq69.Text + "', lw_crf11_71='" + txtq71.Text + "',lw_crf11_71x='" + txtq71x.Text + "', lw_crf11_72='" + txtq72.InnerText.ToUpper() + "', update_dt='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "', update_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where id='" + Request.QueryString["FormID"] + "' and status='1'", cn);
                    cmd.ExecuteNonQuery();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Update Successfully!');window.location.href='dashSecondPhysician.aspx';", true);
                }
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

        protected void add_Click(object sender, EventArgs e)
        {
            countQ70Records();

            SqlConnection cn = new SqlConnection(ConDataBase);
            cn.Open();
            try
            {
                if (forUpdateRec == null && txtq69.Text == "1")
                {
                    SqlCommand cmd = new SqlCommand("insert into second_crf11_q70 (crf11_id, random_id, rec_id, lw_crf11_70_medi, lw_crf11_70_route, lw_crf11_70_dose,	lw_crf11_70_freq, lw_crf11_70_duration, entry_dt, entry_nm) values ('" + Request.QueryString["FormID"] + "','" + Request.QueryString["RandID"] + "','" + lbeRecord.Text + "','" + txtQ70_1.Text + "','" + txtQ70_2.Text + "','" + txtQ70_3.Text + "','" + txtQ70_4.Text + "','" + txtQ70_5.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", cn);
                    cmd.ExecuteNonQuery();
                }
                else if (txtq69.Text == "1")
                {
                    SqlCommand cmd = new SqlCommand("update second_crf11_q70 set lw_crf11_70_medi='" + txtQ70_1.Text + "',lw_crf11_70_route='" + txtQ70_2.Text + "',lw_crf11_70_dose='" + txtQ70_3.Text + "',lw_crf11_70_freq='" + txtQ70_4.Text + "', lw_crf11_70_duration='" + txtQ70_5.Text + "', entry_dt='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "', entry_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where crf11_id='" + Request.QueryString["FormID"] + "' and rec_id='" + forUpdateRec + "'", cn);
                    cmd.ExecuteNonQuery();
                    forUpdateRec = null;
                }
                GridView();
                countQ70Records();

                txtQ70_1.Text = "";
                txtQ70_2.Text = "";
                txtQ70_3.Text = "";
                txtQ70_4.Text = "";
                txtQ70_5.Text = "";

                txtQ70_1.Focus();
            }
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
        }


        public void countQ70Records()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select count(*) as total from second_crf11_q70 where crf11_id='" + Request.QueryString["FormID"] + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true) Q70Records = dr["total"].ToString();
                lbeRecord.Text = Convert.ToString(Convert.ToInt32(Q70Records) + 1);
            }
            finally
            {
                con.Close();
            }
        }



        public void GridView()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from second_crf11_q70 where crf11_id='" + Request.QueryString["FormID"] + "' order by id");
            con.Open();
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter();
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        DataTable dt = new DataTable();
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void Link_Button1(object sender, EventArgs e)
        {
            string[] arg = new string[2];
            arg = ((LinkButton)sender).CommandArgument.Split(';');
            string crf11_id = arg[0];
            forUpdateRec = arg[1];


            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from second_crf11_q70 where crf11_id='" + Request.QueryString["FormID"] + "' and rec_id='" + forUpdateRec + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    lbeRecord.Text = dr["rec_id"].ToString();
                    txtQ70_1.Text = dr["lw_crf11_70_medi"].ToString();
                    txtQ70_2.Text = dr["lw_crf11_70_route"].ToString();
                    txtQ70_3.Text = dr["lw_crf11_70_dose"].ToString();
                    txtQ70_4.Text = dr["lw_crf11_70_freq"].ToString();
                    txtQ70_5.Text = dr["lw_crf11_70_duration"].ToString();
                    txtQ70_1.Focus();
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
            SqlCommand cmd = new SqlCommand("select * from second_crf11 where id='" + Request.QueryString["FormID"] + "' and status='1'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {

                    chk01.Checked = (dr["lw_crf11_64_01"].Equals("1"));
                    chk02.Checked = (dr["lw_crf11_64_02"].Equals("2"));
                    chk03.Checked = (dr["lw_crf11_64_03"].Equals("3"));
                    chk04.Checked = (dr["lw_crf11_64_04"].Equals("4"));
                    chk05.Checked = (dr["lw_crf11_64_05"].Equals("5"));
                    chk06.Checked = (dr["lw_crf11_64_06"].Equals("6"));
                    chk07.Checked = (dr["lw_crf11_64_07"].Equals("7"));


                    txtq64a.Text = dr["lw_crf11_64_07x1"].ToString();
                    txtq64b.Text = dr["lw_crf11_64_07x2"].ToString();
                    txtq64c.Text = dr["lw_crf11_64_07x3"].ToString();
                    txtq64d.Text = dr["lw_crf11_64_07x4"].ToString();
                    txtq65.Text = dr["lw_crf11_65"].ToString();
                    txtq66.Text = dr["lw_crf11_66"].ToString();
                    txtq67.Text = dr["lw_crf11_67"].ToString();
                    txtq68a.Text = dr["lw_crf11_68a"].ToString();
                    txtq68b.Text = dr["lw_crf11_68b"].ToString();
                    txtq69.Text = dr["lw_crf11_69"].ToString();
                    txtq71.Text = dr["lw_crf11_71"].ToString();
                    txtq71x.Text = dr["lw_crf11_71x"].ToString();
                    txtq72.InnerText = dr["lw_crf11_72"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }


    }
}