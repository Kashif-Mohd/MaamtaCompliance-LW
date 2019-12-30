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
    public partial class crf11a : System.Web.UI.Page
    {
        //MySQL 
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;
        //SQL Server
        string ConDataBase = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLink"].ConnectionString;


        static string FormID;
        string currentdate;

        static string Site;
        static string Para;
        static string Block;
        static string Struct;
        static string HH;
        static string Wm_no;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "crf11";
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
                cmd = new MySqlCommand("select b.assis_id ,a.study_id,a.lw_crf_3a_18 as rand_id,b.dssid,b.site,b.para,b.block,b.struct,b.HH,b.wm_no,b.lw_crf1_09 as woman_nm, b.lw_crf1_10 as husband_nm, b.lw_crf2_21 as dob  from view_crf2 as b left join  view_crf3a as a  on a.assis_id=b.assis_id where b.dssid like '%" + txtdssid.Text + "%'  and b.Q17_Vstatus='1' and b.Q20='1' order by a.lw_crf_3a_18", con);

                //cmd = new MySqlCommand("select b.assis_id ,a.study_id,a.lw_crf_3a_18 as rand_id,a.dssid,b.site,b.para,b.block,b.struct,b.HH,b.wm_no,a.lw_crf1_09 as woman_nm, a.lw_crf1_10 as husband_nm, b.lw_crf2_21 as dob  from view_crf3a as a left join view_crf2 as b on a.assis_id=b.assis_id where a.dssid like '%" + txtdssid.Text + "%' order by a.lw_crf_3a_18", con);
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
            currentdate = DateTime.Now.ToString("dd/MM/yyyy");
            SqlConnection cn = new SqlConnection(ConDataBase);
            cn.Open();
            try
            {
                if (DateTime.ParseExact(txtDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= (DateTime.ParseExact(currentdate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date of Visit, enter Less than Current Date!");
                    txtDOV.Focus();
                }
                else if (txtDOB.Text != "" && DateTime.ParseExact(txtDOB.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtDOV.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    showalert("Enter Greater than Date of Birth (" + txtDOB.Text + ")");
                    txtDOV.Focus();
                }
                else if (StatusCheck() == true)
                {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Record already exist, according to given Date of Visit!');window.location.href='crf11a.aspx';", true);
                    showalert("Record already exist, according to given Date of Visit!");
                    txtDOV.Focus();
                }
                else
                {
                    if (CheckIncomplete() == false)
                    {
                        SqlCommand cmd = new SqlCommand("insert into crf11(assist_id, study_id, random_id, dssid, dob, lw_crf11_03dt, lw_crf11_04tm, lw_crf11_05, lw_crf11_06, lw_crf11_07, lw_crf11_08, lw_crf11_09, lw_crf11_10, lw_crf11_11, lw_crf11_12, lw_crf11_13, lw_crf11_14, status, entry_dt, entry_nm) values ('" + txtAssisid.Text + "','" + txtStudyID.Text + "','" + txtRandomid.Text + "','" + txtDSSComplete.Text.ToUpper() + "','" + txtDOB.Text + "','" + txtDOV.Text + "','" + txtTOV.Text + "','" + txtq5bPhyCode.Text.ToUpper() + "','" + txtq6ChldNm.Text.ToUpper() + "','" + txtq7WomanNm.Text.ToUpper() + "','" + txtq8HusbndNm.Text.ToUpper() + "','" + Site.ToUpper() + "' ,'" + Para.ToUpper() + "','" + Block + "','" + Struct + "' ,'" + HH.ToUpper() + "' ,'" + Wm_no + "','" + "0" + "','" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", cn);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update crf11 set random_id='" + txtRandomid.Text + "', dssid='" + txtDSSComplete.Text.ToUpper() + "',dob='" + txtDOB.Text + "', lw_crf11_04tm='" + txtTOV.Text + "',  lw_crf11_05='" + txtq5bPhyCode.Text.ToUpper() + "', lw_crf11_06='" + txtq6ChldNm.Text.ToUpper() + "', lw_crf11_07='" + txtq7WomanNm.Text.ToUpper() + "',lw_crf11_08='" + txtq8HusbndNm.Text.ToUpper() + "'  ,lw_crf11_09='" + Site.ToUpper() + "', lw_crf11_10='" + Para.ToUpper() + "', lw_crf11_11='" + Block + "', lw_crf11_12='" + Struct + "', lw_crf11_13='" + HH.ToUpper() + "', lw_crf11_14='" + Wm_no + "', entry_dt='" + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") + "', entry_nm='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'  where  assist_id='" + txtAssisid.Text + "' and lw_crf11_03dt='" + txtDOV.Text + "'", cn);
                        cmd.ExecuteNonQuery();
                    }
                    cn.Close();
                    CheckFormID();
                    Response.Redirect("crf11b.aspx?&FormID=" + FormID + "&RandID=" + txtRandomid.Text.ToUpper());
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtDOV.Focus();
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



        public void CheckFormID()
        {
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select id from crf11 where assist_id='" + txtAssisid.Text + "' and lw_crf11_03dt='" + txtDOV.Text + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true) FormID = dr["id"].ToString();
            }
            finally
            {
                con.Close();
            }
        }


        public bool StatusCheck()
        {
            bool exist = false;
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from crf11 where assist_id='" + txtAssisid.Text + "' and lw_crf11_03dt='" + txtDOV.Text + "' and status='1'", con);
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




        public bool CheckIncomplete()
        {
            bool exist = false;
            SqlConnection con = new SqlConnection(ConDataBase);
            SqlCommand cmd = new SqlCommand("select * from crf11 where assist_id='" + txtAssisid.Text + "' and lw_crf11_03dt='" + txtDOV.Text + "' and status='0'", con);
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


        protected void Link_OpenForm(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Role"]) == "admin_maamtaLW" || Convert.ToString(Session["Role"]) == "super_admin")
            {
                string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
                txtAssisid.Text = commandArgs[0];
                txtStudyID.Text = commandArgs[1];
                txtRandomid.Text = commandArgs[2];
                txtDSSComplete.Text = commandArgs[3];
                txtq7WomanNm.Text = commandArgs[4];
                txtq8HusbndNm.Text = commandArgs[5];
                string DateB = commandArgs[6];

                string[] DateOfBirth = DateB.Split(new char[] { '-' });
                string Day = DateOfBirth[0];
                string Month = DateOfBirth[1];
                string Year = DateOfBirth[2];

                if (Day.Length == 1) Day = "0" + Day;
                if (Month.Length == 1) Month = "0" + Month;
                txtDOB.Text = Day + "/" + Month + "/" + Year;


                Site = commandArgs[7];
                Para = commandArgs[8];
                Block = commandArgs[9];
                Struct = commandArgs[10];
                HH = commandArgs[11];
                Wm_no = commandArgs[12];

                forSearch.Visible = false;
                forEntry.Visible = true;
                txtDOV.Focus();
            }
            else
            {
                showalert("Only Admin has right to update details");
            }
        }


    }
}