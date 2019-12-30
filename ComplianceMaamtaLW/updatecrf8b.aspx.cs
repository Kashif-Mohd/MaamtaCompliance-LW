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
    public partial class updatecrf8b : System.Web.UI.Page
    {
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashCrf8";
                FieldFill();
                txtq26.Focus();
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
                //   MySqlCommand cmd = new MySqlCommand("update crf8 set q26='" + txtq26.Text + "',q27='" + txtq27.Text + "',q27_other='" + txtq27_other.Text + "',q28='" + txtq28.Text + "'	,q29_minutes='" + txtq29_min.Text + "'	,q29_hours='" + txtq29_hr.Text + "', q29_days='" + txtq29_day.Text + "', q30a_1='" + txtq30a1.InnerText + "', q30a_2='" + txtq30a2.InnerText + "', q30a_3='" + txtq30a3.InnerText + "', q30a_4='" + txtq30a4.InnerText + "', q30a_5='" + txtq30a5.InnerText + "', q30a_6='" + txtq30a6.InnerText + "', q30a_7='" + txtq30a7.InnerText + "', q30a_8='" + txtq30a8.InnerText + "', q30a_9='" + txtq30a9.InnerText + "', q30a_10='" + txtq30a10.InnerText + "',      q30b_1='" + txtq30b1.InnerText + "', q30b_2='" + txtq30b2.InnerText + "', q30b_3='" + txtq30b3.InnerText + "', q30b_4='" + txtq30b4.InnerText + "', q30b_5='" + txtq30b5.InnerText + "', q30b_6='" + txtq30b6.InnerText + "', q30b_7='" + txtq30b7.InnerText + "', q30b_8='" + txtq30b8.InnerText + "', q30b_9='" + txtq30b9.InnerText + "', q30b_10='" + txtq30b10.InnerText + "'          where  id='" + Request.QueryString["FormID"] + "' and status=0", cn);
                MySqlCommand cmd = new MySqlCommand("update crf8 set q26='" + txtq26.Text + "',q27='" + txtq27.Text + "',q27_other='" + txtq27_other.Text + "',q28='" + txtq28.Text + "'	,q29_minutes='" + txtq29_min.Text + "'	,q29_hours='" + txtq29_hr.Text + "', q29_days='" + txtq29_day.Text + "', q30a_1='" + txtq30a1.InnerText + "', q30a_2='" + txtq30a2.InnerText + "', q30a_3='" + txtq30a3.InnerText + "', q30a_4='" + txtq30a4.InnerText + "', q30a_5='" + txtq30a5.InnerText + "', q30a_6='" + txtq30a6.InnerText + "', q30a_7='" + txtq30a7.InnerText + "', q30a_8='" + txtq30a8.InnerText + "', q30a_9='" + txtq30a9.InnerText + "', q30a_10='" + txtq30a10.InnerText + "',      q30b_1='" + txtq30b1.InnerText + "', q30b_2='" + txtq30b2.InnerText + "', q30b_3='" + txtq30b3.InnerText + "', q30b_4='" + txtq30b4.InnerText + "', q30b_5='" + txtq30b5.InnerText + "', q30b_6='" + txtq30b6.InnerText + "', q30b_7='" + txtq30b7.InnerText + "', q30b_8='" + txtq30b8.InnerText + "', q30b_9='" + txtq30b9.InnerText + "', q30b_10='" + txtq30b10.InnerText + "', q30a_1dt='" + txtq30a1dt.Text + "', q30a_2dt='" + txtq30a2dt.Text + "', q30a_3dt='" + txtq30a3dt.Text + "', q30a_4dt='" + txtq30a4dt.Text + "', q30a_5dt='" + txtq30a5dt.Text + "', q30a_6dt='" + txtq30a6dt.Text + "', q30a_7dt='" + txtq30a7dt.Text + "', q30a_8dt='" + txtq30a8dt.Text + "', q30a_9dt='" + txtq30a9dt.Text + "', q30a_10dt='" + txtq30a10dt.Text + "',      q30b_1dt='" + txtq30b1dt.Text + "', q30b_2dt='" + txtq30b2dt.Text + "', q30b_3dt='" + txtq30b3dt.Text + "', q30b_4dt='" + txtq30b4dt.Text + "', q30b_5dt='" + txtq30b5dt.Text + "', q30b_6dt='" + txtq30b6dt.Text + "', q30b_7dt='" + txtq30b7dt.Text + "', q30b_8dt='" + txtq30b8dt.Text + "', q30b_9dt='" + txtq30b9dt.Text + "', q30b_10dt='" + txtq30b10dt.Text + "'          where  id='" + Request.QueryString["FormID"] + "'", cn);
                cmd.ExecuteNonQuery();
                Response.Redirect("updatecrf8c.aspx?&FormID=" + Request.QueryString["FormID"] + "&Study_ID=" + Request.QueryString["Study_ID"]);
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
                    txtq26.SelectedValue = dr["q26"].ToString();
                    txtq27.SelectedValue = dr["q27"].ToString();
                    txtq27_other.Text = dr["q27_other"].ToString();
                    txtq28.SelectedValue = dr["q28"].ToString();

                    txtq29_min.Text = dr["q29_minutes"].ToString();
                    txtq29_hr.Text = dr["q29_hours"].ToString();
                    txtq29_day.Text = dr["q29_days"].ToString();



                    txtq30a1.InnerText = dr["q30a_1"].ToString();
                    txtq30a2.InnerText = dr["q30a_2"].ToString();
                    txtq30a3.InnerText = dr["q30a_3"].ToString();
                    txtq30a4.InnerText = dr["q30a_4"].ToString();
                    txtq30a5.InnerText = dr["q30a_5"].ToString();
                    txtq30a6.InnerText = dr["q30a_6"].ToString();
                    txtq30a7.InnerText = dr["q30a_7"].ToString();
                    txtq30a8.InnerText = dr["q30a_8"].ToString();
                    txtq30a9.InnerText = dr["q30a_9"].ToString();
                    txtq30a10.InnerText = dr["q30a_10"].ToString();

                    txtq30b1.InnerText = dr["q30b_1"].ToString();
                    txtq30b2.InnerText = dr["q30b_2"].ToString();
                    txtq30b3.InnerText = dr["q30b_3"].ToString();
                    txtq30b4.InnerText = dr["q30b_4"].ToString();
                    txtq30b5.InnerText = dr["q30b_5"].ToString();
                    txtq30b6.InnerText = dr["q30b_6"].ToString();
                    txtq30b7.InnerText = dr["q30b_7"].ToString();
                    txtq30b8.InnerText = dr["q30b_8"].ToString();
                    txtq30b9.InnerText = dr["q30b_9"].ToString();
                    txtq30b10.InnerText = dr["q30b_10"].ToString();



                    txtq30a1dt.Text = dr["q30a_1dt"].ToString();
                    txtq30a2dt.Text = dr["q30a_2dt"].ToString();
                    txtq30a3dt.Text = dr["q30a_3dt"].ToString();
                    txtq30a4dt.Text = dr["q30a_4dt"].ToString();
                    txtq30a5dt.Text = dr["q30a_5dt"].ToString();
                    txtq30a6dt.Text = dr["q30a_6dt"].ToString();
                    txtq30a7dt.Text = dr["q30a_7dt"].ToString();
                    txtq30a8dt.Text = dr["q30a_8dt"].ToString();
                    txtq30a9dt.Text = dr["q30a_9dt"].ToString();
                    txtq30a10dt.Text = dr["q30a_10dt"].ToString();

                    txtq30b1dt.Text = dr["q30b_1dt"].ToString();
                    txtq30b2dt.Text = dr["q30b_2dt"].ToString();
                    txtq30b3dt.Text = dr["q30b_3dt"].ToString();
                    txtq30b4dt.Text = dr["q30b_4dt"].ToString();
                    txtq30b5dt.Text = dr["q30b_5dt"].ToString();
                    txtq30b6dt.Text = dr["q30b_6dt"].ToString();
                    txtq30b7dt.Text = dr["q30b_7dt"].ToString();
                    txtq30b8dt.Text = dr["q30b_8dt"].ToString();
                    txtq30b9dt.Text = dr["q30b_9dt"].ToString();
                    txtq30b10dt.Text = dr["q30b_10dt"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }


    }
}