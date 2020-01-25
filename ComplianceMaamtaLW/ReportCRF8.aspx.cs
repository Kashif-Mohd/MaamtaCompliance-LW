using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WebForms;

namespace ComplianceMaamtaLW
{
    public partial class ReportCRF8 : System.Web.UI.Page
    {

        static string Study_id;
        static string id;

        //MySQL 
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "ReportCRF8";
                DateFormatPageLoad();
                ShowData();
            }
        }

        private void DateFormatPageLoad()
        {
            txtCalndrDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate1.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtCalndrDate.Attributes.Add("readonly", "readonly");
            txtCalndrDate1.Attributes.Add("readonly", "readonly");
            txtCalndrDate.Enabled = true;
            txtCalndrDate1.Enabled = true;
            CheckBox1.Checked = false;
        }


        public void showalert(string message)
        {
            string script = @"alert('" + message + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
        }


        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtCalndrDate.Enabled = !CheckBox1.Checked;
            txtCalndrDate1.Enabled = !CheckBox1.Checked;
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == false && DateTime.ParseExact(txtCalndrDate.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture) > DateTime.ParseExact(txtCalndrDate1.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture))
            {
                showalert("First Date should be Less or Equal than Second Date");
                txtCalndrDate.Focus();
            }
            else
            {
                ShowData();
            }
            txtdssid.Focus();
        }



        private void ShowData()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                if (CheckBox1.Checked == false)
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_crf8 WHERE status='1' and dssid LIKE '%" + txtdssid.Text + "%' and (str_to_date(q2, '%d-%m-%Y') between str_to_date('" + txtCalndrDate.Text + "', '%d-%m-%Y') and str_to_date('" + txtCalndrDate1.Text + "', '%d-%m-%Y')) order by (str_to_date(q2, '%d-%m-%Y'))", con);
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
                else
                {
                    con.Open();
                    MySqlCommand cmd;
                    cmd = new MySqlCommand("select * from view_crf8 where status='1' and  dssid like '%" + txtdssid.Text + "%'  order by (str_to_date(q2, '%d-%m-%Y'))", con);
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




        private void GetInfo()
        {
            ReportViewer.Reset();

            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select *, mid(dssid,1,2) as q8,mid(dssid,3,2) as q9,mid(dssid,5,2) as q10,mid(dssid,7,3) as q11,mid(dssid,10,1) as q12,mid(dssid,11,1) as q13,(CASE  WHEN q47_01!='' THEN  CONCAT(q47_01,', ')	WHEN q47_01='' THEN  '' END)  AS xQ47_01, (CASE  WHEN q47_02!='' THEN  CONCAT(q47_02,', ')	WHEN q47_02='' THEN  '' END)  AS xQ47_02, (CASE  WHEN q47_03!='' THEN  CONCAT(q47_03,', ')	WHEN q47_03='' THEN  '' END)  AS xQ47_03, (CASE  WHEN q47_04!='' THEN  CONCAT(q47_04,', ')	WHEN q47_04='' THEN  '' END)  AS xQ47_04                from view_crf8 where status='1' and  study_id='" + Study_id + "' and id='" + id + "'", con);
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    string Q1 = dr["study_id"].ToString();
                    string Q2 = dr["q2"].ToString();
                    string Q3 = dr["q3"].ToString();
                    string Q4 = dr["q4"].ToString();
                    string Q5 = dr["q5"].ToString();
                    string Q6 = dr["q6"].ToString();
                    string Q7 = dr["q7"].ToString();
                    string Q8 = dr["q8"].ToString();
                    string Q9 = dr["q9"].ToString();
                    string Q10 = dr["q10"].ToString();
                    string Q11 = dr["q11"].ToString();
                    string Q12 = dr["q12"].ToString();
                    string Q13 = dr["q13"].ToString();
                    string Q14 = dr["q14"].ToString();
                    string Q15 = dr["q15"].ToString();
                    string Q16 = dr["q16"].ToString();
                    string Q17 = dr["q17"].ToString();
                    string Q18 = dr["q18"].ToString();
                    string Q19 = dr["q19"].ToString();
                    string Q20 = dr["q20"].ToString();
                    string Q21 = dr["q21"].ToString();
                    string Q22 = dr["q22"].ToString();
                    string Q23 = dr["q23"].ToString();
                    string Q24 = dr["q24"].ToString();
                    string Q25 = dr["q25"].ToString();
                    string Q26 = dr["q26"].ToString();
                    string Q27 = dr["q27"].ToString();
                    string Q27_other = dr["q27_other"].ToString();
                    string Q28 = dr["q28"].ToString();
                    string Q29_minutes = dr["q29_minutes"].ToString();
                    string Q29_hours = dr["q29_hours"].ToString();
                    string Q29_days = dr["q29_days"].ToString();
                    string Q30a_1dt = dr["q30a_1dt"].ToString();
                    string Q30a_1 = dr["q30a_1"].ToString();
                    string Q30a_2dt = dr["q30a_2dt"].ToString();
                    string Q30a_2 = dr["q30a_2"].ToString();
                    string Q30a_3dt = dr["q30a_3dt"].ToString();
                    string Q30a_3 = dr["q30a_3"].ToString();
                    string Q30a_4dt = dr["q30a_4dt"].ToString();
                    string Q30a_4 = dr["q30a_4"].ToString();
                    string Q30a_5dt = dr["q30a_5dt"].ToString();
                    string Q30a_5 = dr["q30a_5"].ToString();
                    string Q30a_6dt = dr["q30a_6dt"].ToString();
                    string Q30a_6 = dr["q30a_6"].ToString();
                    string Q30a_7dt = dr["q30a_7dt"].ToString();
                    string Q30a_7 = dr["q30a_7"].ToString();
                    string Q30a_8dt = dr["q30a_8dt"].ToString();
                    string Q30a_8 = dr["q30a_8"].ToString();
                    string Q30a_9dt = dr["q30a_9dt"].ToString();
                    string Q30a_9 = dr["q30a_9"].ToString();
                    string Q30a_10dt = dr["q30a_10dt"].ToString();
                    string Q30a_10 = dr["q30a_10"].ToString();
                    string Q30b_1dt = dr["q30b_1dt"].ToString();
                    string Q30b_1 = dr["q30b_1"].ToString();
                    string Q30b_2dt = dr["q30b_2dt"].ToString();
                    string Q30b_2 = dr["q30b_2"].ToString();
                    string Q30b_3dt = dr["q30b_3dt"].ToString();
                    string Q30b_3 = dr["q30b_3"].ToString();
                    string Q30b_4dt = dr["q30b_4dt"].ToString();
                    string Q30b_4 = dr["q30b_4"].ToString();
                    string Q30b_5dt = dr["q30b_5dt"].ToString();
                    string Q30b_5 = dr["q30b_5"].ToString();
                    string Q30b_6dt = dr["q30b_6dt"].ToString();
                    string Q30b_6 = dr["q30b_6"].ToString();
                    string Q30b_7dt = dr["q30b_7dt"].ToString();
                    string Q30b_7 = dr["q30b_7"].ToString();
                    string Q30b_8dt = dr["q30b_8dt"].ToString();
                    string Q30b_8 = dr["q30b_8"].ToString();
                    string Q30b_9dt = dr["q30b_9dt"].ToString();
                    string Q30b_9 = dr["q30b_9"].ToString();
                    string Q30b_10dt = dr["q30b_10dt"].ToString();
                    string Q30b_10 = dr["q30b_10"].ToString();
                    string Q31 = dr["q31"].ToString();
                    string Q31_other = dr["q31_other"].ToString();
                    string Q32_1a = dr["q32_1a"].ToString();
                    string Q32_1b = dr["q32_1b"].ToString();
                    string Q32_2a = dr["q32_2a"].ToString();
                    string Q32_2b = dr["q32_2b"].ToString();
                    string Q32_2c = dr["q32_2c"].ToString();
                    string Q32_3a = dr["q32_3a"].ToString();
                    string Q32_3b = dr["q32_3b"].ToString();
                    string Q32_3c = dr["q32_3c"].ToString();
                    string Q32_4a = dr["q32_4a"].ToString();
                    string Q32_4b = dr["q32_4b"].ToString();
                    string Q32_4c = dr["q32_4c"].ToString();
                    string Q32_4d = dr["q32_4d"].ToString();
                    string Q32_4e = dr["q32_4e"].ToString();
                    string Q32_4f = dr["q32_4f"].ToString();
                    string Q32_5a = dr["q32_5a"].ToString();
                    string Q32_5b = dr["q32_5b"].ToString();
                    string Q32_5c = dr["q32_5c"].ToString();
                    string Q32_5d = dr["q32_5d"].ToString();
                    string Q32_6a = dr["q32_6a"].ToString();
                    string Q32_6b = dr["q32_6b"].ToString();

                    string Q33_01 = dr["q33_01"].ToString();
                    string Q33_02 = dr["q33_02"].ToString();
                    string Q33_03 = dr["q33_03"].ToString();
                    string Q33_04 = dr["q33_04"].ToString();
                    string Q33_05 = dr["q33_05"].ToString();
                    string Q33_06 = dr["q33_06"].ToString();
                    string Q33_07 = dr["q33_07"].ToString();
                    string Q33_08 = dr["q33_08"].ToString();
                    string Q33_other = dr["q33_other"].ToString();

                    string Q34 = dr["q34"].ToString();
                    string Q34_other = dr["q34_other"].ToString();
                    string Q35 = dr["q35"].ToString();
                    string Q36 = dr["q36"].ToString();
                    string Q37 = dr["q37"].ToString();
                    string Q37_other = dr["q37_other"].ToString();
                    string Q38 = dr["q38"].ToString();
                    string Q38_other = dr["q38_other"].ToString();
                    string Q39 = dr["q39"].ToString();
                    string Q40 = dr["q40"].ToString();
                    string Q41 = dr["q41"].ToString();
                    string Q42 = dr["q42"].ToString();
                    string Q43 = dr["q43"].ToString();
                    string Q44 = dr["q44"].ToString();
                    string Q45 = dr["q45"].ToString();
                    string Q46 = dr["q46"].ToString();

                    string Q47_01 = dr["xQ47_01"].ToString();
                    string Q47_02 = dr["xQ47_02"].ToString();
                    string Q47_03 = dr["xQ47_03"].ToString();
                    string Q47_04 = dr["xQ47_04"].ToString();

                    string Q48 = dr["q48"].ToString();

                    string Q49_01 = dr["q49_01"].ToString();
                    string Q49_02 = dr["q49_02"].ToString();
                    string Q49_03 = dr["q49_03"].ToString();
                    
                    string Q50 = dr["q50"].ToString();
                    string Q51 = dr["q51"].ToString();
                    string Q52 = dr["q52"].ToString();




                    //if (Q18a == "1") Q18a = "Gestational age, ";
                    //if (Q18b == "2") Q18b = "Multiple pregnancy, ";
                    //if (Q18c == "3") Q18c = "Thr./missed abortion, ";
                    //if (Q18d == "4") Q18d = "Fetal death, ";
                    //if (Q18e == "5") Q18e = "Presentation, ";
                    //if (Q18f == "6") Q18f = "Placental localization, ";
                    //if (Q18g == "7") Q18g = "Hydatidiform mole, ";
                    //if (Q18h == "8") Q18h = "Fetal growth retardation, ";
                    //if (Q18i == "9") Q18i = "Fetal abnormality, ";

                    //string Q18 = Q18a + Q18b + Q18c + Q18d + Q18e + Q18f + Q18g + Q18h + Q18i + Q18j;








                    ReportParameterCollection ReportParameters = new ReportParameterCollection();
                    ReportViewer.LocalReport.ReportPath = "ReportCRF8.rdlc";
                    ReportViewer.LocalReport.DataSources.Clear();


                    ReportParameters.Add(new ReportParameter("Q1", Q1));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q2", Q2));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q3", Q3));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q4", Q4));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q5", Q5));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q6", Q6));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q7", Q7));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q8", Q8));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q9", Q9));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q10", Q10));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q11", Q11));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q12", Q12));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q13", Q13));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q14", Q14));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q15", Q15));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q16", Q16));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q17", Q17));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q18", Q18));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q19", Q19));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q20", Q20));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q21", Q21));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q22", Q22));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q23", Q23));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q24", Q24));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q25", Q25));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    if (Q26 == "1") Q26 = "LW";
                    else if (Q26 == "2") Q26 = "Infant";

                    ReportParameters.Add(new ReportParameter("Q26", Q26));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    if (Q27 == "1") Q27 = "LW herself";
                    else if (Q27 == "2") Q27 = "Research Team Member";
                    else if (Q27 == "3") Q27 = "Any other member of the family";
                    else if (Q27 == "4") Q27 = "Healthcare provider";
                    else if (Q27 == "5") Q27 = Q27_other;

                    ReportParameters.Add(new ReportParameter("Q27", Q27));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    if (Q28 == "1") Q28 = "After Maamta";
                    else if (Q28 == "2") Q28 = "After Azithromycin";
                    else if (Q28 == "3") Q28 = "Don’t know";
                    else if (Q28 == "4") Q28 = "No";
                    else if (Q28 == "5") Q28 = "Not applicable";

                    ReportParameters.Add(new ReportParameter("Q28", Q28));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q29_minutes", Q29_minutes));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q29_hours", Q29_hours));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q29_days", Q29_days));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    ReportParameters.Add(new ReportParameter("Q30a_1dt", Q30a_1dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_1", Q30a_1));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_2dt", Q30a_2dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_2", Q30a_2));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_3dt", Q30a_3dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_3", Q30a_3));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_4dt", Q30a_4dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_4", Q30a_4));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_5dt", Q30a_5dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_5", Q30a_5));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_6dt", Q30a_6dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_6", Q30a_6));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_7dt", Q30a_7dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_7", Q30a_7));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_8dt", Q30a_8dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_8", Q30a_8));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_9dt", Q30a_9dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_9", Q30a_9));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_10dt", Q30a_10dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30a_10", Q30a_10));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_1dt", Q30b_1dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_1", Q30b_1));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_2dt", Q30b_2dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_2", Q30b_2));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_3dt", Q30b_3dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_3", Q30b_3));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_4dt", Q30b_4dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_4", Q30b_4));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_5dt", Q30b_5dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_5", Q30b_5));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_6dt", Q30b_6dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_6", Q30b_6));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_7dt", Q30b_7dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_7", Q30b_7));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_8dt", Q30b_8dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_8", Q30b_8));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_9dt", Q30b_9dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_9", Q30b_9));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_10dt", Q30b_10dt));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q30b_10", Q30b_10));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q31 == "1") Q31 = "At home";
                    else if (Q31 == "2") Q31 = "At health care centre/clinic/hospital";
                    else if (Q31 == "3") Q31 = Q31_other;
                    ReportParameters.Add(new ReportParameter("Q31", Q31));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q32_1a == "1") Q32_1a = "Yes";
                    else if (Q32_1a == "2") Q32_1a = "No";
                    
                    if (Q32_2a == "1") Q32_2a = "Yes";
                    else if (Q32_2a == "2") Q32_2a = "No";
                    
                    if (Q32_3a == "1") Q32_3a = "Yes";
                    else if (Q32_3a == "2") Q32_3a = "No";
                    
                    if (Q32_4a == "1") Q32_4a = "Yes";
                    else if (Q32_4a == "2") Q32_4a = "No";
                    
                    if (Q32_5a == "1") Q32_5a = "Yes";
                    else if (Q32_5a == "2") Q32_5a = "No";
                    
                    if (Q32_6a == "1") Q32_6a = "Yes";
                    else if (Q32_6a == "2") Q32_6a = "No";

                    ReportParameters.Add(new ReportParameter("Q32_1a", Q32_1a));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q32_2a", Q32_2a));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q32_3a", Q32_3a));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q32_4a", Q32_4a));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q32_5a", Q32_5a));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q32_6a", Q32_6a));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);




                    if (Q33_01 == "1") Q33_01 = "Nothing, LW continues using LNS regularly, ";
                    if (Q33_02 == "2") Q33_02 = "Hold LNS for few days, ";
                    if (Q33_03 == "3") Q33_03 = "Discontinued LNS since ADR happened, ";
                    if (Q33_04 == "4") Q33_04 = "LW was hospitalized, ";
                    if (Q33_05 == "5") Q33_05 = "Infant was hospitalised, ";
                    if (Q33_06 == "6") Q33_06 = "Infant on injectable, ";
                    if (Q33_07 == "7") Q33_07 = "Not Applicable, ";
                    if (Q33_08 == "8") Q33_08 = Q33_other;

                    string Q33 = Q33_01 + Q33_02 + Q33_03 + Q33_04 + Q33_05 + Q33_06 + Q33_07 + Q33_08;

                    ReportParameters.Add(new ReportParameter("Q33", Q33));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    if (Q34 == "1") Q34 = "Resolved";
                    else if (Q34 == "2") Q34 = "Improved";
                    else if (Q34 == "3") Q34 = "Persist / Not Improved";
                    else if (Q34 == "4") Q34 = "Worsened";
                    else if (Q34 == "5") Q34 = "Death";
                    else if (Q34 == "6") Q34 = Q34_other;
                    else if (Q34 == "7") Q34 = "Treatment hold by the Family / LAMA";
                    ReportParameters.Add(new ReportParameter("Q34", Q34));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    ReportParameters.Add(new ReportParameter("Q35", Q35));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q36", Q36));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q37 == "1") Q37 = "At home";
                    else if (Q37 == "2") Q37 = "At healthcare centre/clinic/Hospital";
                    else if (Q37 == "3") Q37 = Q37_other;
                    else if (Q37 == "4") Q37 = "Not applicable";

                    ReportParameters.Add(new ReportParameter("Q37", Q37));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);



                    if (Q38 == "1") Q38 = Q38_other;
                    else if (Q38 == "2") Q38 = "Unknown";
                    else if (Q38 == "3") Q38 = "Not applicable";
                    
                    ReportParameters.Add(new ReportParameter("Q38", Q38));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    if (Q39 == "1") Q39 = "LNS supplement";
                    else if (Q39 == "2") Q39 = "Azithromycin";
                    else if (Q39 == "3") Q39 = "None";
                    
                    ReportParameters.Add(new ReportParameter("Q39", Q39));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    
                    
                    ReportParameters.Add(new ReportParameter("Q40", Q40));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q41 == "1") Q41 = "None";
                    else if (Q41 == "2") Q41 = "Remote";
                    else if (Q41 == "3") Q41 = "Possible";
                    else if (Q41 == "4") Q41 = "Probable";
                    else if (Q41 == "5") Q41 = "Definite";
                    else if (Q41 == "6") Q41 = "Not assessed";
                    else if (Q41 == "7") Q41 = "Not applicable";

                    ReportParameters.Add(new ReportParameter("Q41", Q41));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    if (Q42 == "1") Q42 = "None";
                    else if (Q42 == "2") Q42 = "Remote";
                    else if (Q42 == "3") Q42 = "Possible";
                    else if (Q42 == "4") Q42 = "Probable";
                    else if (Q42 == "5") Q42 = "Definite";
                    else if (Q42 == "6") Q42 = "Not assessed";
                    else if (Q42 == "7") Q42 = "Not applicable";
                    
                    ReportParameters.Add(new ReportParameter("Q42", Q42));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    ReportParameters.Add(new ReportParameter("Q43", Q43));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q44", Q44));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q45", Q45));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);
                    ReportParameters.Add(new ReportParameter("Q46", Q46));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);




                    // Additional Fields
                 
                    string Q47 = Q47_01 + Q47_02 + Q47_03 + Q47_04;
                    ReportParameters.Add(new ReportParameter("Q47", Q47));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    if (Q48 == "1") Q48 = "Completed";
                    else if (Q48 == "2") Q48 = "Still hospitalized";
                    else if (Q48 == "3") Q48 = "Death";
                    else if (Q48 == "4") Q48 = "LAMA";
                    else if (Q48 == "5") Q48 = "On going";
                    else if (Q48 == "6") Q48 = "Sudden death";
                    else if (Q48 == "7") Q48 = "Died at AKUH";
                    else if (Q48 == "8") Q48 = "Discharged on medication and died later";
                    else if (Q48 == "9") Q48 = "Refused";
                    else if (Q48 == "10") Q48 = "Persist";

                    ReportParameters.Add(new ReportParameter("Q48", Q48));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q49_01 == "1") Q49_01 = "IM/IV injectable, ";
                    if (Q49_02 == "2") Q49_02 = "Hospitalization, ";
                    if (Q49_03 == "3") Q49_03 = "Fatal ";

                    string Q49 = Q49_01 + Q49_02 + Q49_03;
                    ReportParameters.Add(new ReportParameter("Q49", Q49));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q50 == "1") Q50 = "Yes";
                    else if (Q50 == "2") Q50 = "No";
                    else if (Q50 == "3") Q50 = "Not Applicable";
                    ReportParameters.Add(new ReportParameter("Q50", Q50));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q51 == "1") Q51 = "Yes";
                    else if (Q51 == "2") Q51 = "No";
                    else if (Q51 == "3") Q51 = "Not Applicable";
                    ReportParameters.Add(new ReportParameter("Q51", Q51));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);

                    if (Q52 == "1") Q52 = "Yes";
                    else if (Q52 == "2") Q52 = "No";
                    else if (Q52 == "3") Q52 = "Not Applicable";
                    ReportParameters.Add(new ReportParameter("Q52", Q52));
                    this.ReportViewer.LocalReport.SetParameters(ReportParameters);


                    con.Close();
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowData();
        }



        protected void btnBack_Click(object sender, EventArgs e)
        {
            id = null;
            Study_id = null;
            Response.Redirect("ReportCRF8.aspx");
        }




        protected void Link_Study_id(object sender, EventArgs e)
        {
            id = null;
            Study_id = null;

            string[] commandArgs = ((LinkButton)sender).CommandArgument.ToString().Split(new char[] { ',' });
            Study_id = commandArgs[0];
            id = commandArgs[1];

            DivShow.Visible = false;
            DivReport.Visible = true;
            GetInfo();
        }

    }
}