using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ComplianceMaamtaLW
{
    public partial class searchdss : System.Web.UI.Page
    {
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "searchDssid";
                ShowData();
                txtdssid.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
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

            ShowData();
            txtdssid.Focus();

        }

        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {

                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select   a.lw_crf_3a_18 as rand_id,a.lw_crf_3a_4 as study_id,c.lw_crf1_09 as woman_nm,c.lw_crf1_10 as husband_nm, concat(b.lw_crf_1_11,'',b.lw_crf_1_12,'',b.lw_crf_1_13,'',b.lw_crf_1_14,'',b.lw_crf_1_15,'',b.lw_crf_1_16)as dssid,a.lw_crf_3a_2 as date_of_enrollment,e.lw_crf2_21 as date_of_birth	from form_crf_3a as a inner join pw as c on a.assis_id=c.id inner join  dss_address as b on c.dss_id=b.dss_id inner join emp as d on d.team_id=a.team_id inner join form_crf_2 as e on e.assis_id=a.assis_id where  a.lw_crf_3a_19 !='a' and  concat(b.lw_crf_1_11,'',b.lw_crf_1_12,'',b.lw_crf_1_13,'',b.lw_crf_1_14,'',b.lw_crf_1_15,'',b.lw_crf_1_16)   like '%" + txtdssid.Text + "%' order by a.lw_crf_3a_18 ", con);
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




    }
}