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
    public partial class Register_CoreDSS : System.Web.UI.Page
    {

        static string Site;

        //MySQL Server
        string ConDataBase_COREDSS_MySQL = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSSMySQL"].ConnectionString;
        //SQL Server
        string ConDataBase_COREDSS_SQL = System.Configuration.ConfigurationManager.ConnectionStrings["ServerLinkCoreDSS"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "Register_CoreDSS";

                SearchSite();
                ParaList();
                dd_ParaList.Focus();
            }
        }

        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        public void SearchSite()
        {
            SqlConnection con = new SqlConnection(ConDataBase_COREDSS_SQL);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from login where username='" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Site = dr["site"].ToString();


                if (Site == "1")
                {
                    txtSite.Text = "BH";
                }
                else if (Site == "2")
                {
                    txtSite.Text = "RG";
                }
                else if (Site == "3")
                {
                    txtSite.Text = "AG";
                }
            }
            con.Close();
        }



        public void ParaList()
        {
            SqlConnection con = new SqlConnection(ConDataBase_COREDSS_SQL);
            try
            {
                dd_ParaList.Items.Add("Choose Para");
                con.Open();
                string sqlsel = "SELECT * from para_list where site_id=" + Site + "";

                SqlCommand com = new SqlCommand(sqlsel, con);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    dd_ParaList.Items.Add(reader["Para"].ToString());
                }
                reader.Close();
                con.Close();
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




        public bool StatusCheckSQL()
        {
            string DSSID = txtSite.Text + dd_ParaList.Text + txtBlock.Text + txtStruct.Text + txtHH.Text + txtWomanNumber.Text;

            bool exist = false;
            SqlConnection con = new SqlConnection(ConDataBase_COREDSS_SQL);
            SqlCommand cmd = new SqlCommand("select * from core_dss where dssid='" + DSSID + "'", con);
            con.Open();
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    exist = true;

                    string MW_Name = dr["woman_name"].ToString() + " / " + dr["husband_name"].ToString();
                    showalert("Record already exist in SQL Server, against the name of " + MW_Name);
                    dd_ParaList.Focus();
                }
            }
            finally
            {
                con.Close();
            }
            return exist;
        }




        public bool StatusCheckMySQL()
        {
            string DSSID = txtSite.Text + dd_ParaList.Text + txtBlock.Text + txtStruct.Text + txtHH.Text + txtWomanNumber.Text;

            bool exist = false;
            MySqlConnection con = new MySqlConnection(ConDataBase_COREDSS_MySQL);
            MySqlCommand cmd = new MySqlCommand("select * from married_woman where concat(site,para,block,structure,house_hold,woman_number)='" + DSSID + "'", con);
            con.Open();
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
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



        protected void submit_Click(object sender, EventArgs e)
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
                    string DSSID = txtSite.Text.ToUpper() + dd_ParaList.Text.ToUpper() + txtBlock.Text + txtStruct.Text + txtHH.Text.ToUpper() + txtWomanNumber.Text;
                    string DOB = null;


                    if (txtDOR.Text != "" && txtAge.Text != "")
                    {
                        DOB = (Convert.ToDateTime(txtDOR.Text).AddYears(-Convert.ToInt32(txtAge.Text))).ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }

                    // CoreDSS SQL Server:
                    if (StatusCheckSQL() == false)
                    {
                        SQL_Connection.Open();
                        SqlCommand cmd = new SqlCommand("insert into core_dss (dssid,woman_name,husband_name,age,dob,Remarks,status,entry_date,entry_name) values ('" + DSSID + "','" + txtWomanNm.Text.ToUpper() + "','" + txtHusbandNm.Text.ToUpper() + "','" + txtAge.Text + "','" + DOB + "' ,'" + txtremarks.InnerText + "' ,'1','" + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt", CultureInfo.InvariantCulture) + "','" + Convert.ToString(Session["ComplianceMaamtaLW"]) + "')", SQL_Connection);
                        cmd.ExecuteNonQuery();
                        SQL_Connection.Close();

                    }

                    // Married_Woman  MySQL:
                    if (StatusCheckMySQL() == false && txtSite.Text == "RG")
                    {
                        MySQL_Connection.Open();
                        MySqlCommand cmd = new MySqlCommand("insert into married_woman (site,para,block,structure,house_hold,woman_number,name,husband_name,age,dob) values ('" + txtSite.Text.ToUpper() + "','" + dd_ParaList.Text.ToUpper() + "','" + txtBlock.Text + "','" + txtStruct.Text + "','" + txtHH.Text.ToUpper() + "','" + txtWomanNumber.Text + "','" + txtWomanNm.Text.ToUpper() + "','" + txtHusbandNm.Text.ToUpper() + "','" + txtAge.Text + "','" + DOB + "')", MySQL_Connection);
                        cmd.ExecuteNonQuery();
                        MySQL_Connection.Close();
                    }

                    ClearTextBox();
                    showalert("Record Save Successfully!");
                    dd_ParaList.Focus();
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
            dd_ParaList.Items.Clear();
            ParaList();
            txtBlock.Text = "";
            txtStruct.Text = "";
            txtHH.Text = "";
            txtWomanNumber.Text = "";
            txtWomanNm.Text = "";
            txtHusbandNm.Text = "";
            txtAge.Text = "";
            txtremarks.InnerText = "";
        }



    }
}