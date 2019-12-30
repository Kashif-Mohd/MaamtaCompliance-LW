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
    public partial class updatecrf11a : System.Web.UI.Page
    {
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "dashCrf11";
                FieldFill();
                txtTOV.Focus();
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
                SqlCommand cmd = new SqlCommand("update crf11 set  lw_crf11_04tm='" + txtTOV.Text + "',  lw_crf11_05='" + txtq5bPhyCode.Text.ToUpper() + "', lw_crf11_06='" + txtq6ChldNm.Text.ToUpper() + "', lw_crf11_07='" + txtq7WomanNm.Text.ToUpper() + "',lw_crf11_08='" + txtq8HusbndNm.Text.ToUpper() + "', update_dt='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "', update_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where  id='" + Request.QueryString["FormID"] + "' and status='1'", cn);
                cmd.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("updatecrf11b.aspx?&FormID=" + Request.QueryString["FormID"]);
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
            SqlCommand cmd = new SqlCommand("select * from crf11 where id='" + Request.QueryString["FormID"] + "'  and status='1'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    txtRandomid.Text = dr["random_id"].ToString();
                    txtAssisid.Text = dr["assist_id"].ToString();
                    txtStudyID.Text = dr["study_id"].ToString();
                    txtDOB.Text = dr["dob"].ToString();
                    txtDSSComplete.Text = dr["dssid"].ToString();
                    txtDOV.Text = dr["lw_crf11_03dt"].ToString();
                    txtTOV.Text = dr["lw_crf11_04tm"].ToString();
                    txtq5bPhyCode.Text = dr["lw_crf11_05"].ToString();
                    txtq6ChldNm.Text = dr["lw_crf11_06"].ToString();
                    txtq7WomanNm.Text = dr["lw_crf11_07"].ToString();
                    txtq8HusbndNm.Text = dr["lw_crf11_08"].ToString();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form status is Incomplete');window.location.href='dashPhysician.aspx';", true);
                }
            }
            finally
            {
                con.Close();
            }
        }







    }
}