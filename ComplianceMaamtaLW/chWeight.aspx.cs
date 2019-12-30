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
    public partial class chWeight : System.Web.UI.Page
    {
        string LiveServer = System.Configuration.ConfigurationManager.ConnectionStrings["LiveServerMaamtaLW"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["WebForm"] = "chWeight";
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
                cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm, DATE_FORMAT(str_to_date(j.lw_crf2_21, '%d-%m-%Y'), '%d-%m-%Y') as dob,	(select DATE_FORMAT(str_to_date(a.lw_crf4a_24, '%d-%m-%Y'), '%d-%m-%Y') from form_crf_4a as a where a.lw_crf4a_24!='' and a.study_id=q.study_id) as dod,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, 		 l.lw_crf3b_44 as gender,							i.lw_crf3c_2 as Enrollment_Date,i.lw_crf3c_15 as enrollment_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_V_Status,(select a.lw_crf6_20 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_V_Status,(select b.lw_crf6_20 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_V_Status,(select c.lw_crf6_20 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_V_Status,(select d.lw_crf6_20 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_V_Status,(select e.lw_crf6_20 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_weight ,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_V_Status,	(select f.lw_crf6_20 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_weight              		  from view_crf3c as i left join view_crf2 as j on i.assis_id=j.assis_id left join view_crf3b as l on l.study_code=i.study_code left join view_crf3a as m on m.study_id=i.study_code  left join studies as q on q.study_code=i.study_code  where i.dssid like '%" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
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

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                TableCell cell0 = e.Row.Cells[2];
                TableCell cell1 = e.Row.Cells[10];
                TableCell cell2 = e.Row.Cells[13];
                TableCell cell3 = e.Row.Cells[16];
                TableCell cell4 = e.Row.Cells[19];
                TableCell cell5 = e.Row.Cells[22];
                TableCell cell6 = e.Row.Cells[25];
                TableCell cell7 = e.Row.Cells[28];

                cell0.BackColor = System.Drawing.Color.FromName("#74b9ff");
                cell1.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell2.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell3.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell4.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell5.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell6.BackColor = System.Drawing.Color.FromName("#ffeaa7");
                cell7.BackColor = System.Drawing.Color.FromName("#ffeaa7");




                if (e.Row.Cells[8].Text == "f")
                {
                    e.Row.Cells[8].Text = "Female";
                }
                else if (e.Row.Cells[8].Text == "m")
                {
                    e.Row.Cells[8].Text = "Male";
                }


                // For Followup 1
                if (e.Row.Cells[12].Text == "1")
                {
                    e.Row.Cells[12].Text = "Complete";
                }
                else if (e.Row.Cells[12].Text == "2")
                {
                    e.Row.Cells[12].Text = "Refused";
                }
                else if (e.Row.Cells[12].Text == "3")
                {
                    e.Row.Cells[12].Text = "House Lock";
                }
                else if (e.Row.Cells[12].Text == "4")
                {
                    e.Row.Cells[12].Text = "Permanent Migrated";
                }


                // For Followup 2
                if (e.Row.Cells[15].Text == "1")
                {
                    e.Row.Cells[15].Text = "Complete";
                }
                else if (e.Row.Cells[15].Text == "2")
                {
                    e.Row.Cells[15].Text = "Refused";
                }
                else if (e.Row.Cells[15].Text == "3")
                {
                    e.Row.Cells[15].Text = "House Lock";
                }
                else if (e.Row.Cells[15].Text == "4")
                {
                    e.Row.Cells[15].Text = "Permanent Migrated";
                }

                // For Followup 3
                if (e.Row.Cells[18].Text == "1")
                {
                    e.Row.Cells[18].Text = "Complete";
                }
                else if (e.Row.Cells[18].Text == "2")
                {
                    e.Row.Cells[18].Text = "Refused";
                }
                else if (e.Row.Cells[18].Text == "3")
                {
                    e.Row.Cells[18].Text = "House Lock";
                }
                else if (e.Row.Cells[18].Text == "4")
                {
                    e.Row.Cells[18].Text = "Permanent Migrated";
                }


                // For Followup 4
                if (e.Row.Cells[21].Text == "1")
                {
                    e.Row.Cells[21].Text = "Complete";
                }
                else if (e.Row.Cells[21].Text == "2")
                {
                    e.Row.Cells[21].Text = "Refused";
                }
                else if (e.Row.Cells[21].Text == "3")
                {
                    e.Row.Cells[21].Text = "House Lock";
                }
                else if (e.Row.Cells[21].Text == "4")
                {
                    e.Row.Cells[21].Text = "Permanent Migrated";
                }


                // For Followup 5
                if (e.Row.Cells[24].Text == "1")
                {
                    e.Row.Cells[24].Text = "Complete";
                }
                else if (e.Row.Cells[24].Text == "2")
                {
                    e.Row.Cells[24].Text = "Refused";
                }
                else if (e.Row.Cells[24].Text == "3")
                {
                    e.Row.Cells[24].Text = "House Lock";
                }
                else if (e.Row.Cells[24].Text == "4")
                {
                    e.Row.Cells[24].Text = "Permanent Migrated";
                }

                // For Followup 6
                if (e.Row.Cells[27].Text == "1")
                {
                    e.Row.Cells[27].Text = "Complete";
                }
                else if (e.Row.Cells[27].Text == "2")
                {
                    e.Row.Cells[27].Text = "Refused";
                }
                else if (e.Row.Cells[27].Text == "3")
                {
                    e.Row.Cells[27].Text = "House Lock";
                }
                else if (e.Row.Cells[27].Text == "4")
                {
                    e.Row.Cells[27].Text = "Permanent Migrated";
                }
            }
        }







        protected void btnExport_Click(object sender, EventArgs e)
        {
            ShowData();
            if (GridView1.Rows.Count != 0)
            {
                ExcelExport();
            }
            txtdssid.Focus();
        }



        public void ExcelExportMessage()
        {
            if (txtdssid.Text != "")
            {
                GridView2.Caption = "DSSID, Search by: " + txtdssid.Text;
            }           
        }



        private void Exportdata()
        {
            MySqlConnection con = new MySqlConnection(LiveServer);
            try
            {
                con.Open();
                MySqlCommand cmd;
                cmd = new MySqlCommand("select i.study_code,i.dssid,i.q6 as woman_nm ,i.q7 as husband_nm, DATE_FORMAT(str_to_date(j.lw_crf2_21, '%d-%m-%Y'), '%d-%m-%Y') as dob,	(select DATE_FORMAT(str_to_date(a.lw_crf4a_24, '%d-%m-%Y'), '%d-%m-%Y') from form_crf_4a as a where a.lw_crf4a_24!='' and a.study_id=q.study_id) as dod,  DATEDIFF(CURDATE(),str_to_date(j.lw_crf2_21, '%d-%m-%Y')) as current_age, 		 l.lw_crf3b_44 as gender,							i.lw_crf3c_2 as Enrollment_Date,i.lw_crf3c_15 as enrollment_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=1 and z.study_code=i.study_code) as F1_V_Status,(select a.lw_crf6_20 from view_crf6 as a where a.followup_no=1 and a.study_code=i.study_code) as F1_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=2 and z.study_code=i.study_code) as F2_V_Status,(select b.lw_crf6_20 from view_crf6 as b where b.followup_no=2 and b.study_code=i.study_code) as F2_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=3 and z.study_code=i.study_code) as F3_V_Status,(select c.lw_crf6_20 from view_crf6 as c where c.followup_no=3 and c.study_code=i.study_code) as F3_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=4 and z.study_code=i.study_code) as F4_V_Status,(select d.lw_crf6_20 from view_crf6 as d where d.followup_no=4 and d.study_code=i.study_code) as F4_ch_weight,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=5 and z.study_code=i.study_code) as F5_V_Status,(select e.lw_crf6_20 from view_crf6 as e where e.followup_no=5 and e.study_code=i.study_code) as F5_ch_weight ,(select z.lw_crf6_2 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_DATE,(select z.lw_crf6_15 from view_crf6 as z where z.followup_no=6 and z.study_code=i.study_code) as F6_V_Status,	(select f.lw_crf6_20 from view_crf6 as f where f.followup_no=6 and f.study_code=i.study_code) as F6_ch_weight              		  from view_crf3c as i left join view_crf2 as j on i.assis_id=j.assis_id left join view_crf3b as l on l.study_code=i.study_code left join view_crf3a as m on m.study_id=i.study_code  left join studies as q on q.study_code=i.study_code  where i.dssid like '%" + txtdssid.Text + "%' group by i.study_code order by i.study_code", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    {
                        sda.Fill(dt);
                        GridView2.DataSource = dt;
                        GridView2.DataBind();
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




        public void ExcelExport()
        {
            try
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment;filename=Child Weigth (" + DateTime.Today.ToString("dd-MM-yyyy") + ").xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.xls";
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite =
                new HtmlTextWriter(stringWrite);
                GridView2.AllowPaging = false;
                ExcelExportMessage();
                GridView2.CaptionAlign = TableCaptionAlign.Top;
                Exportdata();
                for (int i = 0; i < GridView2.HeaderRow.Cells.Count; i++)
                {
                    GridView2.HeaderRow.Cells[i].Style.Add("background-color", "#5D7B9D");
                    GridView2.HeaderRow.Cells[i].Style.Add("Color", "white");
                }
                GridView2.RenderControl(htmlWrite);
                Response.Write(stringWrite.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write("<script type=\"text/javascript\">alert(" + ex.Message + ")</script>");

            }
        }


    }
}