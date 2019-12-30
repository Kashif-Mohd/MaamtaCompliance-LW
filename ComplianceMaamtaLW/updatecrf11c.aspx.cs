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
    public partial class updatecrf11c : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FieldFill();
                Session["WebForm"] = "crf11";
                txtq33.Focus();
            }
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }




        protected void next_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConDataBase);
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("update crf11 set lw_crf11_33='" + txtq33.Text + "', lw_crf11_34='" + txtq34.Text + "', lw_crf11_35='" + txtq35.Text + "', lw_crf11_36a='" + txtq36a.Text + "', lw_crf11_36b='" + txtq36b.Text + "', lw_crf11_37='" + txtq37.Text + "', lw_crf11_38a='" + txtq38a.Text + "',lw_crf11_38b='" + txtq38b.Text + "',lw_crf11_39='" + txtq39.Text + "', lw_crf11_40='" + txtq40.Text + "', lw_crf11_41a='" + txtq41a.Text + "', lw_crf11_41b='" + txtq41b.Text + "', lw_crf11_42='" + txtq42.Text + "', lw_crf11_43='" + txtq43.Text + "', lw_crf11_44='" + txtq44.Text + "', lw_crf11_45='" + txtq45.Text + "', lw_crf11_46='" + txtq46.Text + "', lw_crf11_47='" + txtq47.Text + "', lw_crf11_48='" + txtq48.Text + "', lw_crf11_49='" + txtq49.Text + "', lw_crf11_50='" + txtq50.Text + "', lw_crf11_51='" + txtq51.Text + "', lw_crf11_52='" + txtq52.Text + "', lw_crf11_53='" + txtq53.Text + "', lw_crf11_54='" + txtq54.Text + "', lw_crf11_55='" + txtq55.Text + "', lw_crf11_56='" + txtq56.Text + "', lw_crf11_57='" + txtq57.Text + "', lw_crf11_58='" + txtq58.Text + "', lw_crf11_59_01='" + txtq59a.Text + "', lw_crf11_59_02='" + txtq59b.Text + "', lw_crf11_59_03='" + txtq59c.Text + "', lw_crf11_59_04='" + txtq59d.Text + "', lw_crf11_60='" + txtq60.Text + "', lw_crf11_61='" + txtq61.Text + "', lw_crf11_62='" + txtq62.Text + "', lw_crf11_63='" + txtq63.Text + "', update_dt='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "', update_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where id='" + Request.QueryString["FormID"] + "' and status='1'", cn);
                cmd.ExecuteNonQuery();
                Response.Redirect("updatecrf11d.aspx?&FormID=" + Request.QueryString["FormID"]);
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
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from crf11 where id='" + Request.QueryString["FormID"] + "' and status='1'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    txtq33.Text = dr["lw_crf11_33"].ToString();
                    txtq34.Text = dr["lw_crf11_34"].ToString();
                    txtq35.Text = dr["lw_crf11_35"].ToString();
                    txtq36a.Text = dr["lw_crf11_36a"].ToString();
                    txtq36b.Text = dr["lw_crf11_36b"].ToString();
                    txtq37.Text = dr["lw_crf11_37"].ToString();
                    txtq38a.Text = dr["lw_crf11_38a"].ToString();
                    txtq38b.Text = dr["lw_crf11_38b"].ToString();
                    txtq39.Text = dr["lw_crf11_39"].ToString();
                    txtq40.Text = dr["lw_crf11_40"].ToString();
                    txtq41a.Text = dr["lw_crf11_41a"].ToString();
                    txtq41b.Text = dr["lw_crf11_41b"].ToString();
                    txtq42.Text = dr["lw_crf11_42"].ToString();
                    txtq43.Text = dr["lw_crf11_43"].ToString();
                    txtq44.Text = dr["lw_crf11_44"].ToString();
                    txtq45.Text = dr["lw_crf11_45"].ToString();
                    txtq46.Text = dr["lw_crf11_46"].ToString();
                    txtq47.Text = dr["lw_crf11_47"].ToString();
                    txtq48.Text = dr["lw_crf11_48"].ToString();
                    txtq49.Text = dr["lw_crf11_49"].ToString();
                    txtq50.Text = dr["lw_crf11_50"].ToString();
                    txtq51.Text = dr["lw_crf11_51"].ToString();
                    txtq52.Text = dr["lw_crf11_52"].ToString();
                    txtq53.Text = dr["lw_crf11_53"].ToString();
                    txtq54.Text = dr["lw_crf11_54"].ToString();
                    txtq55.Text = dr["lw_crf11_55"].ToString();
                    txtq56.Text = dr["lw_crf11_56"].ToString();
                    txtq57.Text = dr["lw_crf11_57"].ToString();
                    txtq58.Text = dr["lw_crf11_58"].ToString();
                    txtq59a.Text = dr["lw_crf11_59_01"].ToString();
                    txtq59b.Text = dr["lw_crf11_59_02"].ToString();
                    txtq59c.Text = dr["lw_crf11_59_03"].ToString();
                    txtq59d.Text = dr["lw_crf11_59_04"].ToString();
                    txtq60.Text = dr["lw_crf11_60"].ToString();
                    txtq61.Text = dr["lw_crf11_61"].ToString();
                    txtq62.Text = dr["lw_crf11_62"].ToString();
                    txtq63.Text = dr["lw_crf11_63"].ToString();
                }
            }
            finally
            {
                con.Close();
            }
        }


    }
}