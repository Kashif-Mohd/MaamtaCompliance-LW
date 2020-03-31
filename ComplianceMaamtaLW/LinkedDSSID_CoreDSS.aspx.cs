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
    public partial class LinkedDSSID_CoreDSS : System.Web.UI.Page
    {

        //MySQL Server
        string ConDataBase_COREDSS_MySQL = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSSMySQL"].ConnectionString;
        //SQL Server
        string ConDataBase_COREDSS_SQL = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSS"].ConnectionString;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "LinkedDSSID_CoreDSS";
                txt_OLD_DSSID.Focus();
            }

        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }



        protected void submit_Click(object sender, EventArgs e)
        {
            SqlConnection SQL_Connection = new SqlConnection(ConDataBase_COREDSS_SQL);
            MySqlConnection MySQL_Connection = new MySqlConnection(ConDataBase_COREDSS_MySQL);

            try
            {

                // CoreDSS SQL Server:
                if (Check_Old_DSS_SQLServer() == true && Check_New_DSS_SQLServer() == true)
                {
                    //Update on CoreDSS Table (SQL Server):
                    SQL_Connection.Open();
                    // SqlCommand cmd = new SqlCommand("update core_dss set woman_name='" + txtWomanNm.Text.ToUpper() + "', husband_name='" + txtHusbandNm.Text.ToUpper() + "', dob='" + DOB + "', Remarks='" + txtremarks.InnerText + "', update_date='" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture) + "', update_name='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "' where dssid='" + txtDSSID.Text + "'", SQL_Connection);
                  //  cmd.ExecuteNonQuery();
                    SQL_Connection.Close();
                }

                // Married_Woman  MySQL:
                if (Check_Old_DSS_MySQL() == true && Check_New_DSS_MySQL() == true)
                {
                    //Update on Married_Woman Table (MySQL):
                    MySQL_Connection.Open();
                    //MySqlCommand cmd1 = new MySqlCommand("update married_woman set name='" + txtWomanNm.Text.ToUpper() + "', husband_name='" + txtHusbandNm.Text.ToUpper() + "', dob='" + DOB + "'  where concat(site,para,block,structure,house_hold,woman_number) ='" + txtDSSID.Text + "'", MySQL_Connection);
                    //cmd1.ExecuteNonQuery();
                    MySQL_Connection.Close();
                }

                ClearTextBox();
                showalert("Link Created between Old and New DSSID Successfully!");

            }
            finally
            {
                SQL_Connection.Close();
                MySQL_Connection.Close();
            }
        }





        public void ClearTextBox()
        {
            txt_OLD_DSSID.Text = "";
            txt_NEW_DSSID.Text = "";
            txtWomanNm.Text = "";
            txtHusbandNm.Text = "";
        }





        public bool Check_Old_DSS_SQLServer()
        {
            bool exist = false;
            SqlConnection con = new SqlConnection(ConDataBase_COREDSS_SQL);
            SqlCommand cmd = new SqlCommand("select * from core_dss where dssid='" + txt_OLD_DSSID.Text + "' and woman_name='" + txtWomanNm.Text.ToUpper() + "' and husband_name='" + txtHusbandNm.Text.ToUpper() + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
                else
                {
                    string MW_Name = txtWomanNm.Text.ToUpper() + " / " + txtHusbandNm.Text.ToUpper();
                    showalert("OLD DSSID does not exist in SQL Server, against the name of " + MW_Name);
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }


        public bool Check_New_DSS_SQLServer()
        {
            bool exist = false;
            SqlConnection con = new SqlConnection(ConDataBase_COREDSS_SQL);
            SqlCommand cmd = new SqlCommand("select * from core_dss where dssid='" + txt_NEW_DSSID.Text + "' and woman_name='" + txtWomanNm.Text.ToUpper() + "' and husband_name='" + txtHusbandNm.Text.ToUpper() + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
                else
                {
                    string MW_Name = txtWomanNm.Text.ToUpper() + " / " + txtHusbandNm.Text.ToUpper();
                    showalert("NEW DSSID does not exist in SQL Server, against the name of " + MW_Name);
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }









        public bool Check_Old_DSS_MySQL()
        {

            bool exist = false;
            MySqlConnection con = new MySqlConnection(ConDataBase_COREDSS_MySQL);
            MySqlCommand cmd = new MySqlCommand("select * from married_woman where concat(site,para,block,structure,house_hold,woman_number)='" + txt_OLD_DSSID.Text.ToUpper() + "' and name='" + txtWomanNm.Text.ToUpper() + "' and husband_name='" + txtHusbandNm.Text.ToUpper() + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
                else
                {
                    string MW_Name = txtWomanNm.Text.ToUpper() + " / " + txtHusbandNm.Text.ToUpper();
                    showalert("OLD DSSID does not exist in MySQL, against the name of " + MW_Name);
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }



        public bool Check_New_DSS_MySQL()
        {

            bool exist = false;
            MySqlConnection con = new MySqlConnection(ConDataBase_COREDSS_MySQL);
            MySqlCommand cmd = new MySqlCommand("select * from married_woman where concat(site,para,block,structure,house_hold,woman_number)='" + txt_NEW_DSSID.Text.ToUpper() + "' and name='" + txtWomanNm.Text.ToUpper() + "' and husband_name='" + txtHusbandNm.Text.ToUpper() + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;
                }
                else
                {
                    string MW_Name = txtWomanNm.Text.ToUpper() + " / " + txtHusbandNm.Text.ToUpper();
                    showalert("NEW DSSID does not exist in MySQL, against the name of " + MW_Name);

                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }





    }
}