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
    public partial class second_crf11b : System.Web.UI.Page
    {
        static string forUpdateRec;
        static string Q32Records;

        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FieldFill();
                GridView();
                countQ32Records();
                Session["WebForm"] = "second_crf11";
                txtq15.Focus();
            }
        }



        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }





        protected void next_Click(object sender, EventArgs e)
        {
            deleteQ32Records();
            countQ32Records();
            SqlConnection cn = new SqlConnection(ConDataBase);
            cn.Open();
            try
            {
                if (Q32Records == "0" && txtq31.Text == "1")
                {
                    GridView();
                    showalert("Please add Medicine Records");
                    txtq31.Focus();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("update second_crf11 set lw_crf11_15='" + txtq15.Text + "', lw_crf11_15x='" + txtq15x.Text + "', lw_crf11_16='" + txtq16.Text + "', lw_crf11_17='" + txtq17.Text + "', lw_crf11_18='" + txtq18.Text + "', lw_crf11_19='" + txtq19.Text + "', lw_crf11_20='" + txtq20.Text + "',lw_crf11_21='" + txtq21.Text + "',lw_crf11_22='" + txtq22.Text + "', lw_crf11_23='" + txtq23.Text + "', lw_crf11_24='" + txtq24.Text + "', lw_crf11_25='" + txtq25.Text + "', lw_crf11_26='" + txtq26.Text + "', lw_crf11_27='" + txtq27.Text + "', lw_crf11_28='" + txtq28.Text + "', lw_crf11_29='" + txtq29.Text + "', lw_crf11_30='" + txtq30.Text + "', lw_crf11_31='" + txtq31.Text + "', entry_dt='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "', entry_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where id='" + Request.QueryString["FormID"] + "' and status='0'", cn);
                    cmd.ExecuteNonQuery();
                    Response.Redirect("second_crf11c.aspx?&FormID=" + Request.QueryString["FormID"] + "&RandID=" + Request.QueryString["RandID"]);
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
            countQ32Records();
           

            SqlConnection cn = new SqlConnection(ConDataBase);
            cn.Open();
            try
            {
                if (forUpdateRec == null && txtq31.Text == "1")
                {
                    SqlCommand cmd = new SqlCommand("insert into second_crf11_q32(crf11_id, random_id, rec_id, lw_crf11_32_medi, lw_crf11_32_type, lw_crf11_32_tm_day,	lw_crf11_32_dose, lw_crf11_32_tot_day, entry_dt, entry_nm) values ('" + Request.QueryString["FormID"] + "','" + Request.QueryString["RandID"] + "','" + lbeRecord.Text + "','" + txtQ32_1.Text + "','" + txtQ32_2.Text + "','" + txtQ32_3.Text + "','" + txtQ32_4.Text + "','" + txtQ32_5.Text + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", cn);
                    cmd.ExecuteNonQuery();
                }
                else if (txtq31.Text == "1")
                {
                    SqlCommand cmd = new SqlCommand("update second_crf11_q32 set lw_crf11_32_medi='" + txtQ32_1.Text + "',lw_crf11_32_type='" + txtQ32_2.Text + "',lw_crf11_32_tm_day='" + txtQ32_3.Text + "',lw_crf11_32_dose='" + txtQ32_4.Text + "', lw_crf11_32_tot_day='" + txtQ32_5.Text + "', entry_dt='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "', entry_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where crf11_id='" + Request.QueryString["FormID"] + "' and rec_id='" + forUpdateRec + "'", cn);
                    cmd.ExecuteNonQuery();
                    forUpdateRec = null;
                }


                GridView();
                countQ32Records();

                txtQ32_1.Text = "";
                txtQ32_2.Text = "";
                txtQ32_3.Text = "";
                txtQ32_4.Text = "";
                txtQ32_5.Text = "";

                txtQ32_1.Focus();
            }
            catch (Exception ex)
            {
                showalert(ex.Message);
            }
        }




        public void deleteQ32Records()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            con.Open();
            try
            {
                if (txtq31.Text != "1")
                {
                    SqlCommand cmd = new SqlCommand("delete from second_crf11_q32 where crf11_id='" + Request.QueryString["FormID"] + "'", con);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                con.Close();
            }
        }






        public void countQ32Records()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select count(*) as total from second_crf11_q32 where crf11_id='" + Request.QueryString["FormID"] + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true) Q32Records = dr["total"].ToString();
                lbeRecord.Text = Convert.ToString(Convert.ToInt32(Q32Records) + 1);
            }
            finally
            {
                con.Close();
            }
        }



        public void GridView()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from second_crf11_q32 where crf11_id='" + Request.QueryString["FormID"] + "' order by id");
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
            SqlCommand cmd = new SqlCommand("select * from second_crf11_q32 where crf11_id='" + Request.QueryString["FormID"] + "' and rec_id='" + forUpdateRec + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    lbeRecord.Text = dr["rec_id"].ToString();
                    txtQ32_1.Text = dr["lw_crf11_32_medi"].ToString();
                    txtQ32_2.Text = dr["lw_crf11_32_type"].ToString();
                    txtQ32_3.Text = dr["lw_crf11_32_tm_day"].ToString();
                    txtQ32_4.Text = dr["lw_crf11_32_dose"].ToString();
                    txtQ32_5.Text = dr["lw_crf11_32_tot_day"].ToString();
                    txtQ32_1.Focus();
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
            SqlCommand cmd = new SqlCommand("select * from second_crf11 where id='" + Request.QueryString["FormID"] + "'  and status='0'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    txtq15.Text = dr["lw_crf11_15"].ToString();
                    txtq15x.Text = dr["lw_crf11_15x"].ToString();
                    txtq16.Text = dr["lw_crf11_16"].ToString();
                    txtq17.Text = dr["lw_crf11_17"].ToString();
                    txtq18.Text = dr["lw_crf11_18"].ToString();
                    txtq19.Text = dr["lw_crf11_19"].ToString();
                    txtq20.Text = dr["lw_crf11_20"].ToString();
                    txtq21.Text = dr["lw_crf11_21"].ToString();
                    txtq22.Text = dr["lw_crf11_22"].ToString();
                    txtq23.Text = dr["lw_crf11_23"].ToString();
                    txtq24.Text = dr["lw_crf11_24"].ToString();
                    txtq25.Text = dr["lw_crf11_25"].ToString();
                    txtq26.Text = dr["lw_crf11_26"].ToString();
                    txtq27.Text = dr["lw_crf11_27"].ToString();
                    txtq28.Text = dr["lw_crf11_28"].ToString();
                    txtq29.Text = dr["lw_crf11_29"].ToString();
                    txtq30.Text = dr["lw_crf11_30"].ToString();
                    txtq31.Text = dr["lw_crf11_31"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }


    }
}