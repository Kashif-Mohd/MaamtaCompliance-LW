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
    public partial class searchfollowups : System.Web.UI.Page
    {
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "searchFollowups";
              //  ShowData();
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
                cmd = new MySqlCommand("select a.form_crf_5a_id,a.followup_num, c.study_code,DAYNAME(str_to_date(a.lw_crf5a_02, '%d-%m-%Y')) as Day, a.lw_crf5a_02 as DOV,a.lw_crf5a_03 as TOV,     d.lw_crf1_09 as woman_nm,d.lw_crf1_10 as husband_nm,         concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16)as dssid,	 if((a.lw_crf5a_29 is NULL || a.lw_crf5a_29 =''), (SELECT (DATEDIFF(str_to_date(a.lw_crf5a_02, '%d-%m-%Y'), str_to_date(z.lw_crf3c_2, '%d-%m-%Y')))*2 from form_crf_3c as z where z.study_id=a.study_id), a.lw_crf5a_29)   as lw_crf5a_29,	a.lw_crf5a_30,		   f.name from form_crf_5a as a  left join studies as c on c.study_id=a.study_id left join pw as d on d.id=c.assis_id left join dss_address as e on e.dss_id=d.dss_id  left join emp as f on  f.team_id=a.team_id  left join form_crf_3a as g on g.lw_crf_3a_4=c.study_code 	 where  concat(e.lw_crf_1_11,e.lw_crf_1_12,e.lw_crf_1_13,e.lw_crf_1_14,e.lw_crf_1_15,e.lw_crf_1_16) like '" + txtdssid.Text + "%'      group by a.form_crf_5a_id order by c.study_code,a.followup_num", con);
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