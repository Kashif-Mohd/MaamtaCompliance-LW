using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ComplianceMaamtaLW
{
    public partial class Update_CoreDSS : System.Web.UI.Page
    {
        static string Core_DSS_DSSID = null;
        static string Core_DSS_Woman_Name = null;
        static string Core_DSS_Husband_Name = null;
        static string Core_DSS_DOB = null;
        static string Core_DSS_Remarks = null;


        //MySQL Server
        string ConDataBase_COREDSS_MySQL = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSSMySQL"].ConnectionString;
        //SQL Server
        string ConDataBase_COREDSS_SQL = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSS"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "Update_CoreDSS";
                txtSearchDSSID.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }












        protected void Update_Click(object sender, EventArgs e)
        {
            SqlConnection SQL_Connection = new SqlConnection(ConDataBase_COREDSS_SQL);
            MySqlConnection MySQL_Connection = new MySqlConnection(ConDataBase_COREDSS_MySQL);

            try
            {

                string currentdate = DateTime.Now.ToString("dd-MM-yyyy");

                if (txtDOR.Text != "" && DateTime.ParseExact(txtDOR.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > (DateTime.ParseExact(currentdate, "dd-MM-yyyy", CultureInfo.InvariantCulture)))
                {
                    showalert("Incorrect Date, Date of Registration should be Less than Current Date!");
                    txtDOR.Focus();
                }
                else
                {
                    string DOB = null;


                    if (txtDOR.Text != "" && txtAge.Text != "")
                    {
                        DOB = (Convert.ToDateTime(txtDOR.Text).AddYears(-Convert.ToInt32(txtAge.Text))).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }

                    // Insert on Update_Core_DSS_Info Table on (SQL Server):
                    SQL_Connection.Open();
                    SqlCommand update_core_dss_info = new SqlCommand("insert into update_core_dss_info (dssid,woman_name,husband_name,dob,Remarks,removed_date,removed_by_name) values ('" + Core_DSS_DSSID + "','" + Core_DSS_Woman_Name + "','" + Core_DSS_Husband_Name + "','" + Core_DSS_DOB + "','" + Core_DSS_Remarks + "' ,'" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture) + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", SQL_Connection);
                    update_core_dss_info.ExecuteNonQuery();
                    SQL_Connection.Close();

                    //Update on CoreDSS Table (SQL Server):
                    SQL_Connection.Open();
                    SqlCommand cmd = new SqlCommand("update core_dss set woman_name='" + txtWomanNm.Text.ToUpper() + "', husband_name='" + txtHusbandNm.Text.ToUpper() + "', dob='" + DOB + "', Remarks='" + txtremarks.InnerText + "', update_date='" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture) + "', update_name='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "' where dssid='" + txtDSSID.Text + "'", SQL_Connection);
                    cmd.ExecuteNonQuery();
                    SQL_Connection.Close();

                    //Update on Married_Woman Table (MySQL):
                    MySQL_Connection.Open();
                    MySqlCommand cmd1 = new MySqlCommand("update married_woman set name='" + txtWomanNm.Text.ToUpper() + "', husband_name='" + txtHusbandNm.Text.ToUpper() + "', dob='" + DOB + "'  where concat(site,para,block,structure,house_hold,woman_number) ='" + txtDSSID.Text + "'", MySQL_Connection);
                    cmd1.ExecuteNonQuery();
                    MySQL_Connection.Close();

                    ClearTextBox();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alerts", "javascript:alert('Form Update Successfully!');window.location.href='Update_CoreDSS.aspx';", true);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "The DateTime represented by the string is not supported in calendar System.Globalization.GregorianCalendar.")
                {
                    showalert("Incorrect Date Format!");
                    txtDOR.Focus();
                }
                else
                {
                    showalert(ex.Message);
                }
            }
            finally
            {
                SQL_Connection.Close();
                MySQL_Connection.Close();
            }

        }




        public void ClearTextBox()
        {
            txtDSSID.Text = "";
            txtWomanNm.Text = "";
            txtHusbandNm.Text = "";
            txtAge.Text = "";
            txtremarks.InnerText = "";
        }





        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData_CoreDSS();
        }




        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchDSSID.Text == "" || txtSearchDSSID.Text.Length < 5)
            {
                showalert("Enter DSSID, minimun length should be 5");
                txtSearchDSSID.Focus();
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
                ShowData_CoreDSS();
                txtSearchDSSID.Focus();
            }
        }






        private void ShowData_CoreDSS()
        {
            SqlConnection con = new SqlConnection(ConDataBase_COREDSS_SQL);
            try
            {
                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("select * from core_dss as a where a.dssid like 'RG%' and a.dssid like '%" + txtSearchDSSID.Text + "%' and a.status='1'", con);
                SqlDataAdapter sda = new SqlDataAdapter();
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









        protected void Link_OpenForm(object sender, EventArgs e)
        {
            ClearTextBox();
            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Core_DSS_DSSID = commandArgs[0];
            Core_DSS_Woman_Name = commandArgs[1];
            Core_DSS_Husband_Name = commandArgs[2];
            Core_DSS_DOB = commandArgs[3];
            Core_DSS_Remarks = commandArgs[4];

            txtDSSID.Text = commandArgs[0];
            txtWomanNm.Text = commandArgs[1];
            txtHusbandNm.Text = commandArgs[2];
            txtremarks.InnerText = commandArgs[4];

            Panel1.Visible = true;
            Panel2.Visible = false;
            txtWomanNm.Focus();
        }




    }
}